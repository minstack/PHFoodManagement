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
        private BindingSource _bndClients = new BindingSource();
        private ClientDB db = new ClientDB();
        bool newClient = false;
        private Client _tempClient;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // load the client list
            LoadList();

            // load the combo with the values of enum class
            LoadZone();
            LoadClientType();

            // Load the fields with the content of the selected item on the list
            RefreshFields();
            DisableFields();
            ControlUtil.DisableButtons(this._btnSave, this._btnDelete, this._btnCancel);
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            bool insertUpdate;

            if (newClient)
            {
                sql =
                   "INSERT INTO client (clientName, phone, address, zoneid, clientTypeId) VALUES (" + 
                   "'" + this._txtName.Text + "'" +
                   ", '" + this._txtPhone.Text + "'" +
                   ", '" + this._txtAddress.Text + "'" +
                   ", " + this._cmbZone.SelectedValue + 
                   ", " + this._cmbType.SelectedValue + ")";
            }
            else
            {
                sql =
                    "UPDATE client SET clientName = '" + this._txtName.Text +
                    "', phone = '" + this._txtPhone.Text +
                    "', address = '" + this._txtAddress.Text +
                    "', zoneId = " + this._cmbZone.SelectedValue +
                    ", clientTypeId = " + this._cmbType.SelectedValue +
                    " WHERE clientId = " + this.listClient[this._lstClient.SelectedIndex].id;

                // remove the selected client, and add it again with correct values
                listClient.RemoveAt(_lstClient.SelectedIndex);
            }

            insertUpdate = db.InsertUpdateClients(sql);
            newClient = false;

            _tempClient = new Client();
            this._tempClient.name = this._txtName.Text;
            this._tempClient.phoneNumber = this._txtPhone.Text;
            this._tempClient.address = this._txtAddress.Text;
            this._tempClient.zone = (Zone)this._cmbZone.SelectedValue;
            this._tempClient.type = (ClientType)this._cmbType.SelectedValue;

            listClient.Add(_tempClient);
            
            if (insertUpdate)
            {
                ControlUtil.EnableButtons(this._btnNew, this._btnEdit, this._btnDelete);
                ControlUtil.DisableButtons(this._btnSave, this._btnCancel);
                DisableFields();
                ControlUtil.ResetList(this.listClient, this._bndClients, this._lstClient, "name");
                RefreshFields();
            }
        }

        private void _btnNew_Click(object sender, EventArgs e)
        {
            newClient = true;

            ControlUtil.DisableButtons(this._btnNew, this._btnEdit, this._btnDelete);
            ControlUtil.EnableButtons(this._btnSave);
            ClearFields();
            EnableFields();

            // the field Name receive the focus
            this._txtName.Focus();
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            ControlUtil.EnableButtons(this._btnSave, this._btnDelete, this._btnCancel);
            ControlUtil.DisableButtons(this._btnNew, this._btnEdit);
            EnableFields();

            this._txtName.Focus();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            ControlUtil.EnableButtons(this._btnNew, this._btnEdit);
            ControlUtil.DisableButtons(this._btnSave);
            if (this.listClient.Count > 0)
            {
                this._lstClient.SelectedIndex = 0;
            }
            RefreshFields();
        }

        private void _lstClient_Click(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void RefreshFields()
        {
            if (this.listClient.Count > 0) { 
                this._txtName.Text = this.listClient[this._lstClient.SelectedIndex].name;
                this._txtPhone.Text = this.listClient[this._lstClient.SelectedIndex].phoneNumber;
                this._txtAddress.Text = this.listClient[this._lstClient.SelectedIndex].address;
                this._cmbZone.Text = this.listClient[this._lstClient.SelectedIndex].zone.ToString();
                this._cmbType.Text = this.listClient[this._lstClient.SelectedIndex].type.ToString();
            }
            else
            {
                ClearFields();
            }
        }

        private void DisableFields()
        {
            ControlUtil.DisableTextBoxes(this._txtName, this._txtPhone, this._txtAddress);
            ControlUtil.DisableComboBoxes(this._cmbZone, this._cmbType);
        }

        private void EnableFields()
        {
            ControlUtil.EnableTextBoxes(this._txtName, this._txtPhone, this._txtAddress);
            ControlUtil.EnableComboBoxes(this._cmbZone, this._cmbType);
        }

        private void ClearFields()
        {
            ControlUtil.ClearTextBoxes(this._txtName, this._txtPhone, this._txtAddress);
            ControlUtil.ClearComboBoxes(this._cmbZone, this._cmbType);
        }

        private void LoadList()
        {
            ControlUtil.ResetList(this.listClient, this._bndClients, this._lstClient, "name");
            if (this.listClient.Count > 0)
            {
                this._lstClient.SelectedIndex = 0;
            }
        }

        private void LoadZone()
        {
            Dictionary<Zone, int> dict = new Dictionary<Zone, int>();
            int n = 1;

            foreach (Zone zon in Enum.GetValues(typeof(Zone)))
            {
                dict.Add(zon, n);
                n = n + 1;
            }

            this._cmbZone.DisplayMember = "Key";
            this._cmbZone.ValueMember = "Value";
            this._cmbZone.DataSource = dict.ToList();
        }

        private void LoadClientType()
        {
            Dictionary<ClientType, int> dict = new Dictionary<ClientType, int>();
            int n = 1;

            foreach (ClientType type in Enum.GetValues(typeof(ClientType)))
            {
                dict.Add(type, n);
                n = n + 1;
            }

            this._cmbType.DisplayMember = "Key";
            this._cmbType.ValueMember = "Value";
            this._cmbType.DataSource = dict.ToList();
        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            listClient.RemoveAt(_lstClient.SelectedIndex);
            ControlUtil.ResetList(this.listClient, this._bndClients, this._lstClient, "name");
            LoadList();
            RefreshFields();
            DisableFields();
            ControlUtil.DisableButtons(this._btnSave, this._btnDelete, this._btnCancel);
        }
    }
}
