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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHFoodOrderMgmtForm));
            this._grpQuickOrder = new System.Windows.Forms.GroupBox();
            this._pnlClients = new System.Windows.Forms.Panel();
            this._lblClients = new System.Windows.Forms.Label();
            this._lstClients = new System.Windows.Forms.ListBox();
            this._txtClientSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._txtQOProdQty = new System.Windows.Forms.TextBox();
            this._txtProdSearch = new System.Windows.Forms.TextBox();
            this._lblProductList = new System.Windows.Forms.Label();
            this._lstProducts = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._grpQuickOrderDetails = new System.Windows.Forms.GroupBox();
            this._txtQOTotal = new System.Windows.Forms.TextBox();
            this._lblTotal = new System.Windows.Forms.Label();
            this._btnQOFinalize = new System.Windows.Forms.Button();
            this._lstQOProducts = new System.Windows.Forms.ListBox();
            this._txtQOClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._btnAddProdQuick = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._stsLoadingMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this._grpQuickOrder.SuspendLayout();
            this._pnlClients.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this._grpQuickOrderDetails.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpQuickOrder
            // 
            this._grpQuickOrder.Controls.Add(this._pnlClients);
            this._grpQuickOrder.Controls.Add(this.label4);
            this._grpQuickOrder.Controls.Add(this._txtQOProdQty);
            this._grpQuickOrder.Controls.Add(this._txtProdSearch);
            this._grpQuickOrder.Controls.Add(this._lblProductList);
            this._grpQuickOrder.Controls.Add(this._lstProducts);
            this._grpQuickOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpQuickOrder.Location = new System.Drawing.Point(21, 55);
            this._grpQuickOrder.Name = "_grpQuickOrder";
            this._grpQuickOrder.Size = new System.Drawing.Size(719, 607);
            this._grpQuickOrder.TabIndex = 0;
            this._grpQuickOrder.TabStop = false;
            this._grpQuickOrder.Text = "Quick Order";
            // 
            // _pnlClients
            // 
            this._pnlClients.Controls.Add(this._lblClients);
            this._pnlClients.Controls.Add(this._lstClients);
            this._pnlClients.Controls.Add(this._txtClientSearch);
            this._pnlClients.Location = new System.Drawing.Point(25, 34);
            this._pnlClients.Name = "_pnlClients";
            this._pnlClients.Size = new System.Drawing.Size(323, 552);
            this._pnlClients.TabIndex = 8;
            // 
            // _lblClients
            // 
            this._lblClients.AutoSize = true;
            this._lblClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblClients.Location = new System.Drawing.Point(-2, -5);
            this._lblClients.Name = "_lblClients";
            this._lblClients.Size = new System.Drawing.Size(87, 29);
            this._lblClients.TabIndex = 9;
            this._lblClients.Text = "Clients";
            // 
            // _lstClients
            // 
            this._lstClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lstClients.FormattingEnabled = true;
            this._lstClients.ItemHeight = 29;
            this._lstClients.Location = new System.Drawing.Point(3, 27);
            this._lstClients.Name = "_lstClients";
            this._lstClients.Size = new System.Drawing.Size(317, 468);
            this._lstClients.TabIndex = 6;
            // 
            // _txtClientSearch
            // 
            this._txtClientSearch.Location = new System.Drawing.Point(3, 501);
            this._txtClientSearch.Name = "_txtClientSearch";
            this._txtClientSearch.Size = new System.Drawing.Size(317, 35);
            this._txtClientSearch.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(537, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Qty";
            // 
            // _txtQOProdQty
            // 
            this._txtQOProdQty.Location = new System.Drawing.Point(591, 24);
            this._txtQOProdQty.Multiline = true;
            this._txtQOProdQty.Name = "_txtQOProdQty";
            this._txtQOProdQty.Size = new System.Drawing.Size(100, 32);
            this._txtQOProdQty.TabIndex = 4;
            // 
            // _txtProdSearch
            // 
            this._txtProdSearch.Location = new System.Drawing.Point(375, 535);
            this._txtProdSearch.Name = "_txtProdSearch";
            this._txtProdSearch.Size = new System.Drawing.Size(316, 35);
            this._txtProdSearch.TabIndex = 3;
            this._txtProdSearch.Enter += new System.EventHandler(this._txtProdSearch_Enter);
            this._txtProdSearch.Leave += new System.EventHandler(this._txtProdSearch_Leave);
            // 
            // _lblProductList
            // 
            this._lblProductList.AutoSize = true;
            this._lblProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblProductList.Location = new System.Drawing.Point(370, 30);
            this._lblProductList.Name = "_lblProductList";
            this._lblProductList.Size = new System.Drawing.Size(108, 29);
            this._lblProductList.TabIndex = 3;
            this._lblProductList.Text = "Products";
            // 
            // _lstProducts
            // 
            this._lstProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lstProducts.FormattingEnabled = true;
            this._lstProducts.ItemHeight = 29;
            this._lstProducts.Location = new System.Drawing.Point(374, 61);
            this._lstProducts.Name = "_lstProducts";
            this._lstProducts.Size = new System.Drawing.Size(317, 468);
            this._lstProducts.TabIndex = 2;
            this._lstProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this._lstProducts_KeyDown);
            this._lstProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this._lstProducts_KeyUp);
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
            this.menuStrip1.Size = new System.Drawing.Size(1190, 33);
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
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.closeToolStripMenuItem.Text = "&Close";
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
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.productsToolStripMenuItem.Text = "&Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
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
            this._grpQuickOrderDetails.Controls.Add(this._txtQOTotal);
            this._grpQuickOrderDetails.Controls.Add(this._lblTotal);
            this._grpQuickOrderDetails.Controls.Add(this._btnQOFinalize);
            this._grpQuickOrderDetails.Controls.Add(this._lstQOProducts);
            this._grpQuickOrderDetails.Controls.Add(this._txtQOClient);
            this._grpQuickOrderDetails.Controls.Add(this.label3);
            this._grpQuickOrderDetails.Controls.Add(this.label2);
            this._grpQuickOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpQuickOrderDetails.Location = new System.Drawing.Point(843, 55);
            this._grpQuickOrderDetails.Name = "_grpQuickOrderDetails";
            this._grpQuickOrderDetails.Size = new System.Drawing.Size(330, 607);
            this._grpQuickOrderDetails.TabIndex = 4;
            this._grpQuickOrderDetails.TabStop = false;
            this._grpQuickOrderDetails.Text = "Quick Order Details";
            // 
            // _txtQOTotal
            // 
            this._txtQOTotal.Location = new System.Drawing.Point(194, 480);
            this._txtQOTotal.Name = "_txtQOTotal";
            this._txtQOTotal.ReadOnly = true;
            this._txtQOTotal.Size = new System.Drawing.Size(130, 35);
            this._txtQOTotal.TabIndex = 10;
            // 
            // _lblTotal
            // 
            this._lblTotal.AutoSize = true;
            this._lblTotal.Location = new System.Drawing.Point(102, 483);
            this._lblTotal.Name = "_lblTotal";
            this._lblTotal.Size = new System.Drawing.Size(68, 29);
            this._lblTotal.TabIndex = 9;
            this._lblTotal.Text = "Total";
            // 
            // _btnQOFinalize
            // 
            this._btnQOFinalize.Location = new System.Drawing.Point(67, 526);
            this._btnQOFinalize.Name = "_btnQOFinalize";
            this._btnQOFinalize.Size = new System.Drawing.Size(206, 44);
            this._btnQOFinalize.TabIndex = 7;
            this._btnQOFinalize.Text = "Finalize Order";
            this._btnQOFinalize.UseVisualStyleBackColor = true;
            this._btnQOFinalize.Click += new System.EventHandler(this._btnQOFinalize_Click);
            // 
            // _lstQOProducts
            // 
            this._lstQOProducts.FormattingEnabled = true;
            this._lstQOProducts.ItemHeight = 29;
            this._lstQOProducts.Location = new System.Drawing.Point(11, 107);
            this._lstQOProducts.Name = "_lstQOProducts";
            this._lstQOProducts.Size = new System.Drawing.Size(313, 352);
            this._lstQOProducts.TabIndex = 7;
            this._lstQOProducts.TabStop = false;
            // 
            // _txtQOClient
            // 
            this._txtQOClient.Location = new System.Drawing.Point(107, 43);
            this._txtQOClient.Name = "_txtQOClient";
            this._txtQOClient.ReadOnly = true;
            this._txtQOClient.Size = new System.Drawing.Size(217, 35);
            this._txtQOClient.TabIndex = 6;
            this._txtQOClient.TabStop = false;
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
            // _btnAddProdQuick
            // 
            this._btnAddProdQuick.Location = new System.Drawing.Point(746, 235);
            this._btnAddProdQuick.Name = "_btnAddProdQuick";
            this._btnAddProdQuick.Size = new System.Drawing.Size(91, 42);
            this._btnAddProdQuick.TabIndex = 5;
            this._btnAddProdQuick.Text = "Add >";
            this._btnAddProdQuick.UseVisualStyleBackColor = true;
            this._btnAddProdQuick.Click += new System.EventHandler(this._btnAddProdQuick_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._stsLoadingMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1190, 30);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _stsLoadingMessage
            // 
            this._stsLoadingMessage.Name = "_stsLoadingMessage";
            this._stsLoadingMessage.Size = new System.Drawing.Size(179, 25);
            this._stsLoadingMessage.Text = "toolStripStatusLabel1";
            // 
            // PHFoodOrderMgmtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 693);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._btnAddProdQuick);
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
            this._pnlClients.ResumeLayout(false);
            this._pnlClients.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._grpQuickOrderDetails.ResumeLayout(false);
            this._grpQuickOrderDetails.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpQuickOrder;
        private System.Windows.Forms.ListBox _lstProducts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox _grpQuickOrderDetails;
        private System.Windows.Forms.Label _lblProductList;
        private System.Windows.Forms.Button _btnQOFinalize;
        private System.Windows.Forms.ListBox _lstQOProducts;
        private System.Windows.Forms.TextBox _txtQOClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.TextBox _txtQOProdQty;
        private System.Windows.Forms.TextBox _txtProdSearch;
        private System.Windows.Forms.Button _btnAddProdQuick;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtQOTotal;
        private System.Windows.Forms.Label _lblTotal;
        private System.Windows.Forms.Panel _pnlClients;
        private System.Windows.Forms.Label _lblClients;
        private System.Windows.Forms.ListBox _lstClients;
        private System.Windows.Forms.TextBox _txtClientSearch;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _stsLoadingMessage;
    }
}

