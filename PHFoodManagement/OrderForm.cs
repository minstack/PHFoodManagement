﻿using System;
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
        private bool _comingFromQuickOrder = false;
        private PHFOrderService.PHFOrderRetrievalServiceClient _orderdb =
            new PHFOrderService.PHFOrderRetrievalServiceClient();

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

            InitRequiredDictionary(_requiredControls);
            InitRequiredErrors(_requiredControls);

            Orders = new List<Order>();
        }

        private void InitOrdersFromDB()
        {
            Dictionary<int, Client> clientIdToObject = GetIdToClient();

            string[] tempStringOrders = _orderdb.GetAllOrders().Split('|');

            foreach (string strOrder in tempStringOrders)
            {
                string[] order = strOrder.Split(',');

                Order currOrder = new Order {
                    OrderNumber = int.Parse(order[0]),
                    OrderDate = Convert.ToDateTime(order[1]),
                    DeliveryDate = Convert.ToDateTime(order[2]),
                    Paid = Convert.ToBoolean(order[3]),
                    Client = clientIdToObject[int.Parse(order[4])]
                };

                Orders.Add(currOrder);
                //TEMP UNTIL DICTIONARY VIFGURE OUT
                //currOrder.OrderItems = new List<OrderItem>();
            }


        }

        private Dictionary<int, Client> GetIdToClient()
        {
            Dictionary<int, Client> idtoclient = new Dictionary<int, Client>();

            foreach (Client c in Clients)
            {
                idtoclient.Add(c.id, c);
            }

            return idtoclient;
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

        public void LoadOrders()
        {
            InitOrdersFromDB();
        }

        private void SetInitialState()
        {
            ControlUtil.DisableButtons(_btnEdit, _btnDelete, _btnCancel, _btnSave, _btnAddProduct, _btnRemoveProduct);
            ControlUtil.EnableButtons(_btnNew);
            DisablInputForm();
        }

        private void SetEditState()
        {
            ControlUtil.DisableButtons(_btnNew, _btnDelete, _btnEdit);
            ControlUtil.EnableButtons(_btnCancel, _btnSave, _btnAddProduct, _btnRemoveProduct);
            EnableInputForm();
            ControlUtil.DisableListBoxes(_lstOrders);
        }

        private void SetItemSelectedState()
        {
            ControlUtil.DisableButtons(_btnSave, _btnCancel, _btnAddProduct, _btnRemoveProduct);
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            DisablInputForm();
            ControlUtil.EnableListBoxes(_lstOrders);
            
        }

        private void DisablInputForm()
        {
            _grpOrderInfo.Enabled = false;
            
        }

        private void EnableInputForm()
        {
            _grpOrderInfo.Enabled = true;
            ControlUtil.DisableTextBoxes(_txtTotalCost);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            Products = new List<Product>();
            //Clients = new List<Client>();
            Products.Add(new Product("prod1", 3.3M, "product 1", false));
            Products.Add(new Product("prod2", 2.3M, "product 2", false));
            Products.Add(new Product("prod2", 1.3M, "product 3", false));

            // Clients.Add(new Client { name = "client 1", id=1, additionalDiscount = 0,
            //address = "32 fakestreet ave", phoneNumber = "44444444", type = ClientType.Restaurant, zone = Zone.East});
            //Clients.Add(new Client { name = "client 2" });
            //Clients.Add(new Client { name = "client 3" });
            InitOrdersFromDB();

            ResetOrderList();
            ResetClientCombo();
            ResetProductCombo();
            ResetDates();
            if (_comingFromQuickOrder)
            {
                _currOrder = (Order)_lstOrders.SelectedItem;
                SetEditState();
                _comingFromQuickOrder = false;
            }
            else
            {
                SetInitialState();
                _currOrder = null;
            }

            
        }

        private void ResetProductCombo()
        {
            ControlUtil.ResetList(Products, _bndProductCbo, _cboProductSelect, "ToString");
        }

        private void ResetClientCombo()
        {
            ControlUtil.ResetList(Clients, _bndClientCbo, _cboOrderClient, "name");
            
        }

        private void ResetDates()
        {
            _dpOrderDate.Value = DateTime.Today;
            _dpDeliveryDate.Value = DateTime.Today;
        }

        private void ResetOrderList()
        {
            ControlUtil.ResetList(Orders, _bndOrders, _lstOrders, "ToString");
        }

        private void ResetOrderItemList()
        {
            ControlUtil.ResetList(_currOrder.OrderItems, _bndOrderItems, _lstOrderProducts, "ToString");
        }

        //private void ResetList<T>(List<T> lst, BindingSource bsrc, Control ctrl, string dispMem)
        //{
        //    bsrc.DataSource = lst;

        //    if (ctrl is ListBox)
        //    {
        //        ListBox tempLst = (ListBox)ctrl;
        //        tempLst.DataSource = bsrc;
        //        tempLst.DisplayMember = dispMem;
        //    }
        //    else if (ctrl is ComboBox)
        //    {
        //        ComboBox tempCbo = (ComboBox)ctrl;
        //        tempCbo.DataSource = bsrc;
        //        tempCbo.DisplayMember = dispMem;
        //    }
            
        //    bsrc.ResetBindings(false);
        //}

        private void _btnNew_Click(object sender, EventArgs e)
        {
            SetEditState();
            CreateNewOrder();
            //_txtOrderNum.Text = NextOrderNum.ToString();
            _editing = false;
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
            Client client = (Client)_cboOrderClient.SelectedItem;
            //decimal total = decimal.Parse(_txtTotalCost.Text);

            if (ValidInputs(out errorControl))
            {
                Order currOrder = _editing ?
                    (Order)_lstOrders.SelectedItem : new Order();

                currOrder.OrderDate = orderDate;
                currOrder.DeliveryDate = deliveryDate;
                currOrder.OrderItems = GetOrderItems();
                currOrder.Client = client;
               // currOrder.OrderNumber = int.Parse(_txtOrderNum.Text);

                if (!_editing)
                {
                    int orderNum = AddToDB(currOrder);

                    if (orderNum > 0)
                    {
                        currOrder.OrderNumber = orderNum;
                        AddOrderItemsToDB(currOrder);

                        Orders.Add(currOrder);  
                    }
                }
                else
                {
                    UpdateDB(currOrder);
                }

                ResetOrderList();
                _lstOrders.SelectedItem = currOrder;

                SetItemSelectedState();
                ResetErrors();
                _editing = false;
            }
            else
            {
                SetRequiredError(errorControl);
            }
        }

        private void UpdateDB(Order currOrder)
        {
            string orderString = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                    currOrder.OrderNumber,
                    currOrder.OrderDate,
                    currOrder.DeliveryDate,
                    currOrder.CalculateTotal(),
                    currOrder.Paid,
                    currOrder.Client.id
                );
            _orderdb.UpdateOrder(orderString);

            //update orderitems
            _orderdb.DeleteOrderItems(currOrder.OrderNumber);
            AddOrderItemsToDB(currOrder);

            
        }

        private int AddToDB(Order currOrder)
        {
            return _orderdb.AddNewOrder(
                        currOrder.OrderDate.Date.ToString(),
                        currOrder.DeliveryDate.Date.ToString(),
                        currOrder.CalculateTotal(),
                        currOrder.Paid,
                        currOrder.Client.id
                    );

            
        }

        private void AddOrderItemsToDB(Order currOrder)
        {
            foreach (OrderItem oi in currOrder.OrderItems)
            {
                //_orderdb.AddOrderItem(currOrder.OrderNumber, )
                _orderdb.AddOrderItem(currOrder.OrderNumber, 1, oi.Quantity);
            }
        }

        internal void InitQOOrder(Order quickOrder)
        {
            ResetOrderList();
            _lstOrders.SelectedItem = quickOrder;
            //_lstOrders.SelectedIndex = Orders.Count - 1;
            PopulateOrder(quickOrder);
            _comingFromQuickOrder = true;
            _editing = true;
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
                SetItemSelectedState();
                PopulateOrder((Order)_lstOrders.SelectedItem);
            }
        }

        private void PopulateOrder(Order order)
        {
            if (order != null)
            {
                //_txtOrderNum.Text = order.OrderNumber.ToString();
                _dpDeliveryDate.Value = order.DeliveryDate;
                _dpOrderDate.Value = order.OrderDate;
                _txtTotalCost.Text = order.CalculateTotal().ToString();
                _currOrder = order;
                _cboOrderClient.SelectedItem = order.Client;
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
            ControlUtil.ClearTextBoxes(_txtTotalCost);
            ControlUtil.ClearComboBoxes(_cboOrderClient, _cboProductSelect);
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
            ClearOrderItems();
        }

        private bool IsValidProduct(Product selectedItem)
        {
            foreach(Product p in Products)
            {
                
            }
            return true;
        }

        private void ClearOrderItems()
        {
            ControlUtil.ClearComboBoxes(_cboProductSelect);
            ControlUtil.ClearNumUpDown(_nmbProductQty);
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

        private void _lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order selected = (Order)_lstOrders.SelectedItem;

            if (selected != null)
            {
                PopulateOrder(selected);
                SetItemSelectedState();
            }
            else
            {
                SetInitialState();
            }
            
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            SetEditState();
            _editing = true;
        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            Order selected = (Order)_lstOrders.SelectedItem;

            if (selected != null)
            {
                Orders.Remove(selected);
                ResetOrderList();
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            
            ResetOrderItemList();
            _currOrder = null;
            SetChangedState();
            RevertPreviousErrorLabel();
            ResetErrors();
        }

        private void _btnRemoveProduct_Click(object sender, EventArgs e)
        {
            OrderItem selected = (OrderItem)_lstOrderProducts.SelectedItem;

            if (selected != null)
            {
                _currOrder.OrderItems.Remove(selected);
                ResetOrderItemList();
            }
        }
    }
}
