using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMUtil;

namespace PHFoodManagement
{
    public partial class PHFoodOrderMgmtForm : Form
    {
        private OrderForm _orderForm;
        private ClientForm _clientForm;
        private ProductForm _productForm;
        private BindingSource _bndClients = new BindingSource();
        private BindingSource _bndProducts = new BindingSource();
        private BindingSource _bndQOorder = new BindingSource();
        private Order _quickOrder;
        private List<Client> _clients = new List<Client>();
        private List<Product> _products = new List<Product>();
        private List<Client> _clientSearchList = new List<Client>();
        private List<Product> _prodSearchList = new List<Product>();

        public PHFoodOrderMgmtForm()
        {
            InitializeComponent();

        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitOrderForm();
            _orderForm.ShowDialog();            
        }
        
        private void PHFoodOrderMgmtForm_Load(object sender, EventArgs e)
        {
            InitSubForms();
        }

        private void InitSubForms()
        {
            //not sure if these loading status bar messages will
            //actually work when there are more items to load from db
            //since this isn't multithreaded...
            _stsLoadingMessage.Text = "Loading clients...";
            _clientForm = new ClientForm();
            _clients = _clientForm.listClient;
            ResetClientList();

            _stsLoadingMessage.Text = "Loading products...";
            _productForm = new ProductForm();
            _products = _productForm.products;
            ResetProductList();

            _stsLoadingMessage.Text = "Loading orders...";
            InitOrderForm();
            
            _stsLoadingMessage.Text = "";
        }

        private void ResetClientList()
        {
            ControlUtil.ResetList(_clients, _bndClients, _lstClients, "name");
        }
        
        //client form open
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            _clientForm.ShowDialog();
            ResetClientList();
        }

        //product form open
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _productForm.ShowDialog();
            ResetProductList();
        }

        private void ResetProductList()
        {
            ControlUtil.ResetList(_products, _bndProducts, _lstProducts, "ToString");
        }

        //the underlying functionality to make the quick order, quick
        private void _lstProducts_KeyDown(object sender, KeyEventArgs e)
        {
            //to have full functionality as typing in the
            //textbox
            if (e.KeyCode == Keys.Back)
            {
                string tempQty = _txtQOProdQty.Text;

                if (tempQty.Length > 0)
                {
                    tempQty = tempQty.Substring(0, tempQty.Length-1);
                    _txtQOProdQty.Text = tempQty;
                }

                return;
            }

            //make sure that an item is selected
            //prevents useless processing if there isnt'
            if (_lstProducts.SelectedItem != null)
            {
                string key;

                //check period or get last character of keycode since digits
                //end with the actual digit (D9, NumPad9)
                if(e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
                {
                    key = ".";
                }
                else
                {
                    GetLastChar(e.KeyCode.ToString(), out key);
                }
                
                //only populate digits and periods
                if (Regex.IsMatch(key, @"^[\d\.]$"))
                {
                    _txtQOProdQty.Text += key;
                }
            }
        }

        private void GetLastChar(string pressed, out string key)
        {
            key = pressed.Substring(pressed.Length - 1);
        }

        //adding product to the quick order
        private void _btnAddProdQuick_Click(object sender, EventArgs e)
        {
            Client client = (Client) _lstClients.SelectedItem;
            Product prod = (Product)_lstProducts.SelectedItem;
            string error = "";

            if (!double.TryParse(_txtQOProdQty.Text, out double qty))
            {
                error += "Quantity must be a number.\n";
            }

            if (client == null)
            {
                error += "Client must be selected.\n";
            }
            if (prod == null)
            {
                error += "Product must be selected.\n";
            }

            if (error.Length > 0)
            {
                ShowError("Invalid Values", error);
                return;
            }

            //this point -> valid values
            if (_quickOrder == null)
            {
                _quickOrder = new Order {
                    Client = client,
                    DeliveryDate = DateTime.Today,
                    OrderDate = DateTime.Today
                };
            }            

            _txtQOClient.Text = client.name;
            _quickOrder.AddProduct(prod, qty);

            ResetQuickOrderList(_quickOrder.OrderItems);
            UpdateTotal(_quickOrder);  
            
            _pnlClients.Enabled = false;
            _txtQOProdQty.Clear();
        }

        //to be easily called for a messagebox with icons
        //prevent typing out all the enums
        private void ShowError(string v, string error)
        {
            MessageBox.Show(error, v, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //updates the total for the current quick order
        private void UpdateTotal(Order quickOrder)
        {
            _txtQOTotal.Text = quickOrder.CalculateTotal().ToString();
        }

        //resets the quick order order item list
        private void ResetQuickOrderList(List<OrderItem> ois)
        {
            ControlUtil.ResetList(ois, _bndQOorder, _lstQOProducts, "ToString");
        }

        //finalize quick order -> open in editing mode in order form
        private void _btnQOFinalize_Click(object sender, EventArgs e)
        {
         
            if (_quickOrder == null)
            {
                ShowError("No Order", 
                    "Please add a client and products " +
                    "with quantity to create an order.");
                return;
            }

            if (_orderForm == null)
            {
                InitOrderForm();
            }

            //quickorder must be passed for initialization
            //in order form before showing
            _orderForm.InitQOOrder(_quickOrder);
            _orderForm.ShowDialog();
            ResetQuickOrder();
        }

        //resets the quick order 
        private void ResetQuickOrder()
        {
            _pnlClients.Enabled = true;
            _quickOrder = null;
            _lstQOProducts.DataSource = null;
            _txtQOClient.Clear();
            _txtQOTotal.Clear();
        }

        //initializes the order form with all necessary setup
        private void InitOrderForm()
        {
            _orderForm = new OrderForm();
            _orderForm.Clients = _clients;
            _orderForm.Products = _products;
            _orderForm.LoadOrders();
        }

        //event for when user presses enter to add a product to a quickorder
        private void _lstProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _btnAddProdQuick_Click(sender, e);
            }
        }

        //general method to filter and update the lists of product
        //and client
        private void FilterList<T>(List<T> original, List<T> searchList, 
            ListBox lbox, string searchTerm, BindingSource bndsrc, string dispMemb)
        {
            if (original.Count > 0)
            {
                List<T> currList = original;
                searchList.Clear();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    ControlUtil.ResetList(original, bndsrc, lbox, dispMemb);
                }
                else
                {
                    //this only works since both client and product
                    //have tostrings overridden with their names
                    foreach (T obj in original)
                    {
                        if (obj.ToString().ToLower().Contains(searchTerm.ToLower()))
                        {
                            searchList.Add(obj);
                        }                        
                    }

                    currList = searchList;
                    ControlUtil.ResetList(searchList, bndsrc, lbox, dispMemb);
                    
                }

                SetSearchingState(currList, lbox);
            }
        }

        // State of the form has been changed -> change to appropriate state
        // for controls.
        private void SetSearchingState<T>(List<T> list, ListBox lbox)
        {
            
            if (list.Count == 0)
            {
                _btnAddProdQuick.Enabled = false;
            }
            else
            {
                lbox.SelectedIndex = 0;
                _btnAddProdQuick.Enabled = true;
            }
        }

        //filters client search list
        private void _txtClientSearch_TextChanged(object sender, EventArgs e)
        {
            FilterList(_clients, _clientSearchList, 
                _lstClients, _txtClientSearch.Text, _bndClients, "name");
        }
                
        //filters the list of product search
        private void _txtProdSearch_TextChanged(object sender, EventArgs e)
        {
            FilterList(_products, _prodSearchList,
                _lstProducts, _txtProdSearch.Text, _bndProducts, "name");
        }

        //general statusbar tooltip for product and client search
        private void SetSearchMessage()
        {
            _stsLoadingMessage.Text = "Start typing to search the list.";
        }

        //clears the statusbar message
        private void ClearStatusMessage()
        {
            _stsLoadingMessage.Text = "";
        }

        //Product search statusbar tooltip
        private void _txtProdSearch_MouseEnter(object sender, EventArgs e)
        {
            SetSearchMessage();
        }

        //clear product search statusbar 'tooltip'
        private void _txtProdSearch_MouseLeave(object sender, EventArgs e)
        {
            ClearStatusMessage();
        }

        //client search textbox hover statusbar 'tooltip'
        private void _txtClientSearch_MouseEnter(object sender, EventArgs e)
        {
            SetSearchMessage();
        }

        //clears the statusbar message for search 'tooltip'
        private void _txtClientSearch_MouseLeave(object sender, EventArgs e)
        {
            ClearStatusMessage();
        }

        //if user chooses to type into the qty textbox
        //ensures that only digits and decimal is allowed
        private void _txtQOProdQty_TextChanged(object sender, EventArgs e)
        {
            _txtQOProdQty.Text = RemoveNonDigits(_txtQOProdQty.Text);
        }

        // revised from https://stackoverflow.com/a/262466
        private string RemoveNonDigits(string text)
        {
            Regex digitsOnly = new Regex(@"[^\d^\.]");
            return digitsOnly.Replace(text, "");
        }

        //statusbar 'tooltip' for product list, since just by looking at the interface
        //may not be intuitive of the underlying functionality
        private void _lstProducts_MouseEnter(object sender, EventArgs e)
        {
            _stsLoadingMessage.Text = "Select product and type in quantity. Press enter to add to order.";
        }

        //for clearing statusbar 'tooltip'
        private void _lstProducts_MouseLeave(object sender, EventArgs e)
        {
            ClearStatusMessage();
        }

        //cancel the current quickorder
        private void _btnQoCancel_Click(object sender, EventArgs e)
        {
            if (_quickOrder == null)
            {
                return;
            }

            _quickOrder.OrderItems = null;
            ResetQuickOrderList(_quickOrder.OrderItems);
            _quickOrder = null;
            _pnlClients.Enabled = true;
            _txtQOClient.Clear();
        }

        //close app
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //same functionality as enter in lst products
        private void _txtQOProdQty_KeyUp(object sender, KeyEventArgs e)
        {
            _lstProducts_KeyUp(sender, e);
        }

        //remove order item from quick order
        private void _btnRemoveProduct_Click(object sender, EventArgs e)
        {
            OrderItem selected = (OrderItem)_lstQOProducts.SelectedItem;

            if (selected == null)
            {
                return;
            }

            if (_quickOrder == null)
            {
                return;
            }

            _quickOrder.OrderItems.Remove(selected);
            UpdateTotal(_quickOrder);
            ResetQuickOrderList(_quickOrder.OrderItems);
            _lstQOProducts_SelectedIndexChanged(sender, e);
        }

        //enabled/disabled delete button based on list
        private void _lstQOProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _btnRemoveProduct.Enabled = _lstQOProducts.Items.Count > 0;
        }
    }
}
