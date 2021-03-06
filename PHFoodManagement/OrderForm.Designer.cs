﻿namespace PHFoodManagement
{
    partial class OrderForm
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
            this.components = new System.ComponentModel.Container();
            this._grpOrderInfo = new System.Windows.Forms.GroupBox();
            this._chkPaid = new System.Windows.Forms.CheckBox();
            this._cboOrderClient = new System.Windows.Forms.ComboBox();
            this._lblClient = new System.Windows.Forms.Label();
            this._lblProductQty = new System.Windows.Forms.Label();
            this._lblBoxes = new System.Windows.Forms.Label();
            this._nmbProductQty = new System.Windows.Forms.NumericUpDown();
            this._cboProductSelect = new System.Windows.Forms.ComboBox();
            this._btnRemoveProduct = new System.Windows.Forms.Button();
            this._btnAddProduct = new System.Windows.Forms.Button();
            this._txtTotalCost = new System.Windows.Forms.TextBox();
            this._lstOrderProducts = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this._lblOrderProducts = new System.Windows.Forms.Label();
            this._grpDates = new System.Windows.Forms.GroupBox();
            this._dpOrderDate = new System.Windows.Forms.DateTimePicker();
            this._lblOrderDate = new System.Windows.Forms.Label();
            this._lblDelDate = new System.Windows.Forms.Label();
            this._dpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this._lstOrders = new System.Windows.Forms.ListBox();
            this._lblOrder = new System.Windows.Forms.Label();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnNew = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._stsOrderStatus = new System.Windows.Forms.StatusStrip();
            this._toolStatErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this._txtOrderSearch = new System.Windows.Forms.TextBox();
            this._toolStripOrderSearch = new System.Windows.Forms.ToolStripStatusLabel();
            this._tooltipSearch = new System.Windows.Forms.ToolTip(this.components);
            this._grpOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nmbProductQty)).BeginInit();
            this._grpDates.SuspendLayout();
            this.panel1.SuspendLayout();
            this._stsOrderStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpOrderInfo
            // 
            this._grpOrderInfo.Controls.Add(this._chkPaid);
            this._grpOrderInfo.Controls.Add(this._cboOrderClient);
            this._grpOrderInfo.Controls.Add(this._lblClient);
            this._grpOrderInfo.Controls.Add(this._lblProductQty);
            this._grpOrderInfo.Controls.Add(this._lblBoxes);
            this._grpOrderInfo.Controls.Add(this._nmbProductQty);
            this._grpOrderInfo.Controls.Add(this._cboProductSelect);
            this._grpOrderInfo.Controls.Add(this._btnRemoveProduct);
            this._grpOrderInfo.Controls.Add(this._btnAddProduct);
            this._grpOrderInfo.Controls.Add(this._txtTotalCost);
            this._grpOrderInfo.Controls.Add(this._lstOrderProducts);
            this._grpOrderInfo.Controls.Add(this.label5);
            this._grpOrderInfo.Controls.Add(this._lblOrderProducts);
            this._grpOrderInfo.Controls.Add(this._grpDates);
            this._grpOrderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpOrderInfo.Location = new System.Drawing.Point(18, 14);
            this._grpOrderInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this._grpOrderInfo.Name = "_grpOrderInfo";
            this._grpOrderInfo.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this._grpOrderInfo.Size = new System.Drawing.Size(456, 446);
            this._grpOrderInfo.TabIndex = 0;
            this._grpOrderInfo.TabStop = false;
            this._grpOrderInfo.Text = "Order Information";
            // 
            // _chkPaid
            // 
            this._chkPaid.AutoSize = true;
            this._chkPaid.Location = new System.Drawing.Point(353, 32);
            this._chkPaid.Name = "_chkPaid";
            this._chkPaid.Size = new System.Drawing.Size(82, 30);
            this._chkPaid.TabIndex = 2;
            this._chkPaid.Text = "Paid";
            this._chkPaid.UseVisualStyleBackColor = true;
            // 
            // _cboOrderClient
            // 
            this._cboOrderClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboOrderClient.FormattingEnabled = true;
            this._cboOrderClient.Location = new System.Drawing.Point(126, 26);
            this._cboOrderClient.Name = "_cboOrderClient";
            this._cboOrderClient.Size = new System.Drawing.Size(210, 34);
            this._cboOrderClient.TabIndex = 1;
            // 
            // _lblClient
            // 
            this._lblClient.AutoSize = true;
            this._lblClient.Location = new System.Drawing.Point(46, 29);
            this._lblClient.Name = "_lblClient";
            this._lblClient.Size = new System.Drawing.Size(74, 26);
            this._lblClient.TabIndex = 21;
            this._lblClient.Text = "Client:";
            // 
            // _lblProductQty
            // 
            this._lblProductQty.AutoSize = true;
            this._lblProductQty.Location = new System.Drawing.Point(65, 230);
            this._lblProductQty.Name = "_lblProductQty";
            this._lblProductQty.Size = new System.Drawing.Size(52, 26);
            this._lblProductQty.TabIndex = 20;
            this._lblProductQty.Text = "Qty:";
            // 
            // _lblBoxes
            // 
            this._lblBoxes.AutoSize = true;
            this._lblBoxes.Location = new System.Drawing.Point(249, 230);
            this._lblBoxes.Name = "_lblBoxes";
            this._lblBoxes.Size = new System.Drawing.Size(70, 26);
            this._lblBoxes.TabIndex = 19;
            this._lblBoxes.Text = "boxes";
            // 
            // _nmbProductQty
            // 
            this._nmbProductQty.DecimalPlaces = 1;
            this._nmbProductQty.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._nmbProductQty.Location = new System.Drawing.Point(123, 228);
            this._nmbProductQty.Name = "_nmbProductQty";
            this._nmbProductQty.Size = new System.Drawing.Size(120, 32);
            this._nmbProductQty.TabIndex = 6;
            // 
            // _cboProductSelect
            // 
            this._cboProductSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboProductSelect.FormattingEnabled = true;
            this._cboProductSelect.Location = new System.Drawing.Point(123, 188);
            this._cboProductSelect.Name = "_cboProductSelect";
            this._cboProductSelect.Size = new System.Drawing.Size(296, 34);
            this._cboProductSelect.TabIndex = 5;
            // 
            // _btnRemoveProduct
            // 
            this._btnRemoveProduct.BackgroundImage = global::PHFoodManagement.Properties.Resources.trash;
            this._btnRemoveProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnRemoveProduct.Location = new System.Drawing.Point(84, 365);
            this._btnRemoveProduct.Name = "_btnRemoveProduct";
            this._btnRemoveProduct.Size = new System.Drawing.Size(33, 31);
            this._btnRemoveProduct.TabIndex = 9;
            this._btnRemoveProduct.UseVisualStyleBackColor = true;
            this._btnRemoveProduct.Click += new System.EventHandler(this._btnRemoveProduct_Click);
            // 
            // _btnAddProduct
            // 
            this._btnAddProduct.Location = new System.Drawing.Point(325, 228);
            this._btnAddProduct.Name = "_btnAddProduct";
            this._btnAddProduct.Size = new System.Drawing.Size(36, 31);
            this._btnAddProduct.TabIndex = 7;
            this._btnAddProduct.Text = "+";
            this._btnAddProduct.UseVisualStyleBackColor = true;
            this._btnAddProduct.Click += new System.EventHandler(this._btnAddProduct_Click);
            // 
            // _txtTotalCost
            // 
            this._txtTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTotalCost.Location = new System.Drawing.Point(227, 411);
            this._txtTotalCost.Name = "_txtTotalCost";
            this._txtTotalCost.ReadOnly = true;
            this._txtTotalCost.Size = new System.Drawing.Size(195, 32);
            this._txtTotalCost.TabIndex = 11;
            this._txtTotalCost.TabStop = false;
            // 
            // _lstOrderProducts
            // 
            this._lstOrderProducts.FormattingEnabled = true;
            this._lstOrderProducts.ItemHeight = 26;
            this._lstOrderProducts.Location = new System.Drawing.Point(123, 262);
            this._lstOrderProducts.Name = "_lstOrderProducts";
            this._lstOrderProducts.Size = new System.Drawing.Size(296, 134);
            this._lstOrderProducts.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total:";
            // 
            // _lblOrderProducts
            // 
            this._lblOrderProducts.AutoSize = true;
            this._lblOrderProducts.Location = new System.Drawing.Point(16, 191);
            this._lblOrderProducts.Name = "_lblOrderProducts";
            this._lblOrderProducts.Size = new System.Drawing.Size(104, 26);
            this._lblOrderProducts.TabIndex = 3;
            this._lblOrderProducts.Text = "Products:";
            // 
            // _grpDates
            // 
            this._grpDates.Controls.Add(this._dpOrderDate);
            this._grpDates.Controls.Add(this._lblOrderDate);
            this._grpDates.Controls.Add(this._lblDelDate);
            this._grpDates.Controls.Add(this._dpDeliveryDate);
            this._grpDates.Location = new System.Drawing.Point(19, 66);
            this._grpDates.Name = "_grpDates";
            this._grpDates.Size = new System.Drawing.Size(416, 116);
            this._grpDates.TabIndex = 2;
            this._grpDates.TabStop = false;
            this._grpDates.Text = "Dates";
            // 
            // _dpOrderDate
            // 
            this._dpOrderDate.Checked = false;
            this._dpOrderDate.Location = new System.Drawing.Point(105, 26);
            this._dpOrderDate.Name = "_dpOrderDate";
            this._dpOrderDate.Size = new System.Drawing.Size(295, 32);
            this._dpOrderDate.TabIndex = 3;
            // 
            // _lblOrderDate
            // 
            this._lblOrderDate.AutoSize = true;
            this._lblOrderDate.Location = new System.Drawing.Point(25, 31);
            this._lblOrderDate.Name = "_lblOrderDate";
            this._lblOrderDate.Size = new System.Drawing.Size(73, 26);
            this._lblOrderDate.TabIndex = 1;
            this._lblOrderDate.Text = "Order:";
            // 
            // _lblDelDate
            // 
            this._lblDelDate.AutoSize = true;
            this._lblDelDate.Location = new System.Drawing.Point(1, 73);
            this._lblDelDate.Name = "_lblDelDate";
            this._lblDelDate.Size = new System.Drawing.Size(97, 26);
            this._lblDelDate.TabIndex = 5;
            this._lblDelDate.Text = "Delivery:";
            // 
            // _dpDeliveryDate
            // 
            this._dpDeliveryDate.Location = new System.Drawing.Point(105, 72);
            this._dpDeliveryDate.Name = "_dpDeliveryDate";
            this._dpDeliveryDate.Size = new System.Drawing.Size(296, 32);
            this._dpDeliveryDate.TabIndex = 4;
            // 
            // _lstOrders
            // 
            this._lstOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lstOrders.FormattingEnabled = true;
            this._lstOrders.ItemHeight = 26;
            this._lstOrders.Location = new System.Drawing.Point(507, 40);
            this._lstOrders.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this._lstOrders.Name = "_lstOrders";
            this._lstOrders.Size = new System.Drawing.Size(275, 368);
            this._lstOrders.TabIndex = 0;
            this._lstOrders.SelectedIndexChanged += new System.EventHandler(this._lstOrders_SelectedIndexChanged);
            // 
            // _lblOrder
            // 
            this._lblOrder.AutoSize = true;
            this._lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrder.Location = new System.Drawing.Point(507, 10);
            this._lblOrder.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._lblOrder.Name = "_lblOrder";
            this._lblOrder.Size = new System.Drawing.Size(78, 26);
            this._lblOrder.TabIndex = 2;
            this._lblOrder.Text = "Orders";
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(482, 13);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(125, 36);
            this._btnDelete.TabIndex = 13;
            this._btnDelete.Text = "&Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(175, 13);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(125, 36);
            this._btnSave.TabIndex = 11;
            this._btnSave.Text = "&Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnNew
            // 
            this._btnNew.Location = new System.Drawing.Point(19, 13);
            this._btnNew.Name = "_btnNew";
            this._btnNew.Size = new System.Drawing.Size(125, 36);
            this._btnNew.TabIndex = 10;
            this._btnNew.Text = "&New";
            this._btnNew.UseVisualStyleBackColor = true;
            this._btnNew.Click += new System.EventHandler(this._btnNew_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(627, 13);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(125, 36);
            this._btnCancel.TabIndex = 14;
            this._btnCancel.Text = "&Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnEdit
            // 
            this._btnEdit.Location = new System.Drawing.Point(331, 13);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(125, 36);
            this._btnEdit.TabIndex = 12;
            this._btnEdit.Text = "&Edit";
            this._btnEdit.UseVisualStyleBackColor = true;
            this._btnEdit.Click += new System.EventHandler(this._btnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btnCancel);
            this.panel1.Controls.Add(this._btnEdit);
            this.panel1.Controls.Add(this._btnDelete);
            this.panel1.Controls.Add(this._btnNew);
            this.panel1.Controls.Add(this._btnSave);
            this.panel1.Location = new System.Drawing.Point(18, 467);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 62);
            this.panel1.TabIndex = 8;
            // 
            // _stsOrderStatus
            // 
            this._stsOrderStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._stsOrderStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._stsOrderStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStatErrorLabel,
            this._toolStripOrderSearch});
            this._stsOrderStatus.Location = new System.Drawing.Point(0, 529);
            this._stsOrderStatus.Name = "_stsOrderStatus";
            this._stsOrderStatus.Size = new System.Drawing.Size(812, 35);
            this._stsOrderStatus.TabIndex = 9;
            this._stsOrderStatus.Text = "statusStrip1";
            // 
            // _toolStatErrorLabel
            // 
            this._toolStatErrorLabel.ForeColor = System.Drawing.Color.Red;
            this._toolStatErrorLabel.Name = "_toolStatErrorLabel";
            this._toolStatErrorLabel.Size = new System.Drawing.Size(0, 30);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Image = global::PHFoodManagement.Properties.Resources.search_small;
            this.pictureBox2.Location = new System.Drawing.Point(749, 426);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // _txtOrderSearch
            // 
            this._txtOrderSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._txtOrderSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtOrderSearch.Location = new System.Drawing.Point(507, 422);
            this._txtOrderSearch.Name = "_txtOrderSearch";
            this._txtOrderSearch.Size = new System.Drawing.Size(275, 35);
            this._txtOrderSearch.TabIndex = 10;
            this._tooltipSearch.SetToolTip(this._txtOrderSearch, "Type Order# or Client name to filter list.");
            this._txtOrderSearch.TextChanged += new System.EventHandler(this._txtOrderSearch_TextChanged);
            this._txtOrderSearch.MouseEnter += new System.EventHandler(this._txtOrderSearch_MouseEnter);
            this._txtOrderSearch.MouseLeave += new System.EventHandler(this._txtOrderSearch_MouseLeave);
            // 
            // _toolStripOrderSearch
            // 
            this._toolStripOrderSearch.Name = "_toolStripOrderSearch";
            this._toolStripOrderSearch.Size = new System.Drawing.Size(215, 30);
            this._toolStripOrderSearch.Text = "toolStripStatusLabel1";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 564);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._txtOrderSearch);
            this.Controls.Add(this._stsOrderStatus);
            this.Controls.Add(this._lblOrder);
            this.Controls.Add(this._lstOrders);
            this.Controls.Add(this._grpOrderInfo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(834, 650);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this._grpOrderInfo.ResumeLayout(false);
            this._grpOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nmbProductQty)).EndInit();
            this._grpDates.ResumeLayout(false);
            this._grpDates.PerformLayout();
            this.panel1.ResumeLayout(false);
            this._stsOrderStatus.ResumeLayout(false);
            this._stsOrderStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpOrderInfo;
        private System.Windows.Forms.ListBox _lstOrders;
        private System.Windows.Forms.Label _lblOrder;
        private System.Windows.Forms.DateTimePicker _dpDeliveryDate;
        private System.Windows.Forms.DateTimePicker _dpOrderDate;
        private System.Windows.Forms.Label _lblDelDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lblOrderProducts;
        private System.Windows.Forms.Label _lblOrderDate;
        private System.Windows.Forms.TextBox _txtTotalCost;
        private System.Windows.Forms.ListBox _lstOrderProducts;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnNew;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnRemoveProduct;
        private System.Windows.Forms.Button _btnAddProduct;
        private System.Windows.Forms.GroupBox _grpDates;
        private System.Windows.Forms.StatusStrip _stsOrderStatus;
        private System.Windows.Forms.ToolStripStatusLabel _toolStatErrorLabel;
        private System.Windows.Forms.NumericUpDown _nmbProductQty;
        private System.Windows.Forms.ComboBox _cboProductSelect;
        private System.Windows.Forms.ComboBox _cboOrderClient;
        private System.Windows.Forms.Label _lblClient;
        private System.Windows.Forms.Label _lblProductQty;
        private System.Windows.Forms.Label _lblBoxes;
        private System.Windows.Forms.CheckBox _chkPaid;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox _txtOrderSearch;
        private System.Windows.Forms.ToolStripStatusLabel _toolStripOrderSearch;
        private System.Windows.Forms.ToolTip _tooltipSearch;
    }
}