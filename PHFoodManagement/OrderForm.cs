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
        private Dictionary<Control, Label> _requiredFieldLbls = new Dictionary<Control, Label>();
        private Dictionary<Control, string> _requiredErrors = new Dictionary<Control, string>();
        
        public OrderForm()
        {
            InitializeComponent();
            SetInitialState();

            Control[] requiredControls = {
                 _dpDeliveryDate,
                 _cboOrderClient,
                 _lstOrderProducts                 
            };

            //temporary until DB implementation
            NextOrderNum = 1;

            InitRequiredDictionary(requiredControls);
            InitRequiredErrors(requiredControls);
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
            _lstOrders.DataSource = _bndOrders;
            _bndOrders.DataSource = Orders;

            _bndOrders.ResetBindings(false);

        }

        private void _btnNew_Click(object sender, EventArgs e)
        {
            SetEditState();
        }
    }
}
