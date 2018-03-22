namespace PHFoodManagement
{
    partial class PHFoodOrderMgmtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHFoodOrderMgmtForm));
            this._grpQuickOrder = new System.Windows.Forms.GroupBox();
            this._txtQOProdQty = new System.Windows.Forms.TextBox();
            this._txtProdSearch = new System.Windows.Forms.TextBox();
            this._txtClientSearch = new System.Windows.Forms.TextBox();
            this._lblProductList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._lstProducts = new System.Windows.Forms.ListBox();
            this._lstClients = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._grpQuickOrderDetails = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this._lstQOProducts = new System.Windows.Forms.ListBox();
            this._txtQOClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._grpRecentOrders = new System.Windows.Forms.GroupBox();
            this._lstRecentOrders = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this._btnAddProdQuick = new System.Windows.Forms.Button();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._grpQuickOrder.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this._grpQuickOrderDetails.SuspendLayout();
            this._grpRecentOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpQuickOrder
            // 
            this._grpQuickOrder.Controls.Add(this._txtQOProdQty);
            this._grpQuickOrder.Controls.Add(this._txtProdSearch);
            this._grpQuickOrder.Controls.Add(this._txtClientSearch);
            this._grpQuickOrder.Controls.Add(this._lblProductList);
            this._grpQuickOrder.Controls.Add(this.label1);
            this._grpQuickOrder.Controls.Add(this._lstProducts);
            this._grpQuickOrder.Controls.Add(this._lstClients);
            this._grpQuickOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpQuickOrder.Location = new System.Drawing.Point(21, 55);
            this._grpQuickOrder.Name = "_grpQuickOrder";
            this._grpQuickOrder.Size = new System.Drawing.Size(655, 607);
            this._grpQuickOrder.TabIndex = 0;
            this._grpQuickOrder.TabStop = false;
            this._grpQuickOrder.Text = "Quick Order";
            // 
            // _txtQOProdQty
            // 
            this._txtQOProdQty.Location = new System.Drawing.Point(520, 549);
            this._txtQOProdQty.Name = "_txtQOProdQty";
            this._txtQOProdQty.Size = new System.Drawing.Size(100, 35);
            this._txtQOProdQty.TabIndex = 6;
            this._txtQOProdQty.Enter += new System.EventHandler(this._txtQOProdQty_Enter);
            this._txtQOProdQty.Leave += new System.EventHandler(this._txtQOProdQty_Leave);
            // 
            // _txtProdSearch
            // 
            this._txtProdSearch.Location = new System.Drawing.Point(345, 549);
            this._txtProdSearch.Name = "_txtProdSearch";
            this._txtProdSearch.Size = new System.Drawing.Size(170, 35);
            this._txtProdSearch.TabIndex = 5;
            this._txtProdSearch.Enter += new System.EventHandler(this._txtProdSearch_Enter);
            this._txtProdSearch.Leave += new System.EventHandler(this._txtProdSearch_Leave);
            // 
            // _txtClientSearch
            // 
            this._txtClientSearch.Location = new System.Drawing.Point(34, 549);
            this._txtClientSearch.Name = "_txtClientSearch";
            this._txtClientSearch.Size = new System.Drawing.Size(275, 35);
            this._txtClientSearch.TabIndex = 4;
            this._txtClientSearch.Enter += new System.EventHandler(this._txtClientSearch_Enter);
            this._txtClientSearch.Leave += new System.EventHandler(this._txtClientSearch_Leave);
            // 
            // _lblProductList
            // 
            this._lblProductList.AutoSize = true;
            this._lblProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblProductList.Location = new System.Drawing.Point(341, 61);
            this._lblProductList.Name = "_lblProductList";
            this._lblProductList.Size = new System.Drawing.Size(108, 29);
            this._lblProductList.TabIndex = 3;
            this._lblProductList.Text = "Products";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clients";
            // 
            // _lstProducts
            // 
            this._lstProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lstProducts.FormattingEnabled = true;
            this._lstProducts.ItemHeight = 29;
            this._lstProducts.Location = new System.Drawing.Point(345, 92);
            this._lstProducts.Name = "_lstProducts";
            this._lstProducts.Size = new System.Drawing.Size(275, 439);
            this._lstProducts.TabIndex = 1;
            // 
            // _lstClients
            // 
            this._lstClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._lstClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lstClients.FormattingEnabled = true;
            this._lstClients.ItemHeight = 29;
            this._lstClients.Location = new System.Drawing.Point(34, 92);
            this._lstClients.Name = "_lstClients";
            this._lstClients.Size = new System.Drawing.Size(275, 439);
            this._lstClients.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordersToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.productsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.editToolStripMenuItem.Text = "&Manage";
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.ordersToolStripMenuItem.Text = "&Orders";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.clientsToolStripMenuItem.Text = "&Clients";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.productsToolStripMenuItem.Text = "&Products";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 30);
            this.toolStripMenuItem1.Text = "&View Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(175, 30);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // _grpQuickOrderDetails
            // 
            this._grpQuickOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpQuickOrderDetails.Controls.Add(this.button1);
            this._grpQuickOrderDetails.Controls.Add(this._lstQOProducts);
            this._grpQuickOrderDetails.Controls.Add(this._txtQOClient);
            this._grpQuickOrderDetails.Controls.Add(this.label3);
            this._grpQuickOrderDetails.Controls.Add(this.label2);
            this._grpQuickOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpQuickOrderDetails.Location = new System.Drawing.Point(827, 55);
            this._grpQuickOrderDetails.Name = "_grpQuickOrderDetails";
            this._grpQuickOrderDetails.Size = new System.Drawing.Size(288, 341);
            this._grpQuickOrderDetails.TabIndex = 4;
            this._grpQuickOrderDetails.TabStop = false;
            this._grpQuickOrderDetails.Text = "Quick Order Details";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Open Order";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _lstQOProducts
            // 
            this._lstQOProducts.FormattingEnabled = true;
            this._lstQOProducts.ItemHeight = 29;
            this._lstQOProducts.Location = new System.Drawing.Point(11, 107);
            this._lstQOProducts.Name = "_lstQOProducts";
            this._lstQOProducts.Size = new System.Drawing.Size(270, 178);
            this._lstQOProducts.TabIndex = 7;
            // 
            // _txtQOClient
            // 
            this._txtQOClient.Location = new System.Drawing.Point(107, 43);
            this._txtQOClient.Name = "_txtQOClient";
            this._txtQOClient.ReadOnly = true;
            this._txtQOClient.Size = new System.Drawing.Size(174, 35);
            this._txtQOClient.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Products:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client:";
            // 
            // _grpRecentOrders
            // 
            this._grpRecentOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpRecentOrders.Controls.Add(this._lstRecentOrders);
            this._grpRecentOrders.Controls.Add(this.button2);
            this._grpRecentOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpRecentOrders.Location = new System.Drawing.Point(827, 402);
            this._grpRecentOrders.Name = "_grpRecentOrders";
            this._grpRecentOrders.Size = new System.Drawing.Size(288, 260);
            this._grpRecentOrders.TabIndex = 5;
            this._grpRecentOrders.TabStop = false;
            this._grpRecentOrders.Text = "Recent Orders";
            // 
            // _lstRecentOrders
            // 
            this._lstRecentOrders.FormattingEnabled = true;
            this._lstRecentOrders.ItemHeight = 29;
            this._lstRecentOrders.Location = new System.Drawing.Point(11, 34);
            this._lstRecentOrders.Name = "_lstRecentOrders";
            this._lstRecentOrders.Size = new System.Drawing.Size(270, 178);
            this._lstRecentOrders.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(58, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 42);
            this.button2.TabIndex = 9;
            this.button2.Text = "Open Order";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // _btnAddProdQuick
            // 
            this._btnAddProdQuick.Location = new System.Drawing.Point(695, 227);
            this._btnAddProdQuick.Name = "_btnAddProdQuick";
            this._btnAddProdQuick.Size = new System.Drawing.Size(114, 42);
            this._btnAddProdQuick.TabIndex = 6;
            this._btnAddProdQuick.Text = "Add >";
            this._btnAddProdQuick.UseVisualStyleBackColor = true;
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.closeToolStripMenuItem.Text = "&Close";
            // 
            // PHFoodOrderMgmtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 674);
            this.Controls.Add(this._btnAddProdQuick);
            this.Controls.Add(this._grpRecentOrders);
            this.Controls.Add(this._grpQuickOrderDetails);
            this.Controls.Add(this._grpQuickOrder);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PHFoodOrderMgmtForm";
            this.Text = "PH Food Order Management";
            this.Load += new System.EventHandler(this.PHFoodOrderMgmtForm_Load);
            this._grpQuickOrder.ResumeLayout(false);
            this._grpQuickOrder.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._grpQuickOrderDetails.ResumeLayout(false);
            this._grpQuickOrderDetails.PerformLayout();
            this._grpRecentOrders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpQuickOrder;
        private System.Windows.Forms.ListBox _lstProducts;
        private System.Windows.Forms.ListBox _lstClients;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox _grpQuickOrderDetails;
        private System.Windows.Forms.GroupBox _grpRecentOrders;
        private System.Windows.Forms.Label _lblProductList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox _lstQOProducts;
        private System.Windows.Forms.TextBox _txtQOClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox _lstRecentOrders;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.TextBox _txtQOProdQty;
        private System.Windows.Forms.TextBox _txtProdSearch;
        private System.Windows.Forms.TextBox _txtClientSearch;
        private System.Windows.Forms.Button _btnAddProdQuick;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

