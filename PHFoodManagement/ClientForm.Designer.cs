namespace PHFoodManagement
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnEdit = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnNew = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cmbType = new System.Windows.Forms.ComboBox();
            this._lblType = new System.Windows.Forms.Label();
            this._cmbZone = new System.Windows.Forms.ComboBox();
            this._lblZone = new System.Windows.Forms.Label();
            this._lblAddress = new System.Windows.Forms.Label();
            this._lblPhone = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._txtAddress = new System.Windows.Forms.TextBox();
            this._txtPhone = new System.Windows.Forms.TextBox();
            this._txtName = new System.Windows.Forms.TextBox();
            this._lstClient = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btnCancel);
            this.panel1.Controls.Add(this._btnEdit);
            this.panel1.Controls.Add(this._btnDelete);
            this.panel1.Controls.Add(this._btnNew);
            this.panel1.Controls.Add(this._btnSave);
            this.panel1.Location = new System.Drawing.Point(23, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 62);
            this.panel1.TabIndex = 12;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(627, 13);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(125, 36);
            this._btnCancel.TabIndex = 9;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.Location = new System.Drawing.Point(331, 13);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(125, 36);
            this._btnEdit.TabIndex = 7;
            this._btnEdit.Text = "Edit";
            this._btnEdit.UseVisualStyleBackColor = true;
            this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(482, 13);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(125, 36);
            this._btnDelete.TabIndex = 8;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // _btnNew
            // 
            this._btnNew.Location = new System.Drawing.Point(19, 13);
            this._btnNew.Name = "_btnNew";
            this._btnNew.Size = new System.Drawing.Size(125, 36);
            this._btnNew.TabIndex = 5;
            this._btnNew.Text = "New";
            this._btnNew.UseVisualStyleBackColor = true;
            this._btnNew.Click += new System.EventHandler(this._btnNew_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(175, 13);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(125, 36);
            this._btnSave.TabIndex = 6;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cmbType);
            this.groupBox1.Controls.Add(this._lblType);
            this.groupBox1.Controls.Add(this._cmbZone);
            this.groupBox1.Controls.Add(this._lblZone);
            this.groupBox1.Controls.Add(this._lblAddress);
            this.groupBox1.Controls.Add(this._lblPhone);
            this.groupBox1.Controls.Add(this._lblName);
            this.groupBox1.Controls.Add(this._txtAddress);
            this.groupBox1.Controls.Add(this._txtPhone);
            this.groupBox1.Controls.Add(this._txtName);
            this.groupBox1.Location = new System.Drawing.Point(23, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 310);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Information";
            // 
            // _cmbType
            // 
            this._cmbType.FormattingEnabled = true;
            this._cmbType.Location = new System.Drawing.Point(125, 249);
            this._cmbType.Name = "_cmbType";
            this._cmbType.Size = new System.Drawing.Size(202, 38);
            this._cmbType.TabIndex = 4;
            // 
            // _lblType
            // 
            this._lblType.AutoSize = true;
            this._lblType.Location = new System.Drawing.Point(43, 249);
            this._lblType.Name = "_lblType";
            this._lblType.Size = new System.Drawing.Size(83, 31);
            this._lblType.TabIndex = 9;
            this._lblType.Text = "Type:";
            // 
            // _cmbZone
            // 
            this._cmbZone.FormattingEnabled = true;
            this._cmbZone.Location = new System.Drawing.Point(126, 213);
            this._cmbZone.Name = "_cmbZone";
            this._cmbZone.Size = new System.Drawing.Size(202, 38);
            this._cmbZone.TabIndex = 3;
            // 
            // _lblZone
            // 
            this._lblZone.AutoSize = true;
            this._lblZone.Location = new System.Drawing.Point(45, 213);
            this._lblZone.Name = "_lblZone";
            this._lblZone.Size = new System.Drawing.Size(84, 31);
            this._lblZone.TabIndex = 7;
            this._lblZone.Text = "Zone:";
            // 
            // _lblAddress
            // 
            this._lblAddress.AutoSize = true;
            this._lblAddress.Location = new System.Drawing.Point(7, 106);
            this._lblAddress.Name = "_lblAddress";
            this._lblAddress.Size = new System.Drawing.Size(122, 31);
            this._lblAddress.TabIndex = 5;
            this._lblAddress.Text = "Address:";
            // 
            // _lblPhone
            // 
            this._lblPhone.AutoSize = true;
            this._lblPhone.Location = new System.Drawing.Point(45, 67);
            this._lblPhone.Name = "_lblPhone";
            this._lblPhone.Size = new System.Drawing.Size(100, 31);
            this._lblPhone.TabIndex = 4;
            this._lblPhone.Text = "Phone:";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(54, 34);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(94, 31);
            this._lblName.TabIndex = 3;
            this._lblName.Text = "Name:";
            // 
            // _txtAddress
            // 
            this._txtAddress.Location = new System.Drawing.Point(125, 103);
            this._txtAddress.Multiline = true;
            this._txtAddress.Name = "_txtAddress";
            this._txtAddress.Size = new System.Drawing.Size(314, 105);
            this._txtAddress.TabIndex = 2;
            // 
            // _txtPhone
            // 
            this._txtPhone.Location = new System.Drawing.Point(126, 67);
            this._txtPhone.Name = "_txtPhone";
            this._txtPhone.Size = new System.Drawing.Size(236, 37);
            this._txtPhone.TabIndex = 1;
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(125, 34);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(314, 37);
            this._txtName.TabIndex = 0;
            // 
            // _lstClient
            // 
            this._lstClient.FormattingEnabled = true;
            this._lstClient.ItemHeight = 30;
            this._lstClient.Location = new System.Drawing.Point(496, 39);
            this._lstClient.Name = "_lstClient";
            this._lstClient.Size = new System.Drawing.Size(297, 274);
            this._lstClient.TabIndex = 13;
            this._lstClient.Click += new System.EventHandler(this._lstClient_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(810, 433);
            this.Controls.Add(this._lstClient);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(834, 497);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Clients";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnNew;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _lblAddress;
        private System.Windows.Forms.Label _lblPhone;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _txtAddress;
        private System.Windows.Forms.TextBox _txtPhone;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.ComboBox _cmbType;
        private System.Windows.Forms.Label _lblType;
        private System.Windows.Forms.ComboBox _cmbZone;
        private System.Windows.Forms.Label _lblZone;
        private System.Windows.Forms.ListBox _lstClient;
    }
}