using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private ProductList _prodList;
        private ClientList _clientList;
        private OrderList _orderList;


        public PHFoodOrderMgmtForm()
        {
            InitializeComponent();
        }


        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_orderForm == null) { _orderForm = new OrderForm(); }
            if (_orderList == null) { _orderList = new OrderList(); }


            _orderForm.ShowDialog();
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
            AddText(_txtQOProdQty, "Quantity");
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

        private void _txtQOProdQty_Enter(object sender, EventArgs e)
        {
            RemoveText(_txtQOProdQty);
        }

        private void _txtQOProdQty_Leave(object sender, EventArgs e)
        {
            AddText(_txtQOProdQty, "Quantity");
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_clientForm == null) { _clientForm = new ClientForm(); }
            if (_clientList == null) { _clientList = new ClientList(); }

            _clientForm.listClient = _clientList.Clients;
            _clientForm.ShowDialog();
        }

        private void OpenForm(Form frm)
        {
            
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_productForm == null) { _productForm = new ProductForm(); }
            if (_prodList == null) { _prodList = new ProductList(); }

            _productForm.ShowDialog();
        }
    }
}
