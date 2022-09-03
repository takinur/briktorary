namespace StoreApp
{
    partial class frmIndexAd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndexAd));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnMinmz = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTagHom = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTagPro = new System.Windows.Forms.Panel();
            this.pnlTagOrde = new System.Windows.Forms.Panel();
            this.lblUname = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.pnlSub = new System.Windows.Forms.Panel();
            this.brnMngProduct = new System.Windows.Forms.Button();
            this.btnAllProduct = new System.Windows.Forms.Button();
            this.btnprdct = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.prodcutTableAdapter = new StoreApp.storeAppDBDataSetTableAdapters.ProdcutTableAdapter();
            this.storeAppDBDataSet = new StoreApp.storeAppDBDataSet();
            this.prodcutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storeAppDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodcutBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.DarkGray;
            this.pnlTopBar.Controls.Add(this.btnMinmz);
            this.pnlTopBar.Controls.Add(this.btnExit);
            this.pnlTopBar.Controls.Add(this.btnHelp);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(196, 10);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(741, 33);
            this.pnlTopBar.TabIndex = 13;
            this.pnlTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
            // 
            // btnMinmz
            // 
            this.btnMinmz.FlatAppearance.BorderSize = 0;
            this.btnMinmz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinmz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinmz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMinmz.Image = ((System.Drawing.Image)(resources.GetObject("btnMinmz.Image")));
            this.btnMinmz.Location = new System.Drawing.Point(677, 3);
            this.btnMinmz.Name = "btnMinmz";
            this.btnMinmz.Size = new System.Drawing.Size(32, 28);
            this.btnMinmz.TabIndex = 12;
            this.btnMinmz.UseVisualStyleBackColor = true;
            this.btnMinmz.Click += new System.EventHandler(this.btnMinmz_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(707, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 33);
            this.btnExit.TabIndex = 10;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(641, 2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 28);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(196, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 10);
            this.panel2.TabIndex = 16;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pnlTagHom
            // 
            this.pnlTagHom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlTagHom.Location = new System.Drawing.Point(1, 59);
            this.pnlTagHom.Name = "pnlTagHom";
            this.pnlTagHom.Size = new System.Drawing.Size(10, 54);
            this.pnlTagHom.TabIndex = 4;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pnlMain.Controls.Add(this.pnlTagPro);
            this.pnlMain.Controls.Add(this.pnlTagOrde);
            this.pnlMain.Controls.Add(this.lblUname);
            this.pnlMain.Controls.Add(this.btnOrder);
            this.pnlMain.Controls.Add(this.pnlSub);
            this.pnlMain.Controls.Add(this.btnprdct);
            this.pnlMain.Controls.Add(this.pnlTagHom);
            this.pnlMain.Controls.Add(this.btnLogOut);
            this.pnlMain.Controls.Add(this.button14);
            this.pnlMain.Controls.Add(this.btnHome);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(196, 473);
            this.pnlMain.TabIndex = 15;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            // 
            // pnlTagPro
            // 
            this.pnlTagPro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlTagPro.Location = new System.Drawing.Point(1, 189);
            this.pnlTagPro.Name = "pnlTagPro";
            this.pnlTagPro.Size = new System.Drawing.Size(10, 54);
            this.pnlTagPro.TabIndex = 5;
            // 
            // pnlTagOrde
            // 
            this.pnlTagOrde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.pnlTagOrde.Location = new System.Drawing.Point(1, 121);
            this.pnlTagOrde.Name = "pnlTagOrde";
            this.pnlTagOrde.Size = new System.Drawing.Size(10, 54);
            this.pnlTagOrde.TabIndex = 5;
            // 
            // lblUname
            // 
            this.lblUname.AutoSize = true;
            this.lblUname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUname.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUname.Location = new System.Drawing.Point(59, 396);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(116, 20);
            this.lblUname.TabIndex = 8;
            this.lblUname.Text = "Administrator";
            // 
            // btnOrder
            // 
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(12, 121);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(184, 54);
            this.btnOrder.TabIndex = 7;
            this.btnOrder.Text = "   Orders";
            this.btnOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // pnlSub
            // 
            this.pnlSub.Controls.Add(this.brnMngProduct);
            this.pnlSub.Controls.Add(this.btnAllProduct);
            this.pnlSub.Location = new System.Drawing.Point(12, 245);
            this.pnlSub.MaximumSize = new System.Drawing.Size(184, 116);
            this.pnlSub.MinimumSize = new System.Drawing.Size(184, 0);
            this.pnlSub.Name = "pnlSub";
            this.pnlSub.Size = new System.Drawing.Size(184, 84);
            this.pnlSub.TabIndex = 6;
            // 
            // brnMngProduct
            // 
            this.brnMngProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(51)))), ((int)(((byte)(52)))));
            this.brnMngProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.brnMngProduct.FlatAppearance.BorderSize = 0;
            this.brnMngProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnMngProduct.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnMngProduct.ForeColor = System.Drawing.Color.White;
            this.brnMngProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnMngProduct.Location = new System.Drawing.Point(0, 38);
            this.brnMngProduct.Name = "brnMngProduct";
            this.brnMngProduct.Size = new System.Drawing.Size(184, 37);
            this.brnMngProduct.TabIndex = 7;
            this.brnMngProduct.Text = "Manage Products";
            this.brnMngProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.brnMngProduct.UseVisualStyleBackColor = false;
            this.brnMngProduct.Click += new System.EventHandler(this.brnMngProduct_Click);
            // 
            // btnAllProduct
            // 
            this.btnAllProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(51)))), ((int)(((byte)(52)))));
            this.btnAllProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllProduct.FlatAppearance.BorderSize = 0;
            this.btnAllProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllProduct.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllProduct.ForeColor = System.Drawing.Color.White;
            this.btnAllProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllProduct.Location = new System.Drawing.Point(0, 0);
            this.btnAllProduct.Name = "btnAllProduct";
            this.btnAllProduct.Size = new System.Drawing.Size(184, 38);
            this.btnAllProduct.TabIndex = 5;
            this.btnAllProduct.Text = "Add Products";
            this.btnAllProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllProduct.UseVisualStyleBackColor = false;
            this.btnAllProduct.Click += new System.EventHandler(this.btnAllProduct_Click);
            // 
            // btnprdct
            // 
            this.btnprdct.FlatAppearance.BorderSize = 0;
            this.btnprdct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprdct.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprdct.ForeColor = System.Drawing.Color.White;
            this.btnprdct.Image = ((System.Drawing.Image)(resources.GetObject("btnprdct.Image")));
            this.btnprdct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprdct.Location = new System.Drawing.Point(12, 189);
            this.btnprdct.Name = "btnprdct";
            this.btnprdct.Size = new System.Drawing.Size(184, 54);
            this.btnprdct.TabIndex = 5;
            this.btnprdct.Text = "     Products";
            this.btnprdct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprdct.UseVisualStyleBackColor = true;
            this.btnprdct.Click += new System.EventHandler(this.btnprdct_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogOut.Location = new System.Drawing.Point(0, 419);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(196, 54);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "    Log Out";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // button14
            // 
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.Location = new System.Drawing.Point(3, 546);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(36, 34);
            this.button14.TabIndex = 4;
            this.button14.Text = "?";
            this.button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button14.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 59);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(184, 54);
            this.btnHome.TabIndex = 4;
            this.btnHome.Text = "       Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // prodcutTableAdapter
            // 
            this.prodcutTableAdapter.ClearBeforeFill = true;
            // 
            // storeAppDBDataSet
            // 
            this.storeAppDBDataSet.DataSetName = "storeAppDBDataSet";
            this.storeAppDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prodcutBindingSource
            // 
            this.prodcutBindingSource.DataMember = "Prodcut";
            this.prodcutBindingSource.DataSource = this.storeAppDBDataSet;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(196, 43);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(741, 430);
            this.pnlContainer.TabIndex = 17;
            // 
            // frmIndexAd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 473);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIndexAd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellcome Admin";
            this.Load += new System.EventHandler(this.frmIndexAd_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSub.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.storeAppDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodcutBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlTagHom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button btnHome;
        private storeAppDBDataSetTableAdapters.ProdcutTableAdapter prodcutTableAdapter;
        private storeAppDBDataSet storeAppDBDataSet;
        private System.Windows.Forms.BindingSource prodcutBindingSource;
        private System.Windows.Forms.Button btnprdct;
        private System.Windows.Forms.Panel pnlSub;
        private System.Windows.Forms.Button brnMngProduct;
        private System.Windows.Forms.Button btnAllProduct;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnMinmz;
        private System.Windows.Forms.Label lblUname;
        private System.Windows.Forms.Panel pnlTagPro;
        private System.Windows.Forms.Panel pnlTagOrde;
    }
}