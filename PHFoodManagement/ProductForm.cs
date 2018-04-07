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
    public partial class ProductForm : Form
    {
        List<Product> products = new List<Product>();
        
        Product product = new Product();
        public ProductForm()
        {
            InitializeComponent();

            products.Add(new Product("Product one", 33.4M, "Product descrition one", true));
            products.Add(new Product("Product two", 23.4M, "Product descrition one", false));
            products.Add(new Product("Product three", 63.4M, "Product descrition one", true));

            ListProducts();
        }

        private void ListProducts()
        {
            foreach (Product product in products)
            {
                ListViewItem item = new ListViewItem(new String[] { product.ProductName,
                        product.Price.ToString()  });
                item.Tag = product;
                _lvProducts.Items.Add(item);
            }
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_txtName.Text) || String.IsNullOrWhiteSpace(_txtPrice.Text) || String.IsNullOrWhiteSpace(_txtDescription.Text))
            {
                MessageBox.Show("Product was not added! Some information was missing, please make sure to fill all the required fields.", "Product no added.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Product newProduct = new Product();
                //set properties
                newProduct.ProductName = _txtName.Text;
                decimal d;
                if (decimal.TryParse(_txtPrice.Text, out d))
                {
                    newProduct.Price = d; ;
                }
                else
                {
                    MessageBox.Show("The product price you is no valid.", "Price not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                newProduct.Description = _txtDescription.Text;

                //check if organic
                if (_cbOrganic.Checked)
                    newProduct.Organic = true;
                else
                    newProduct.Organic = false;

                //check if item is already in the list, if not add it and print in the listview
                if (products.Any(item => item.ProductName == newProduct.ProductName))
                {
                    MessageBox.Show("The product you are trying to add already exists.", "Product exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    products.Add(newProduct);
                    //ListViewItem lvItem = new ListViewItem(new string[] { newProduct.ProductName, newProduct.Price.ToString() });
                    //_lvProducts.Items.Add(lvItem);
                    //lvItem.Tag = Product;

                    //clear and list
                    ClearAndList();
                }
            }
        }

        private void _lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_lvProducts.SelectedItems.Count > 0)
            {
                ListViewItem item = _lvProducts.SelectedItems[0];
                product = (Product)item.Tag;
                _txtName.Text = product.ProductName;
                _txtPrice.Text = Convert.ToString(product.Price);
                _txtDescription.Text = product.Description;

                if (product.Organic)
                    _cbOrganic.Checked = true;
                else
                    _cbOrganic.Checked = false;
            }

            ControlUtil.DisableButtons(_btnSave);
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            if (_lvProducts.SelectedItems.Count > 0)
            {
                Product product = new Product();
                ListViewItem item = _lvProducts.SelectedItems[0];
                product = (Product)item.Tag;

                product.ProductName = _txtName.Text;
                product.Price = Convert.ToDecimal(_txtPrice.Text);
                product.Description = _txtDescription.Text;
                //check if organic
                if (_cbOrganic.Checked)
                    product.Organic = true;
                else
                    product.Organic = false;

                //list and clear
                ClearAndList();
            }
            else
            {
                MessageBox.Show("Select a product from the list to edit.", "Product not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ControlUtil.EnableButtons(_btnSave);
        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            if (_lvProducts.SelectedItems.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm == DialogResult.OK)
                {
                    Product product = new Product();
                    ListViewItem item = _lvProducts.SelectedItems[0];
                    product = (Product)item.Tag;
                    products.Remove(product);
                }

                //list and clear
                ClearAndList();
            }
            else
            {
                MessageBox.Show("Select a product from the list to delete.", "Product not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ControlUtil.EnableButtons(_btnSave);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            ClearAndList();
            ControlUtil.EnableButtons(_btnSave);
            this.Close();
        }

        private void ClearAndList()
        {
            _lvProducts.Items.Clear();
            ListProducts();
            ControlUtil.ClearTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Checked = false;
        }
    }
}
