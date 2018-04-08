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
        public int NextOrderNum { get; set; }
        private BindingSource _bndOrders = new BindingSource();
        private BindingSource _bndOrderItems = new BindingSource();
        private Dictionary<Control, Label> _requiredFieldLbls = new Dictionary<Control, Label>();
        private Dictionary<Control, string> _requiredErrors = new Dictionary<Control, string>();
        private Control[] _requiredControls;
        private Order _currNewOrder;
        private Label _prevErrLabel;

        public OrderForm()
        {
            InitializeComponent();
            SetInitialState();

            _requiredControls = new Control[]{
                 _dpDeliveryDate,
                 _cboOrderClient,
                 _lstOrderProducts                 
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
                "At least one product must be selected."
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
                _lblOrderProducts
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
            ControlUtil.DisableComboBoxes(_cboOrderClient);
            ControlUtil.DisableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        private void SetEditState()
        {
            ControlUtil.DisableButtons(_btnNew, _btnDelete, _btnEdit);
            ControlUtil.EnableButtons(_btnCancel, _btnSave);
            ControlUtil.EnableComboBoxes(_cboOrderClient);
            ControlUtil.EnableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        private void SetItemSelectedState()
        {
            ControlUtil.DisableButtons(_btnSave, _btnCancel);
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            ControlUtil.DisableComboBoxes(_cboOrderClient);
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
            _bndOrders.DataSource = Orders;
            _lstOrders.DataSource = _bndOrders;
           

            _bndOrders.ResetBindings(false);

        }

        private void ResetOrderProductsList()
        {
            _bndOrderItems.DataSource = _currNewOrder.OrderItems;
            _lstOrderProducts.DataSource = _bndOrderItems;

            _bndOrderItems.ResetBindings(false);
        }

        private void _btnNew_Click(object sender, EventArgs e)
        {
            SetEditState();
            CreateNewOrder();
            
        }

        private void CreateNewOrder()
        {
            _currNewOrder = new Order();
            ResetOrderProductsList();
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        private void SaveOrder()
        {
            Control errorControl;

            RevertPreviousErrorLabel();

            if (ValidInputs(out errorControl))
            {

            }
            else
            {
                SetRequiredError(errorControl);
            }
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


            errCtrl = _lstOrderProducts;
            return false;

        }
    }
}
