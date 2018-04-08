namespace PHFoodManagement
{
    partial class ProductForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cbOrganic = new System.Windows.Forms.CheckBox();
            this._lblDescription = new System.Windows.Forms.Label();
            this._lblPrice = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtPrice = new System.Windows.Forms.TextBox();
            this._txtName = new System.Windows.Forms.TextBox();
            this._btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnEdit = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._lvProducts = new System.Windows.Forms.ListView();
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._cbOrganic);
            this.groupBox1.Controls.Add(this._lblDescription);
            this.groupBox1.Controls.Add(this._lblPrice);
            this.groupBox1.Controls.Add(this._lblName);
            this.groupBox1.Controls.Add(this._txtDescription);
            this.groupBox1.Controls.Add(this._txtPrice);
            this.groupBox1.Controls.Add(this._txtName);
            this.groupBox1.Location = new System.Drawing.Point(21, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 321);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Information";
            // 
            // _cbOrganic
            // 
            this._cbOrganic.AutoSize = true;
            this._cbOrganic.Location = new System.Drawing.Point(132, 262);
            this._cbOrganic.Name = "_cbOrganic";
            this._cbOrganic.Size = new System.Drawing.Size(99, 28);
            this._cbOrganic.TabIndex = 7;
            this._cbOrganic.Text = "Organic";
            this._cbOrganic.UseVisualStyleBackColor = true;
            // 
            // _lblDescription
            // 
            this._lblDescription.AutoSize = true;
            this._lblDescription.Location = new System.Drawing.Point(18, 149);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(109, 24);
            this._lblDescription.TabIndex = 5;
            this._lblDescription.Text = "Description:";
            // 
            // _lblPrice
            // 
            this._lblPrice.AutoSize = true;
            this._lblPrice.Location = new System.Drawing.Point(68, 104);
            this._lblPrice.Name = "_lblPrice";
            this._lblPrice.Size = new System.Drawing.Size(58, 24);
            this._lblPrice.TabIndex = 4;
            this._lblPrice.Text = "Price:";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(60, 56);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(66, 24);
            this._lblName.TabIndex = 3;
            this._lblName.Text = "Name:";
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(132, 146);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(314, 105);
            this._txtDescription.TabIndex = 2;
            // 
            // _txtPrice
            // 
            this._txtPrice.Location = new System.Drawing.Point(132, 100);
            this._txtPrice.Name = "_txtPrice";
            this._txtPrice.Size = new System.Drawing.Size(184, 28);
            this._txtPrice.TabIndex = 1;
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(132, 56);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(184, 28);
            this._txtName.TabIndex = 0;
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
            // panel1
            // 
            this.panel1.Controls.Add(this._btnCancel);
            this.panel1.Controls.Add(this._btnEdit);
            this.panel1.Controls.Add(this._btnDelete);
            this.panel1.Controls.Add(this._btnNew);
            this.panel1.Controls.Add(this._btnSave);
            this.panel1.Location = new System.Drawing.Point(21, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 62);
            this.panel1.TabIndex = 9;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(627, 13);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(125, 36);
            this._btnCancel.TabIndex = 6;
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
            this._btnDelete.TabIndex = 3;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(175, 13);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(125, 36);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _lvProducts
            // 
            this._lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductName,
            this.Price});
            this._lvProducts.GridLines = true;
            this._lvProducts.Location = new System.Drawing.Point(503, 22);
            this._lvProducts.Name = "_lvProducts";
            this._lvProducts.Size = new System.Drawing.Size(300, 331);
            this._lvProducts.TabIndex = 10;
            this._lvProducts.UseCompatibleStateImageBehavior = false;
            this._lvProducts.View = System.Windows.Forms.View.Details;
            this._lvProducts.SelectedIndexChanged += new System.EventHandler(this._lvProducts_SelectedIndexChanged);
            // 
            // ProductName
            // 
            this.ProductName.Text = "Name";
            this.ProductName.Width = 183;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 88;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 440);
            this.Controls.Add(this._lvProducts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Manage Products";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.TextBox _txtPrice;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label _lblDescription;
        private System.Windows.Forms.Label _lblPrice;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.CheckBox _cbOrganic;
        private System.Windows.Forms.Button _btnNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnEdit;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.ListView _lvProducts;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader Price;
    }
}