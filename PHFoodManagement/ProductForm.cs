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

        ProductDB db = new ProductDB();
        public List<Product> products;
        Product product = new Product();
        Product proEdit = new Product();
        Product proNew = new Product();

        public ProductForm()
        {
            InitializeComponent();
            products = db.GetProducts();
            ListProducts();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            ControlUtil.DisableButtons(_btnSave, _btnEdit, _btnDelete);
            ControlUtil.EnableButtons(_btnNew);
            ControlUtil.ClearTextBoxes(_txtName, _txtPrice, _txtDescription);
            ControlUtil.DisableTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Checked = false;
            _cbOrganic.Enabled = false;
        }
        
        private void _btnNew_Click(object sender, EventArgs e)
        {
            ControlUtil.DisableButtons(_btnNew);
            ControlUtil.EnableButtons(_btnSave);
            ControlUtil.EnableTextBoxes(_txtName, _txtPrice, _txtDescription);
            ControlUtil.ClearTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Checked = false;
            _cbOrganic.Enabled = true;
            product = proNew;
        }

        private void ListProducts()
        {
            foreach (Product product in products)
            {
                ListViewItem item = new ListViewItem(
                    new String[] 
                    {
                        product.ProductName,
                        product.Price.ToString()
                    });

                item.Tag = product;
                _lvProducts.Items.Add(item);
            }
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            //If the product was selected from listview and the edit button was pressed
            //Edit product
            if (_lvProducts.SelectedItems.Count > 0 && product == proEdit)
            {
                ListViewItem item = _lvProducts.SelectedItems[0]; 
                product = (Product)item.Tag;

                product.ProductName = _txtName.Text;
                product.Price = Convert.ToDecimal(_txtPrice.Text);
                product.Description = _txtDescription.Text;
                product.Organic = checkIfOrganic();

                bool edited = db.updateProduct(product.Id, product.ProductName, product.Organic, product.Price, product.Description);

                if (!edited)
                {
                    MessageBox.Show("Product could not be updated. Please try again!", "Product update error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                //Clear the listview
                _lvProducts.Items.Clear();

                //Update the listview with the new data
                ListProducts();

                _lvProducts.Items[0].Selected = true;
            }
            else if(product == proNew)
            {
                if (String.IsNullOrWhiteSpace(_txtName.Text) || 
                    String.IsNullOrWhiteSpace(_txtPrice.Text) || 
                    String.IsNullOrWhiteSpace(_txtDescription.Text))
                {
                    MessageBox.Show("Could not add the product! Some information is missing. " +
                        "Please make sure to fill all the required fields.", "Product no added.", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Product newProduct = new Product();

                    newProduct.ProductName = _txtName.Text;

                    decimal d;
                    if (decimal.TryParse(_txtPrice.Text, out d))
                        newProduct.Price = d;
                    else
                        MessageBox.Show("The product price is not valid.", "Price not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    newProduct.Description = _txtDescription.Text;

                    newProduct.Organic = checkIfOrganic();

                    //check if item is already in the list, if not add it and print in the listview
                    if (products.Any(item => item.ProductName == newProduct.ProductName))
                    {
                        MessageBox.Show("The product you are trying to add already exists.", "Product exists", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bool added = db.AddProduct(newProduct.ProductName, newProduct.Organic, newProduct.Price, newProduct.Description);
                        if (added)
                        {
                            products.Add(newProduct);
                        }
                        else
                        {
                            MessageBox.Show("The product was not added. Please try again!", "Product Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        _lvProducts.Items.Clear();
                        ListProducts();
                    }
                }
            }

            _lvProducts.Items[0].Selected = true;
            ControlUtil.DisableButtons(_btnSave);
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            ControlUtil.DisableTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Enabled = false;
        }

        private void _lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lvProducts.SelectedItems.Count > 0)
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
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            ControlUtil.DisableTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Enabled = false;
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            product = proEdit;
            //editing = true;
            ControlUtil.EnableTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Enabled = true;
            ControlUtil.EnableButtons(_btnSave);
            ControlUtil.DisableButtons(_btnEdit, _btnDelete, _btnNew);
        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            if (_lvProducts.SelectedItems.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", 
                    "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm == DialogResult.OK)
                {
                    Product product = new Product();
                    ListViewItem item = _lvProducts.SelectedItems[0];
                    product = (Product)item.Tag;
                    bool deleted = db.deleteProduct(product.Id);

                    if (deleted)
                        products.Remove(product);
                }
            }
            else
            {
                MessageBox.Show("Select a product from the list to delete.", "Product not selected", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _lvProducts.Items.Clear();
            ListProducts();
            ControlUtil.DisableButtons(_btnSave, _btnEdit, _btnDelete);
            ControlUtil.EnableButtons(_btnNew);
            ControlUtil.ClearTextBoxes(_txtName, _txtPrice, _txtDescription);
            ControlUtil.DisableTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Checked = false;
            _cbOrganic.Enabled = false;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            ControlUtil.EnableButtons(_btnNew);
            ControlUtil.DisableButtons(_btnSave, _btnEdit, _btnDelete);
            ControlUtil.ClearTextBoxes(_txtName, _txtPrice, _txtDescription);
            ControlUtil.DisableTextBoxes(_txtName, _txtPrice, _txtDescription);
            _cbOrganic.Checked = false;
            _cbOrganic.Enabled = false;
        }

        private bool checkIfOrganic()
        {
            if (_cbOrganic.Checked)
                return true;
            else
                return false;
        }
        
    }
}
