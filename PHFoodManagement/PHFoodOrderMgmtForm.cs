using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHFoodManagement
{
    public partial class PHFoodOrderMgmtForm : Form
    {
        private OrderForm _orderForm = new OrderForm();

        public PHFoodOrderMgmtForm()
        {
            InitializeComponent();
        }


        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_orderForm.Show();
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

        private void RemoveText(TextBox tbox)
        {
            
            tbox.Text = "";

        }

        private void AddText(TextBox txtbox, string placeholder)
        {
            if (String.IsNullOrWhiteSpace(txtbox.Text))
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
    }
}
