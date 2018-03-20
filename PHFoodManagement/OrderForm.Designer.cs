namespace PHFoodManagement
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
            this._grpOrderInfo = new System.Windows.Forms.GroupBox();
            this._btnRemoveProduct = new System.Windows.Forms.Button();
            this._btnAddProduct = new System.Windows.Forms.Button();
            this._btnAddClient = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this._txtClient = new System.Windows.Forms.TextBox();
            this._txtOrderNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblClient = new System.Windows.Forms.Label();
            this._lblOrderNum = new System.Windows.Forms.Label();
            this._grpDates = new System.Windows.Forms.GroupBox();
            this._dpOrderDate = new System.Windows.Forms.DateTimePicker();
            this._lblOrderDate = new System.Windows.Forms.Label();
            this._lblDelDate = new System.Windows.Forms.Label();
            this._dpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this._lblOrder = new System.Windows.Forms.Label();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnNew = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._grpOrderInfo.SuspendLayout();
            this._grpDates.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpOrderInfo
            // 
            this._grpOrderInfo.Controls.Add(this._btnRemoveProduct);
            this._grpOrderInfo.Controls.Add(this._btnAddProduct);
            this._grpOrderInfo.Controls.Add(this._btnAddClient);
            this._grpOrderInfo.Controls.Add(this.textBox2);
            this._grpOrderInfo.Controls.Add(this.listBox2);
            this._grpOrderInfo.Controls.Add(this._txtClient);
            this._grpOrderInfo.Controls.Add(this._txtOrderNum);
            this._grpOrderInfo.Controls.Add(this.label5);
            this._grpOrderInfo.Controls.Add(this.label4);
            this._grpOrderInfo.Controls.Add(this._lblClient);
            this._grpOrderInfo.Controls.Add(this._lblOrderNum);
            this._grpOrderInfo.Controls.Add(this._grpDates);
            this._grpOrderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpOrderInfo.Location = new System.Drawing.Point(18, 14);
            this._grpOrderInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this._grpOrderInfo.Name = "_grpOrderInfo";
            this._grpOrderInfo.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this._grpOrderInfo.Size = new System.Drawing.Size(488, 448);
            this._grpOrderInfo.TabIndex = 0;
            this._grpOrderInfo.TabStop = false;
            this._grpOrderInfo.Text = "Order Information";
            // 
            // _btnRemoveProduct
            // 
            this._btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnRemoveProduct.Location = new System.Drawing.Point(424, 341);
            this._btnRemoveProduct.Name = "_btnRemoveProduct";
            this._btnRemoveProduct.Size = new System.Drawing.Size(36, 31);
            this._btnRemoveProduct.TabIndex = 14;
            this._btnRemoveProduct.Text = "X";
            this._btnRemoveProduct.UseVisualStyleBackColor = true;
            // 
            // _btnAddProduct
            // 
            this._btnAddProduct.Location = new System.Drawing.Point(424, 290);
            this._btnAddProduct.Name = "_btnAddProduct";
            this._btnAddProduct.Size = new System.Drawing.Size(36, 31);
            this._btnAddProduct.TabIndex = 13;
            this._btnAddProduct.Text = "+";
            this._btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // _btnAddClient
            // 
            this._btnAddClient.Location = new System.Drawing.Point(424, 194);
            this._btnAddClient.Name = "_btnAddClient";
            this._btnAddClient.Size = new System.Drawing.Size(36, 31);
            this._btnAddClient.TabIndex = 12;
            this._btnAddClient.Text = "+";
            this._btnAddClient.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(224, 405);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(195, 32);
            this.textBox2.TabIndex = 11;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 26;
            this.listBox2.Location = new System.Drawing.Point(24, 265);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(395, 134);
            this.listBox2.TabIndex = 10;
            // 
            // _txtClient
            // 
            this._txtClient.Location = new System.Drawing.Point(122, 193);
            this._txtClient.Name = "_txtClient";
            this._txtClient.Size = new System.Drawing.Size(296, 32);
            this._txtClient.TabIndex = 9;
            // 
            // _txtOrderNum
            // 
            this._txtOrderNum.Location = new System.Drawing.Point(123, 36);
            this._txtOrderNum.Name = "_txtOrderNum";
            this._txtOrderNum.ReadOnly = true;
            this._txtOrderNum.Size = new System.Drawing.Size(133, 32);
            this._txtOrderNum.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Products:";
            // 
            // _lblClient
            // 
            this._lblClient.AutoSize = true;
            this._lblClient.Location = new System.Drawing.Point(43, 196);
            this._lblClient.Name = "_lblClient";
            this._lblClient.Size = new System.Drawing.Size(74, 26);
            this._lblClient.TabIndex = 2;
            this._lblClient.Text = "Client:";
            // 
            // _lblOrderNum
            // 
            this._lblOrderNum.AutoSize = true;
            this._lblOrderNum.Location = new System.Drawing.Point(16, 39);
            this._lblOrderNum.Name = "_lblOrderNum";
            this._lblOrderNum.Size = new System.Drawing.Size(101, 26);
            this._lblOrderNum.TabIndex = 0;
            this._lblOrderNum.Text = "OrderNo.";
            // 
            // _grpDates
            // 
            this._grpDates.Controls.Add(this._dpOrderDate);
            this._grpDates.Controls.Add(this._lblOrderDate);
            this._grpDates.Controls.Add(this._lblDelDate);
            this._grpDates.Controls.Add(this._dpDeliveryDate);
            this._grpDates.Location = new System.Drawing.Point(19, 73);
            this._grpDates.Name = "_grpDates";
            this._grpDates.Size = new System.Drawing.Size(437, 116);
            this._grpDates.TabIndex = 15;
            this._grpDates.TabStop = false;
            this._grpDates.Text = "Dates";
            // 
            // _dpOrderDate
            // 
            this._dpOrderDate.Checked = false;
            this._dpOrderDate.Location = new System.Drawing.Point(105, 32);
            this._dpOrderDate.Name = "_dpOrderDate";
            this._dpOrderDate.Size = new System.Drawing.Size(296, 32);
            this._dpOrderDate.TabIndex = 6;
            // 
            // _lblOrderDate
            // 
            this._lblOrderDate.AutoSize = true;
            this._lblOrderDate.Location = new System.Drawing.Point(28, 37);
            this._lblOrderDate.Name = "_lblOrderDate";
            this._lblOrderDate.Size = new System.Drawing.Size(73, 26);
            this._lblOrderDate.TabIndex = 1;
            this._lblOrderDate.Text = "Order:";
            // 
            // _lblDelDate
            // 
            this._lblDelDate.AutoSize = true;
            this._lblDelDate.Location = new System.Drawing.Point(4, 79);
            this._lblDelDate.Name = "_lblDelDate";
            this._lblDelDate.Size = new System.Drawing.Size(97, 26);
            this._lblDelDate.TabIndex = 5;
            this._lblDelDate.Text = "Delivery:";
            // 
            // _dpDeliveryDate
            // 
            this._dpDeliveryDate.Location = new System.Drawing.Point(105, 74);
            this._dpDeliveryDate.Name = "_dpDeliveryDate";
            this._dpDeliveryDate.Size = new System.Drawing.Size(296, 32);
            this._dpDeliveryDate.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(525, 42);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(275, 420);
            this.listBox1.TabIndex = 1;
            // 
            // _lblOrder
            // 
            this._lblOrder.AutoSize = true;
            this._lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrder.Location = new System.Drawing.Point(520, 12);
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
            this._btnDelete.TabIndex = 3;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(175, 13);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(125, 36);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            // 
            // _btnNew
            // 
            this._btnNew.Location = new System.Drawing.Point(19, 13);
            this._btnNew.Name = "_btnNew";
            this._btnNew.Size = new System.Drawing.Size(125, 36);
            this._btnNew.TabIndex = 5;
            this._btnNew.Text = "New";
            this._btnNew.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(627, 13);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(125, 36);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnEdit
            // 
            this._btnEdit.Location = new System.Drawing.Point(331, 13);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(125, 36);
            this._btnEdit.TabIndex = 7;
            this._btnEdit.Text = "Edit";
            this._btnEdit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btnCancel);
            this.panel1.Controls.Add(this._btnEdit);
            this.panel1.Controls.Add(this._btnDelete);
            this.panel1.Controls.Add(this._btnNew);
            this.panel1.Controls.Add(this._btnSave);
            this.panel1.Location = new System.Drawing.Point(18, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 62);
            this.panel1.TabIndex = 8;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 542);
            this.Controls.Add(this._lblOrder);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._grpOrderInfo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(834, 598);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Orders";
            this._grpOrderInfo.ResumeLayout(false);
            this._grpOrderInfo.PerformLayout();
            this._grpDates.ResumeLayout(false);
            this._grpDates.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpOrderInfo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label _lblOrder;
        private System.Windows.Forms.DateTimePicker _dpDeliveryDate;
        private System.Windows.Forms.DateTimePicker _dpOrderDate;
        private System.Windows.Forms.Label _lblDelDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblClient;
        private System.Windows.Forms.Label _lblOrderDate;
        private System.Windows.Forms.Label _lblOrderNum;
        private System.Windows.Forms.TextBox _txtOrderNum;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox _txtClient;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnNew;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnRemoveProduct;
        private System.Windows.Forms.Button _btnAddProduct;
        private System.Windows.Forms.Button _btnAddClient;
        private System.Windows.Forms.GroupBox _grpDates;
    }
}