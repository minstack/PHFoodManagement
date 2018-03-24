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

        public OrderForm()
        {
            InitializeComponent();
            SetInitialState();
        }

        public void SetInitialState()
        {
            ControlUtil.DisableButtons(_btnEdit, _btnDelete, _btnCancel, _btnSave);
            ControlUtil.EnableButtons(_btnNew);
            ControlUtil.DisableTextBoxes(_txtClient);
            ControlUtil.DisableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        public void SetEditState()
        {
            ControlUtil.DisableButtons(_btnNew, _btnDelete);
            ControlUtil.EnableButtons(_btnEdit, _btnCancel, _btnSave);
            ControlUtil.EnableTextBoxes(_txtClient);
            ControlUtil.EnableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }

        public void SetItemSelectedState()
        {
            ControlUtil.DisableButtons(_btnSave, _btnCancel);
            ControlUtil.EnableButtons(_btnEdit, _btnDelete, _btnNew);
            ControlUtil.DisableTextBoxes(_txtClient);
            ControlUtil.DisableDatePickers(_dpDeliveryDate, _dpOrderDate);
        }
    }
}
