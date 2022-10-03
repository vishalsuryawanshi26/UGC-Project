namespace HardwareShopManagement
{
    partial class MRListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.btnremove = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbfield = new System.Windows.Forms.ComboBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.MRNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 73);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Receipt Entries";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Maroon;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(13, 422);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(150, 30);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "New Material Receipt";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MRNo,
            this.MRDate,
            this.BillNo,
            this.BillDate,
            this.SuppNO,
            this.SuppName,
            this.PONo,
            this.TotalAmt,
            this.DiscP,
            this.DiscAmt,
            this.GSTP,
            this.GSTAmt,
            this.NetAmt});
            this.dg1.Location = new System.Drawing.Point(42, 137);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(881, 269);
            this.dg1.TabIndex = 20;
            this.dg1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellContentClick);
            // 
            // btnremove
            // 
            this.btnremove.BackColor = System.Drawing.Color.Maroon;
            this.btnremove.ForeColor = System.Drawing.Color.White;
            this.btnremove.Location = new System.Drawing.Point(345, 422);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(179, 30);
            this.btnremove.TabIndex = 22;
            this.btnremove.Text = "Remove Material Receipt";
            this.btnremove.UseVisualStyleBackColor = false;
            this.btnremove.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.Maroon;
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(169, 422);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(161, 30);
            this.btnedit.TabIndex = 21;
            this.btnedit.Text = "Edit Material Receipt";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click_1);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Maroon;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(530, 422);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(162, 30);
            this.btnprint.TabIndex = 23;
            this.btnprint.Text = "Print MR register";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(698, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 30);
            this.button1.TabIndex = 24;
            this.button1.Text = "Print MR Receipt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Search";
            // 
            // cmbfield
            // 
            this.cmbfield.FormattingEnabled = true;
            this.cmbfield.Items.AddRange(new object[] {
            "MRNo",
            "MRDate",
            "BillNo",
            "BillDate",
            "PONo",
            "SuppNo",
            "SuppName"});
            this.cmbfield.Location = new System.Drawing.Point(127, 94);
            this.cmbfield.Name = "cmbfield";
            this.cmbfield.Size = new System.Drawing.Size(121, 25);
            this.cmbfield.TabIndex = 26;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(270, 91);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(513, 28);
            this.txtsearch.TabIndex = 27;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged_1);
            // 
            // MRNo
            // 
            this.MRNo.DataPropertyName = "MRNo";
            this.MRNo.HeaderText = "MR No";
            this.MRNo.Name = "MRNo";
            // 
            // MRDate
            // 
            this.MRDate.DataPropertyName = "MRDate";
            this.MRDate.HeaderText = "MR Date";
            this.MRDate.Name = "MRDate";
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "Bill No";
            this.BillNo.Name = "BillNo";
            // 
            // BillDate
            // 
            this.BillDate.DataPropertyName = "BillDate";
            this.BillDate.HeaderText = "Bill Date";
            this.BillDate.Name = "BillDate";
            // 
            // SuppNO
            // 
            this.SuppNO.DataPropertyName = "SuppNo";
            this.SuppNO.HeaderText = "Supplier No";
            this.SuppNO.Name = "SuppNO";
            // 
            // SuppName
            // 
            this.SuppName.DataPropertyName = "SuppName";
            this.SuppName.HeaderText = "Supplier Name";
            this.SuppName.Name = "SuppName";
            // 
            // PONo
            // 
            this.PONo.DataPropertyName = "PONo";
            this.PONo.HeaderText = "PONo";
            this.PONo.Name = "PONo";
            // 
            // TotalAmt
            // 
            this.TotalAmt.DataPropertyName = "TotalAmt";
            this.TotalAmt.HeaderText = "Total Amount";
            this.TotalAmt.Name = "TotalAmt";
            this.TotalAmt.Width = 150;
            // 
            // DiscP
            // 
            this.DiscP.DataPropertyName = "DiscP";
            this.DiscP.HeaderText = "Discount P";
            this.DiscP.Name = "DiscP";
            // 
            // DiscAmt
            // 
            this.DiscAmt.DataPropertyName = "DiscAmt";
            this.DiscAmt.HeaderText = "Disc Amt";
            this.DiscAmt.Name = "DiscAmt";
            // 
            // GSTP
            // 
            this.GSTP.DataPropertyName = "GSTP";
            this.GSTP.HeaderText = "GST%";
            this.GSTP.Name = "GSTP";
            // 
            // GSTAmt
            // 
            this.GSTAmt.DataPropertyName = "GSTAmt";
            this.GSTAmt.HeaderText = "GST Amt";
            this.GSTAmt.Name = "GSTAmt";
            // 
            // NetAmt
            // 
            this.NetAmt.DataPropertyName = "NetAmt";
            this.NetAmt.HeaderText = "Net Amount";
            this.NetAmt.Name = "NetAmt";
            // 
            // MRListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 464);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.cmbfield);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnremove);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MRListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Receipt Entry List Form";
            this.Load += new System.EventHandler(this.CustomerForm_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnprint;
        public System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbfield;
        private System.Windows.Forms.TextBox txtsearch;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmt;
        //public System.Windows.Forms.TextBox txtuser;
        //public System.Windows.Forms.TextBox txtpass;
    }
}

