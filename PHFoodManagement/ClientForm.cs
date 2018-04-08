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
    public partial class ClientForm : Form 
    {
        public List<Client> listClient { get; set; }

        //private List<Client> listClient = new List<Client>();
        private Client tempClient; 

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

        private void _btnSave_Click(object sender, EventArgs e)
        {
            tempClient = new Client();

            this.tempClient.name = this._txtName.Text;
            this.tempClient.phoneNumber = this._txtPhone.Text;
            this.tempClient.address = this._txtAddress.Text;
            this.tempClient.zone = (Zone)this._cmbZone.SelectedItem;
            this.tempClient.type = (ClientType)this._cmbType.SelectedItem;

            listClient.Add(tempClient);
        }
    }
}
