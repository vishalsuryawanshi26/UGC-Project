namespace HardwareShopManagement
{
    partial class CustomerReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerReceiptForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.txtno = new System.Windows.Forms.TextBox();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.btnremove = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.txtsummary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtamt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtrdate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.cmbmode = new System.Windows.Forms.ComboBox();
            this.btncust = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcustno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(872, 73);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Receipt Form";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receipt No";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Maroon;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(130, 431);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 30);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.Maroon;
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(224, 431);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(72, 30);
            this.btnreset.TabIndex = 19;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // txtno
            // 
            this.txtno.Location = new System.Drawing.Point(149, 79);
            this.txtno.Name = "txtno";
            this.txtno.ReadOnly = true;
            this.txtno.Size = new System.Drawing.Size(166, 23);
            this.txtno.TabIndex = 2;
            this.txtno.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(352, 122);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(495, 250);
            this.dg1.TabIndex = 23;
            // 
            // btnremove
            // 
            this.btnremove.BackColor = System.Drawing.Color.Maroon;
            this.btnremove.ForeColor = System.Drawing.Color.White;
            this.btnremove.Location = new System.Drawing.Point(505, 390);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(132, 30);
            this.btnremove.TabIndex = 25;
            this.btnremove.Text = "Remove Entry";
            this.btnremove.UseVisualStyleBackColor = false;
            this.btnremove.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.Maroon;
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(367, 390);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(132, 30);
            this.btnedit.TabIndex = 24;
            this.btnedit.Text = "Modify Receipt";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click_1);
            // 
            // txtsummary
            // 
            this.txtsummary.Location = new System.Drawing.Point(149, 334);
            this.txtsummary.Multiline = true;
            this.txtsummary.Name = "txtsummary";
            this.txtsummary.Size = new System.Drawing.Size(166, 56);
            this.txtsummary.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Pay Summary";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(149, 190);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(166, 23);
            this.txtname.TabIndex = 11;
            this.txtname.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Customer Name";
            // 
            // txtamt
            // 
            this.txtamt.Location = new System.Drawing.Point(149, 255);
            this.txtamt.Name = "txtamt";
            this.txtamt.Size = new System.Drawing.Size(166, 23);
            this.txtamt.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Paid Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Payment Mode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Receipt Date";
            // 
            // dtrdate
            // 
            this.dtrdate.CustomFormat = "dd-MM-yyyy hh:mm:ss tt";
            this.dtrdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtrdate.Location = new System.Drawing.Point(149, 118);
            this.dtrdate.Name = "dtrdate";
            this.dtrdate.Size = new System.Drawing.Size(166, 23);
            this.dtrdate.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Customer No";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RecNo",
            "RecDate",
            "CustNo",
            "PaidAmt",
            "PayMode",
            "PayDetails"});
            this.comboBox1.Location = new System.Drawing.Point(451, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 21;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(578, 90);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(250, 23);
            this.txtsearch.TabIndex = 22;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Maroon;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(643, 390);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(132, 30);
            this.btnprint.TabIndex = 23;
            this.btnprint.Text = "Print Receipt";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // cmbmode
            // 
            this.cmbmode.FormattingEnabled = true;
            this.cmbmode.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Online Payment",
            "NFT",
            "Net Banking"});
            this.cmbmode.Location = new System.Drawing.Point(150, 294);
            this.cmbmode.Name = "cmbmode";
            this.cmbmode.Size = new System.Drawing.Size(165, 25);
            this.cmbmode.TabIndex = 15;
            // 
            // btncust
            // 
            this.btncust.BackColor = System.Drawing.Color.Maroon;
            this.btncust.ForeColor = System.Drawing.Color.White;
            this.btncust.Location = new System.Drawing.Point(243, 152);
            this.btncust.Name = "btncust";
            this.btncust.Size = new System.Drawing.Size(72, 27);
            this.btncust.TabIndex = 9;
            this.btncust.Text = "...";
            this.btncust.UseVisualStyleBackColor = false;
            this.btncust.Click += new System.EventHandler(this.btnsupp_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Customer No";
            // 
            // txtcustno
            // 
            this.txtcustno.Location = new System.Drawing.Point(149, 154);
            this.txtcustno.Name = "txtcustno";
            this.txtcustno.Size = new System.Drawing.Size(77, 23);
            this.txtcustno.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "[Outstanding Balance]";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CustomerReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 464);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtcustno);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btncust);
            this.Controls.Add(this.cmbmode);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtrdate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtamt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsummary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnremove);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.txtno);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Receipt Form";
            this.Load += new System.EventHandler(this.CustomerReceiptForm_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtno;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.Button btnedit;
        public System.Windows.Forms.TextBox txtsummary;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtamt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtrdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.ComboBox cmbmode;
        private System.Windows.Forms.Button btncust;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtcustno;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        //public System.Windows.Forms.TextBox txtuser;
        //public System.Windows.Forms.TextBox txtpass;
    }
}

