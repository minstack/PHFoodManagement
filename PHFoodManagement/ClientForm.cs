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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // load the combo with the values of enum class
            this._cmbZone.DataSource = Enum.GetValues(typeof(Zone));
            
            this._cmbType.DataSource = Enum.GetValues(typeof(ClientType));
        }
    }
}
