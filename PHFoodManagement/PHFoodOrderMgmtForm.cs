﻿using System;
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

        private void _btnOrders_Click(object sender, EventArgs e)
        {
            //_orderForm.Show();
        }
    }
}
