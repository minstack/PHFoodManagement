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
        private ErrorProvider _errProvider = new ErrorProvider();
        private Dictionary<int, List<OrderItem>> _orderIdtoOrderItems =
            new Dictionary<int, List<OrderItem>>();

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

        //dictionary prodID to product used when
        //initializing order items..linear
        private Dictionary<int, Product> GetProductIdtoProduct()
        {
            Dictionary<int, Product> idToProd = 
                new Dictionary<int, Product>();

            foreach (Product p in Products)
            {
                idToProd.Add(p.Id, p);
            }

            return idToProd;
        }

        //retrieves orderitems from db
        //returns dictionary of orderid to list of the order items
        //O(n) compared to O(n^2) if retrieving orderitems as
        //orders are created from db retrieval
        private Dictionary<int, List<OrderItem>> GetOrderIdToItems()
        {
            string fullRecord = _orderdb.GetAllOrderItems(-1);
            Dictionary<int, Product> idToProd = GetProductIdtoProduct();
            Dictionary<int, List<OrderItem>> oIdtoItems = 
                new Dictionary<int, List<OrderItem>>();

            if (string.IsNullOrWhiteSpace(fullRecord))
            {
                return oIdtoItems;
            }

            string[] idToItemsString = fullRecord.Split('|');
            
            // ["orderId,prodId,qty",...]
            foreach (string record in idToItemsString)
            {
                string[] fields = record.Split(',');
                int orderId = int.Parse(fields[0]);
                int prodId = int.Parse(fields[1]);
                double qty = double.Parse(fields[2]);

                List<OrderItem> items;

                //check if orderitems for order id exists
                if (oIdtoItems.ContainsKey(orderId))
                {
                    items = oIdtoItems[orderId];
                }
                else
                {
                    items = new List<OrderItem>();
                    oIdtoItems.Add(orderId, items);
                }

                //probably don't need this later if the db
                //is properly implemented with constraints
                //throwing errors
                if (idToProd.ContainsKey(prodId))
                {
                    items.Add(new OrderItem
                    {
                        Product = idToProd[prodId],
                        Quantity = qty
                    });
                }
                
            }
            return oIdtoItems;
        }

        //initializes order list with orders from db
        //complete order objects with client and products/orderitems
        private void InitOrdersFromDB()
        {
            Orders.Clear();
            Dictionary<int, Client> clientIdToObject = GetIdToClient();
            Dictionary<int, List<OrderItem>> oIdtoItems = GetOrderIdToItems();

            string tempString = _orderdb.GetAllOrders();

            if (tempString.Length > 0)
            {
                string[] tempStringOrders = tempString.Split('|');

                foreach (string strOrder in tempStringOrders)
                {
                    string[] order = strOrder.Split(',');

                    Order currOrder = new Order
                    {
                        OrderNumber = int.Parse(order[0]),
                        OrderDate = Convert.ToDateTime(order[1]),
                        DeliveryDate = Convert.ToDateTime(order[2]),
                        Paid = Convert.ToBoolean(order[3])
                    };

                    if (oIdtoItems.ContainsKey(currOrder.OrderNumber))
                    {
                        currOrder.OrderItems = oIdtoItems[currOrder.OrderNumber];
                    }

                    //this is temporary until client-order relationship
                    //constraint can be enforced or client delete needs
                    //to be refactored later
                    int tempClientId = int.Parse(order[4]);
                    if (clientIdToObject.ContainsKey(tempClientId))
                    {
                        currOrder.Client = clientIdToObject[tempClientId];
                        Orders.Add(currOrder);
                    }
                }
            }
            


        }

        //client id to client object dictionary
        //used for initializing orders from db with foreign keys (ints)
        //without this initializing order is O(n^2) compared to O(n)
        private Dictionary<int, Client> GetIdToClient()
        {
            Dictionary<int, Client> idtoclient = new Dictionary<int, Client>();

            foreach (Client c in Clients)
            {
                idtoclient.Add(c.id, c);
            }

            return idtoclient;
        }

        //controls to error messages
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

        //required fields dictionary to the corresponding labels
        //for feedback with red forecolor change
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

        //public method to be called from main form
        public void LoadOrders()
        {
            InitOrdersFromDB();
        }

        //no items in list
        private void SetInitialState()
        {
            ControlUtil.DisableButtons(_btnEdit, _btnDelete, _btnCancel, _btnSave, _btnAddProduct, _btnRemoveProduct);
            ControlUtil.EnableButtons(_btnNew);
            DisablInputForm();
        }

        //adding new order or editing selected
        private void SetEditState()
        {
            ControlUtil.DisableButtons(_btnNew, _btnDelete, _btnEdit);
            ControlUtil.EnableButtons(_btnCancel, _btnSave, _btnAddProduct, _btnRemoveProduct);
            EnableInputForm();
            ControlUtil.DisableListBoxes(_lstOrders);
        }

        //selected mode -> edit, delete, new btns enabled
        //disabling other btns prevents unnecessary bugs
        private void SetItemSelectedState()
        {
            ControlUtil.DisableButtons(_btnSave, _btnCancel, _btnAddProduct, _btnRemoveProduct);
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            DisablInputForm();
            ControlUtil.EnableListBoxes(_lstOrders);
        }

        //disables input form group
        private void DisablInputForm()
        {
            _grpOrderInfo.Enabled = false;
        }

        //enables the order input form group
        //'disables' total cost textbox since
        //that isn't for the user to input
        private void EnableInputForm()
        {
            _grpOrderInfo.Enabled = true;
            ControlUtil.DisableTextBoxes(_txtTotalCost);
        }

        //order form loads with initialization of orders
        //from db, resets all lists/comboboxes with updatesvalues
        //the properties clients and products must be set
        //before calling this form to show
        private void OrderForm_Load(object sender, EventArgs e)
        {
            InitOrdersFromDB();

            ResetOrderList();
            ResetClientCombo();
            ResetProductCombo();
            ResetDates();

            if (_comingFromQuickOrder)
            {
                SetEditState();
                _comingFromQuickOrder = false;
                _editing = false; //triggers new order
                _cboOrderClient.SelectedItem = _currOrder.Client;
            }
            else
            {
                SetInitialState();
                _currOrder = null;
            }
        }

        //resets product combobox
        private void ResetProductCombo()
        {
            ControlUtil.ResetList(Products, _bndProductCbo, _cboProductSelect, "ToString");
        }

        //resets the client combobox
        private void ResetClientCombo()
        {
            ControlUtil.ResetList(Clients, _bndClientCbo, _cboOrderClient, "name");
        }

        //default dates --> today
        private void ResetDates()
        {
            _dpOrderDate.Value = DateTime.Today;
            _dpDeliveryDate.Value = DateTime.Today;
        }

        //resets order list
        private void ResetOrderList()
        {
            ControlUtil.ResetList(Orders, _bndOrders, _lstOrders, "ToString");
        }

        //resets the orderitem list
        private void ResetOrderItemList()
        {
            ControlUtil.ResetList(_currOrder.OrderItems, _bndOrderItems, _lstOrderProducts, "ToString");
        }

        //new order btn event.  Clear fields, create new order, enable controls
        //flag editing as false
        private void _btnNew_Click(object sender, EventArgs e)
        {
            SetEditState();
            CreateNewOrder();
            ClearFields();
            //_txtOrderNum.Text = NextOrderNum.ToString();
            _editing = false;
        }

        //sets current order to new order and resets order item list
        private void CreateNewOrder()
        {
            _currOrder = new Order();
            _dpDeliveryDate.Value = DateTime.Today;
            _dpOrderDate.Value = DateTime.Today;
            ResetOrderItemList();
        }

        //save click event
        private void _btnSave_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        //saves the order whether new or editing
        //has error checking for required fields/lists (orderitems)
        private void SaveOrder()
        {
            Control errorControl;

            RevertPreviousErrorLabel();
            _errProvider.Clear();

            DateTime orderDate = _dpOrderDate.Value;
            DateTime deliveryDate = _dpDeliveryDate.Value;
            Client client = (Client)_cboOrderClient.SelectedItem;
            bool paid = _chkPaid.Checked;
            //decimal total = decimal.Parse(_txtTotalCost.Text);

            if (ValidInputs(out errorControl))
            {
                //this way (and one if block later)
                //prevents weird nested if's from separating
                //edit and new
                Order currOrder = _editing ?
                    (Order)_lstOrders.SelectedItem : new Order();

                currOrder.OrderDate = orderDate;
                currOrder.DeliveryDate = deliveryDate;
                currOrder.OrderItems = GetOrderItems();
                currOrder.Client = client;
                currOrder.Paid = paid;

                if (!_editing)
                {
                    //adding to db first and the db method
                    //returns the orderId to be updated
                    //right away on client
                    int orderNum = AddToDB(currOrder);

                    if (orderNum > 0)
                    {
                        currOrder.OrderNumber = orderNum;
                        AddOrderItemsToDB(currOrder); //db add

                        Orders.Add(currOrder);  
                    }
                }
                else
                {
                    UpdateDB(currOrder); //db update (editing)
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

        //prep order to string values to be sent to
        //order web service -> update db
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
            //this is the 'simplest' way of updating order
            //items without the need to figure out which was
            //updated or not
            _orderdb.DeleteOrderItems(currOrder.OrderNumber);
            AddOrderItemsToDB(currOrder);

            
        }

        //adds the given order to the db
        //through the web service
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

        //adds the orderitems of given order to the db 
        private void AddOrderItemsToDB(Order currOrder)
        {
            foreach (OrderItem oi in currOrder.OrderItems)
            {
                _orderdb.AddOrderItem(
                    currOrder.OrderNumber, oi.Product.Id, oi.Quantity);
            }
        }
        
        //initializes the form to the given quick order
        //coming from the main form.  sets the current order to the
        //given quick order, populates it and flags the corresponding
        //variable to true for further processing when form loads
        internal void InitQOOrder(Order quickOrder)
        {
            ResetOrderList();
            _currOrder = quickOrder;
            PopulateOrder(quickOrder);
            _comingFromQuickOrder = true;
        }

        // State of the form has been changed -> change to appropriate state
        // for controls.
        private void SetChangedState()
        {
            ClearFields();

            //prevents possible awkward bug of editing something that doesn't exist
            //-> user clicks edit nothing selected
            if (Orders.Count == 0)
            {
                SetInitialState();
            }
            else
            {
                _lstOrders.SelectedIndex = 0;
                SetItemSelectedState();
                PopulateOrder((Order)_lstOrders.SelectedItem);
            }
        }

        //populates the order form with the given order
        private void PopulateOrder(Order order)
        {
            if (order != null)
            {
                _dpDeliveryDate.Value = order.DeliveryDate;
                _dpOrderDate.Value = order.OrderDate;
                _txtTotalCost.Text = order.CalculateTotal().ToString();
                _currOrder = order;
                _cboOrderClient.SelectedItem = order.Client;
                _chkPaid.Checked = _currOrder.Paid;
                ResetOrderItemList();
            }
        }
        
        //clears all fields
        private void ClearFields()
        {
            ControlUtil.ClearTextBoxes(_txtTotalCost);
            ControlUtil.ClearComboBoxes(_cboOrderClient, _cboProductSelect);
        }

        //retreives orderitems currently in the listbox
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

        //sets error message based on given control
        private void SetRequiredError(Control ctrl)
        {
            ctrl.Focus();

            string errorMsg = _requiredErrors[ctrl];

            _requiredFieldLbls[ctrl].ForeColor = Color.Red;
            _toolStatErrorLabel.Text = errorMsg;

            //to revert color back to black later
            _prevErrLabel = _requiredFieldLbls[ctrl];
            _prevErrLabel.ForeColor = Color.Red;

            _errProvider.SetError(ctrl, errorMsg);
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

        // checks for valid inputs for the form
        private bool ValidInputs(out Control errCtrl)
        {
            //only new orders should do this check
            if (!_editing && _dpDeliveryDate.Value.Date < DateTime.Today)
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

        //'closing' by hiding for future opens
        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        //add product event
        private void _btnAddProduct_Click(object sender, EventArgs e)
        {
            double qty = (double)_nmbProductQty.Value;
            RevertPreviousErrorLabel();
            
            if (qty == 0 )
            {
                SetError(_nmbProductQty, _requiredErrors[_nmbProductQty]);
                return;
            }

            //only allows .5 denominations without the need for errors
            qty -= (qty % .5);

            AddNewOrderItem((Product)_cboProductSelect.SelectedItem, qty);
            _nmbProductQty.Value = _nmbProductQty.Minimum;
        }

        //adds given product and to current order
        //resets totalcost and orderitemlist
        private void AddNewOrderItem(Product prod, double qty)
        {
            _currOrder.AddProduct(prod, qty);
            ResetOrderItemList();
            UpdateTotalCost();
        }

        //recalculates total.  called when item added/deleted
        private void UpdateTotalCost()
        {
            _txtTotalCost.Text = _currOrder.CalculateTotal().ToString();
        }

        //listbox event selected item change
        //populates order if selected.  If no order selected
        //(empty list) then set to initial state -> all input controls
        //disabled, only listbox and new button enabled
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

        //edit click event -> enable input form controls
        //flag editing true
        private void _btnEdit_Click(object sender, EventArgs e)
        {
            SetEditState();
            _editing = true;
        }

        //deletes selected order as long as it is null
        private void _btnDelete_Click(object sender, EventArgs e)
        {
            Order selected = (Order)_lstOrders.SelectedItem;
            
            if (DeleteConfirmed())
            {
                if (selected != null)
                {
                    DeleteOrderFromDB(selected);
                    Orders.Remove(selected);
                    ResetOrderList();
                }
            }
            
        }

        //returns true or false if the delete action was confirmed 'yes'
        private bool DeleteConfirmed()
        {
            return DialogResult.Yes == MessageBox.Show("Are you sure you would like to delete selected item?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        //deletes the given order from the database
        private void DeleteOrderFromDB(Order selected)
        {
            foreach (OrderItem oi in selected.OrderItems)
            {
                _orderdb.DeleteOrderItems(selected.OrderNumber);
            }

            _orderdb.DeleteOrder(selected.OrderNumber);
        }

        //cancels any edits or new orders
        private void _btnCancel_Click(object sender, EventArgs e)
        {
            
            ResetOrderItemList();
            _currOrder = null;
            SetChangedState();
            RevertPreviousErrorLabel();
            ResetErrors();
        }

        //delete order item
        private void _btnRemoveProduct_Click(object sender, EventArgs e)
        {
            OrderItem selected = (OrderItem)_lstOrderProducts.SelectedItem;
            if (selected != null)
            {
                if (DeleteConfirmed())
                {                
                    _currOrder.RemoveOrderItem(selected);
                    ResetOrderItemList();
                    UpdateTotalCost();
                }
            }
            
        }
    }
}
