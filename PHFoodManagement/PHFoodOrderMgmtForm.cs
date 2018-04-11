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
        private OrderList _orderList;
        private BindingSource _bndClients = new BindingSource();
        private BindingSource _bndProducts = new BindingSource();
        private BindingSource _bndQOorder = new BindingSource();
        private Order _quickOrder;
        private List<Client> _clients = new List<Client>();
        

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
            AddText(_txtClientSearch, "Client Search");
            AddText(_txtProdSearch, "Product Search");
            //AddText(_txtQOProdQty, "Quantity");

            //_clientList.GetClientsFromDB(pfDB);
            //_prodList.InitProductsFromDB(pfDB);

            //_orderList = new OrderList(_prodList.Products, _clientList.Clients);

            //ResetProductList();
            //ResetClientList();

            _toolTip.Show("Select a client and product.\nType the quantity with the product selected and press enter to add to the quick order.", _lstProducts, 15000);

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
            if (_clientForm == null) { _clientForm = new ClientForm(); }

            _clientForm.listClient = _clients ;
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

                _orderList.AddOrder(_quickOrder);
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
    }
}
