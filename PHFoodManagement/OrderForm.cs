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
    public partial class OrderForm : Form
    {
        public List<Order> Orders { get; set; }
        public List<Client> Clients { private get; set; }
        public List<Product> Products { private get; set; }
        public int NextOrderNum { get; set; }
        private BindingSource _bndOrders = new BindingSource();
        private BindingSource _bndOrderItems = new BindingSource();
        private BindingSource _bndProductCbo = new BindingSource();
        private BindingSource _bndClientCbo = new BindingSource();
        private Dictionary<Control, Label> _requiredFieldLbls = new Dictionary<Control, Label>();
        private Dictionary<Control, string> _requiredErrors = new Dictionary<Control, string>();
        private Control[] _requiredControls;
        private Order _currOrder;
        private Label _prevErrLabel;
        private bool _editing = false;

        public OrderForm()
        {
            InitializeComponent();
            SetInitialState();

            _requiredControls = new Control[]{
                 _dpDeliveryDate,
                 _cboOrderClient,
                 _lstOrderProducts,
                 _nmbProductQty
            };

            //temporary until DB implementation
            NextOrderNum = 1;

            InitRequiredDictionary(_requiredControls);
            InitRequiredErrors(_requiredControls);
        }

        private void InitRequiredErrors(Control[] ctrls)
        {
            string[] temp = {
                "Delivery date must not be before today.",
                "A client must be selected.",
                "At least one product must be selected and added.",
                "Quantity must be greater than 0 and denominations of 0.5"
            };
            
            for (int i = 0; i < ctrls.Length; i ++)
            {
                _requiredErrors.Add(ctrls[i], temp[i]);
            }
        }

        private void InitRequiredDictionary(Control[] ctrls)
        {
            Label[] temp = {
                _lblDelDate,
                _lblClient,
                _lblOrderProducts,
                _lblProductQty
            };

            for (int i = 0; i < ctrls.Length; i++)
            {
                _requiredFieldLbls.Add(ctrls[i], temp[i]);
            }
        }

        private void SetInitialState()
        {
            ControlUtil.DisableButtons(_btnEdit, _btnDelete, _btnCancel, _btnSave);
            ControlUtil.EnableButtons(_btnNew);
            ControlUtil.DisableComboBoxes(_cboOrderClient, _cboProductSelect);
            ControlUtil.DisableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        private void SetEditState()
        {
            ControlUtil.DisableButtons(_btnNew, _btnDelete, _btnEdit);
            ControlUtil.EnableButtons(_btnCancel, _btnSave);
            ControlUtil.EnableComboBoxes(_cboOrderClient, _cboProductSelect);
            ControlUtil.EnableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        private void SetItemSelectedState()
        {
            ControlUtil.DisableButtons(_btnSave, _btnCancel);
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            ControlUtil.DisableComboBoxes(_cboOrderClient,_cboProductSelect);
            ControlUtil.DisableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        private void DisablInputForm()
        {
            _grpOrderInfo.Enabled = false;
        }

        private void EnableInputForm()
        {
            _grpOrderInfo.Enabled = true;
            ControlUtil.DisableTextBoxes(_txtTotalCost, _txtOrderNum);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            Products.Add(new Product("prod1", 3.3M, "product 1", false));
            Products.Add(new Product("prod2", 2.3M, "product 2", false));
            Products.Add(new Product("prod2", 1.3M, "product 3", false));

            Clients.Add(new Client { name = "client 1" });
            Clients.Add(new Client { name = "client 2" });
            Clients.Add(new Client { name = "client 3" });
            ResetOrderList();
            ResetClientCombo();
            ResetProductCombo();
            ResetDates();
            SetInitialState();
            _currOrder = null;

           
        }

        private void ResetProductCombo()
        {
            ResetList(Products, _bndProductCbo, _cboProductSelect, "ToString");
        }

        private void ResetClientCombo()
        {
            ResetList(Clients, _bndClientCbo, _cboOrderClient, "name");
            
        }

        private void ResetDates()
        {
            _dpOrderDate.Value = DateTime.Today;
            _dpDeliveryDate.Value = DateTime.Today;
        }

        private void ResetOrderList()
        {
            ResetList(Orders, _bndOrders, _lstOrders, "ToString");
        }

        private void ResetOrderItemList()
        {
            ResetList(_currOrder.OrderItems, _bndOrderItems, _lstOrderProducts, "ToString");
        }

        private void ResetList<T>(List<T> lst, BindingSource bsrc, Control ctrl, string dispMem)
        {
            bsrc.DataSource = lst;

            if (ctrl is ListBox)
            {
                ListBox tempLst = (ListBox)ctrl;
                tempLst.DataSource = bsrc;
                tempLst.DisplayMember = dispMem;
            }
            else if (ctrl is ComboBox)
            {
                ComboBox tempCbo = (ComboBox)ctrl;
                tempCbo.DataSource = bsrc;
                tempCbo.DisplayMember = dispMem;
            }
            
            bsrc.ResetBindings(false);
        }

        private void _btnNew_Click(object sender, EventArgs e)
        {
            SetEditState();
            CreateNewOrder();
            _txtOrderNum.Text = NextOrderNum.ToString();
        }

        private void CreateNewOrder()
        {
            _currOrder = new Order();
            ResetOrderItemList();
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        private void SaveOrder()
        {
            Control errorControl;

            RevertPreviousErrorLabel();

            DateTime orderDate = _dpOrderDate.Value;
            DateTime deliveryDate = _dpDeliveryDate.Value;
            //decimal total = decimal.Parse(_txtTotalCost.Text);

            if (ValidInputs(out errorControl))
            {
                Order currOrder = _editing ?
                    (Order)_lstOrderProducts.SelectedItem : new Order();

                currOrder.OrderDate = orderDate;
                currOrder.DeliveryDate = deliveryDate;
                currOrder.OrderItems = GetOrderItems();

                if (_editing)
                {
                    Orders.Add(currOrder);
                    NextOrderNum++;
                }

                ResetOrderList();
                _lstOrders.SelectedItem = currOrder;

                ResetErrors();
                _editing = false;
            }
            else
            {
                SetRequiredError(errorControl);
            }
        }

        // State of the form has been changed -> change to appropriate state
        // for controls.
        private void SetChangedState()
        {
            ClearFields();

            ////for cases when user is searching and list is not just the
            ////original orders
            //List<Order> currList = (_searching) ? _searchList : _movieList.Movies;

            //prevents possible awkward bug of editing something that doesn't exist
            //-> user clicks edit nothing selected
            if (Orders.Count == 0)
            {
                SetInitialState();
                //_btnNew.Focus();
            }
            else
            {
                _lstOrders.SelectedIndex = 0;
                SetSelectedState();
                PopulateOrder((Order)_lstOrders.SelectedItem);
            }
        }

        private void PopulateOrder(Order order)
        {
            if (order != null)
            {
                _txtOrderNum.Text = order.OrderNumber.ToString();
                _dpDeliveryDate.Value = order.DeliveryDate;
                _dpOrderDate.Value = order.OrderDate;
                _txtTotalCost.Text = order.CalculateTotal().ToString();
                _currOrder = order;
                ResetOrderItemList();
            }
        }

        private void SetSelectedState()
        {
            ControlUtil.DisableButtons(_btnSave, _btnCancel);
            ControlUtil.EnableButtons(_btnNew, _btnDelete, _btnEdit);
        }

        private void ClearFields()
        {
            throw new NotImplementedException();
        }

        private List<OrderItem> GetOrderItems()
        {
            var items = _lstOrderProducts.Items;
            List<OrderItem> tempOI = new List<OrderItem>();

            foreach (Object o in items)
            {
                tempOI.Add((OrderItem)o);
            }

            return tempOI;
        }

        private void SetRequiredError(Control ctrl)
        {
            ctrl.Focus();

            _requiredFieldLbls[ctrl].ForeColor = Color.Red;
            _toolStatErrorLabel.Text = _requiredErrors[ctrl];

            //to revert color back to black later
            _prevErrLabel = _requiredFieldLbls[ctrl];
            _prevErrLabel.ForeColor = Color.Red;
        }

        // Reset color of the previous invalid input label to black
        private void RevertPreviousErrorLabel()
        {
            if (_prevErrLabel != null)
            {
                _prevErrLabel.ForeColor = Color.Black;
            }
        }

        // Resets the error messages
        private void ResetErrors()
        {
            _toolStatErrorLabel.Text = "";
            _prevErrLabel = null;
        }

        private void SetError(Control c, string errorMsg)
        {
            //error message of some sort
            c.Focus();
            _toolStatErrorLabel.Text = errorMsg;

            //to revert color back to black later
            _prevErrLabel = _requiredFieldLbls[c];
            _prevErrLabel.ForeColor = Color.Red;
        }

        private bool ValidInputs(out Control errCtrl)
        {
            if (_dpDeliveryDate.Value.Date < DateTime.Today)
            {
                errCtrl = _dpDeliveryDate;
                return false;
            }

            if (string.IsNullOrWhiteSpace(_cboOrderClient.Text))
            {
                errCtrl = _cboOrderClient;
                return false;
            }
            
            if (_currOrder.OrderItems.Count == 0)
            {
                errCtrl = _lstOrderProducts;
                return false;
            }

            errCtrl = null;
            return true;
        }

        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void _btnAddProduct_Click(object sender, EventArgs e)
        {
            double qty = (double)_nmbProductQty.Value;
            RevertPreviousErrorLabel();

            if (qty == 0 || qty % .5 != 0)
            {
                SetError(_nmbProductQty, _requiredErrors[_nmbProductQty]);
                return;
            }

            AddNewOrderItem((Product)_cboProductSelect.SelectedItem, qty);
        }

        private void AddNewOrderItem(Product prod, double qty)
        {
            _currOrder.AddProduct(prod, qty);
            ResetOrderItemList();
            UpdateTotalCost();
        }

        private void UpdateTotalCost()
        {
            _txtTotalCost.Text = _currOrder.CalculateTotal().ToString();
        }
    }
}
