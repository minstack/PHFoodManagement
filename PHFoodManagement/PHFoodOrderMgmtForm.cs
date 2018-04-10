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
        private ProductList _prodList = new ProductList();
        private ClientList _clientList = new ClientList();
        private OrderList _orderList;
        private BindingSource _bndRecOrders = new BindingSource();
        private BindingSource _bndClients = new BindingSource();
        private BindingSource _bndProducts = new BindingSource();
        private PHFoodDB pfDB = new PHFoodDB();
        private Dictionary<Keys, string> _keysToDouble = new Dictionary<Keys, string>();

        public PHFoodOrderMgmtForm()
        {
            InitializeComponent();
            InitKeysToDouble();
        }

        private void InitKeysToDouble()
        {
            Keys[] digitsAndDot = {Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5
            ,Keys.D6, Keys.D7,Keys.D8, Keys.D9, Keys.Decimal};
            
            for (int i=0; i< digitsAndDot.Length - 1; i++)
            {
                _keysToDouble.Add(digitsAndDot[i], i.ToString());
            }

            _keysToDouble.Add(digitsAndDot[digitsAndDot.Length - 1], ".");

        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_orderForm == null) { _orderForm = new OrderForm(); }

            _orderForm.Orders = _orderList.Orders;
            _orderForm.Products = _prodList.Products;
            _orderForm.Clients = _clientList.Clients;
            _orderForm.ShowDialog();

            _orderList.Orders = _orderForm.Orders;
            ResetRecentOrderList();
            
        }

        private void ResetRecentOrderList()
        {
            ControlUtil.ResetList(_orderList.Orders, _bndRecOrders, _lstRecentOrders, "ToString");
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

            _clientList.GetClientsFromDB(pfDB);
            _prodList.InitProductsFromDB(pfDB);

            _orderList = new OrderList(_prodList.Products, _clientList.Clients);

            ResetProductList();
            ResetClientList();

        }

        private void ResetProductList()
        {
            ControlUtil.ResetList(_prodList.Products, _bndProducts, _lstProducts, "ProductName");
        }

        private void ResetClientList()
        {
            ControlUtil.ResetList(_clientList.Clients, _bndClients, _lstClients, "name");
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

            _clientForm.listClient = _clientList.Clients;
            _clientForm.ShowDialog();
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

                if(e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
                {
                    key = ".";
                }
                else
                {
                    GetLastChar(e.KeyCode.ToString(), out key);
                }
                
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
    }
}
