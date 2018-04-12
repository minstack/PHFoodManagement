using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private bool _searching = false;

        public PHFoodOrderMgmtForm()
        {
            InitializeComponent();

        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_orderForm == null) { _orderForm = new OrderForm(); }

            InitOrderForm();
            _orderForm.ShowDialog();

            //_orderList.Orders = _orderForm.Orders;
            
        }

        private void _txtClientSearch_Enter(object sender, EventArgs e)
        {
            RemoveText(_txtClientSearch);
        }

        private void _txtClientSearch_Leave(object sender, EventArgs e)
        {
            AddText(_txtClientSearch, "Client Search");
        }

        private void _txtProdSearch_Enter(object sender, EventArgs e)
        {
            RemoveText(_txtProdSearch);
        }

        private void _txtProdSearch_Leave(object sender, EventArgs e)
        {
            AddText(_txtProdSearch, "Product Search");
        }

        private void PHFoodOrderMgmtForm_Load(object sender, EventArgs e)
        {
            InitSubForms();
            
            //AddText(_txtClientSearch, "Client Search");
            //AddText(_txtProdSearch, "Product Search");
            

        }

        private void InitSubForms()
        {
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
            
            //_orders = _orderForm.Orders;
            

            _stsLoadingMessage.Text = "";
        }

        //private void ResetProductList()
        //{
        //    ControlUtil.ResetList(_prodList.Products, _bndProducts, _lstProducts, "ProductName");
        //}

        private void ResetClientList()
        {
            ControlUtil.ResetList(_clients, _bndClients, _lstClients, "name");
        }

        private void RemoveText(params TextBox[] tboxes)
        {
            ControlUtil.ClearTextBoxes(tboxes);
        }

        private void AddText(TextBox txtbox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                txtbox.Text = placeholder;
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            _clientForm.ShowDialog();
            ResetClientList();
        }

        private void OpenForm(Form frm)
        {
            
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_productForm == null) { _productForm = new ProductForm(); }
            
            _productForm.ShowDialog();
            ResetProductList();
        }

        private void ResetProductList()
        {
            ControlUtil.ResetList(_products, _bndProducts, _lstProducts, "ToString");
        }

        private void _lstProducts_KeyDown(object sender, KeyEventArgs e)
        {
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
                if (System.Text.RegularExpressions.Regex.IsMatch(key, @"^[\d\.]$"))
                {
                    _txtQOProdQty.Text += key;
                }
            }
        }

        private void GetLastChar(string pressed, out string key)
        {
            key = pressed.Substring(pressed.Length - 1);
        }

        private void _btnAddProdQuick_Click(object sender, EventArgs e)
        {
            Client client = (Client) _lstClients.SelectedItem;
            Product prod = (Product)_lstProducts.SelectedItem;

            if (!double.TryParse(_txtQOProdQty.Text, out double qty))
            {
                //error
                return;
            }

            if (client == null)
            {
                //error
                return;
            }
            if (prod == null)
            {
                //error
                return;
            }

            if (_quickOrder == null)
            {
                _quickOrder = new Order {
                    Client = client,
                    DeliveryDate = DateTime.Today,
                    OrderDate = DateTime.Today
                };

                //_orderList.AddOrder(_quickOrder);
                //_orderForm.Orders.Add(_quickOrder);
            }            

            _txtQOClient.Text = client.name;

            _quickOrder.AddProduct(prod, qty);
            ResetQuickOrderList(_quickOrder.OrderItems);
            UpdateTotal(_quickOrder);            
            _pnlClients.Enabled = false;
            _txtQOProdQty.Clear();
        }

        private void UpdateTotal(Order quickOrder)
        {
            _txtQOTotal.Text = quickOrder.CalculateTotal().ToString();
        }

        private void ResetQuickOrderList(List<OrderItem> ois)
        {
            ControlUtil.ResetList(ois, _bndQOorder, _lstQOProducts, "ToString");
        }

        private void _btnQOFinalize_Click(object sender, EventArgs e)
        {
            if (_quickOrder == null)
            {
                return;
            }

            if (_orderForm == null)
            {
                InitOrderForm();
            }
            _orderForm.InitQOOrder(_quickOrder);
            _orderForm.ShowDialog();
            ResetQuickOrder();
        }

        private void ResetQuickOrder()
        {
            _pnlClients.Enabled = true;
            _quickOrder = null;
            _lstQOProducts.DataSource = null;
            _txtQOClient.Clear();
            _txtQOTotal.Clear();
        }

        private void InitOrderForm()
        {
            _orderForm = new OrderForm();
            _orderForm.Clients = _clients;
            _orderForm.Products = _products;
            _orderForm.LoadOrders();
            //_orderForm.Orders = _orderList.Orders;
            //_orderForm.Clients = _clientList.Clients;
            //_orderForm.Products = _prodList.Products;
        }

        private void _lstProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _btnAddProdQuick_Click(sender, e);
            }
        }

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

        private void _txtClientSearch_TextChanged(object sender, EventArgs e)
        {
            FilterList(_clients, _clientSearchList, 
                _lstClients, _txtClientSearch.Text, _bndClients, "name");
        }

        private List<Client> _clientSearchList = new List<Client>();
        private List<Product> _prodSearchList = new List<Product>();

        private void _txtProdSearch_TextChanged(object sender, EventArgs e)
        {
            FilterList(_products, _prodSearchList,
                _lstProducts, _txtProdSearch.Text, _bndProducts, "name");
        }

        private void SetSearchMessage()
        {
            _stsLoadingMessage.Text = "Start typing to search the list.";
        }

        private void ClearStatusMessage()
        {
            _stsLoadingMessage.Text = "";
        }

        private void _txtProdSearch_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void _txtProdSearch_MouseEnter(object sender, EventArgs e)
        {
            SetSearchMessage();
        }

        private void _txtProdSearch_MouseLeave(object sender, EventArgs e)
        {
            ClearStatusMessage();
        }

        private void _txtClientSearch_MouseEnter(object sender, EventArgs e)
        {
            SetSearchMessage();
        }

        private void _txtClientSearch_MouseLeave(object sender, EventArgs e)
        {
            ClearStatusMessage();
        }
    }
}
