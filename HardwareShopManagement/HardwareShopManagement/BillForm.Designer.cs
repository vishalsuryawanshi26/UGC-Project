namespace HardwareShopManagement
{
    partial class BillForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.txtno = new System.Windows.Forms.TextBox();
            this.txtcname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbmode = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnno = new System.Windows.Forms.Button();
            this.dtbilldate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcno = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtadd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtunit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtpno = new System.Windows.Forms.TextBox();
            this.txtpname = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coloumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coloumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtdiscp = new System.Windows.Forms.TextBox();
            this.txttotalamt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtgstp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtnetamt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtgstamt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtdiscamt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtpaid = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblchange = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(905, 73);
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
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Bill";
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
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bill No";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Maroon;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(682, 678);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 30);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.Maroon;
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(776, 678);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(72, 30);
            this.btnreset.TabIndex = 16;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // txtno
            // 
            this.txtno.Location = new System.Drawing.Point(137, 36);
            this.txtno.Name = "txtno";
            this.txtno.ReadOnly = true;
            this.txtno.Size = new System.Drawing.Size(87, 25);
            this.txtno.TabIndex = 2;
            this.txtno.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtcname
            // 
            this.txtcname.Location = new System.Drawing.Point(484, 76);
            this.txtcname.Multiline = true;
            this.txtcname.Name = "txtcname";
            this.txtcname.Size = new System.Drawing.Size(207, 29);
            this.txtcname.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Customer Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbmode);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.btnno);
            this.groupBox1.Controls.Add(this.dtbilldate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtcno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtno);
            this.groupBox1.Controls.Add(this.txtcname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(27, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Bill Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbmode
            // 
            this.cmbmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmode.FormattingEnabled = true;
            this.cmbmode.Items.AddRange(new object[] {
            "Cash",
            "Online",
            "Cheque"});
            this.cmbmode.Location = new System.Drawing.Point(715, 67);
            this.cmbmode.Name = "cmbmode";
            this.cmbmode.Size = new System.Drawing.Size(121, 27);
            this.cmbmode.TabIndex = 16;
            this.cmbmode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(745, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 22);
            this.label19.TabIndex = 15;
            this.label19.Text = "Mode";
            // 
            // btnno
            // 
            this.btnno.BackColor = System.Drawing.Color.Maroon;
            this.btnno.ForeColor = System.Drawing.Color.White;
            this.btnno.Location = new System.Drawing.Point(244, 75);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(75, 30);
            this.btnno.TabIndex = 7;
            this.btnno.Text = "...";
            this.btnno.UseVisualStyleBackColor = false;
            this.btnno.Click += new System.EventHandler(this.btnno_Click);
            // 
            // dtbilldate
            // 
            this.dtbilldate.Location = new System.Drawing.Point(484, 34);
            this.dtbilldate.Name = "dtbilldate";
            this.dtbilldate.Size = new System.Drawing.Size(166, 25);
            this.dtbilldate.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 3;
            this.label10.Text = "Bill Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 19);
            this.label9.TabIndex = 5;
            this.label9.Text = "Customer No";
            // 
            // txtcno
            // 
            this.txtcno.Location = new System.Drawing.Point(137, 78);
            this.txtcno.Name = "txtcno";
            this.txtcno.ReadOnly = true;
            this.txtcno.Size = new System.Drawing.Size(87, 25);
            this.txtcno.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtprice);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtadd);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtunit);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtqty);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtpno);
            this.groupBox2.Controls.Add(this.txtpname);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(27, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bill Items Information";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(338, 70);
            this.txtprice.Multiline = true;
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(71, 31);
            this.txtprice.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(344, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "Price";
            // 
            // txtadd
            // 
            this.txtadd.BackColor = System.Drawing.Color.Maroon;
            this.txtadd.ForeColor = System.Drawing.Color.White;
            this.txtadd.Location = new System.Drawing.Point(618, 72);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(132, 30);
            this.txtadd.TabIndex = 11;
            this.txtadd.Text = "Add Product";
            this.txtadd.UseVisualStyleBackColor = false;
            this.txtadd.Click += new System.EventHandler(this.txtadd_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(78, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtunit
            // 
            this.txtunit.Location = new System.Drawing.Point(522, 70);
            this.txtunit.Multiline = true;
            this.txtunit.Name = "txtunit";
            this.txtunit.Size = new System.Drawing.Size(85, 31);
            this.txtunit.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Unit";
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(431, 72);
            this.txtqty.Multiline = true;
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(71, 29);
            this.txtqty.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Product Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Product No";
            // 
            // txtpno
            // 
            this.txtpno.Location = new System.Drawing.Point(9, 73);
            this.txtpno.Name = "txtpno";
            this.txtpno.ReadOnly = true;
            this.txtpno.Size = new System.Drawing.Size(63, 25);
            this.txtpno.TabIndex = 5;
            // 
            // txtpname
            // 
            this.txtpname.Location = new System.Drawing.Point(137, 72);
            this.txtpname.Multiline = true;
            this.txtpname.Name = "txtpname";
            this.txtpname.Size = new System.Drawing.Size(183, 29);
            this.txtpname.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.coloumnHeader5,
            this.coloumnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(27, 373);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(853, 206);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ProductNo";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ProductName";
            this.columnHeader2.Width = 260;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantity";
            this.columnHeader4.Width = 100;
            // 
            // coloumnHeader5
            // 
            this.coloumnHeader5.Text = "Unit";
            this.coloumnHeader5.Width = 105;
            // 
            // coloumnHeader6
            // 
            this.coloumnHeader6.Text = "Total";
            this.coloumnHeader6.Width = 150;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 602);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "F3 - Delete Item";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(143, 602);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "Disc%";
            // 
            // txtdiscp
            // 
            this.txtdiscp.Location = new System.Drawing.Point(208, 597);
            this.txtdiscp.Multiline = true;
            this.txtdiscp.Name = "txtdiscp";
            this.txtdiscp.Size = new System.Drawing.Size(141, 28);
            this.txtdiscp.TabIndex = 4;
            this.txtdiscp.TextChanged += new System.EventHandler(this.txtdiscp_TextChanged);
            // 
            // txttotalamt
            // 
            this.txttotalamt.Location = new System.Drawing.Point(752, 600);
            this.txttotalamt.Multiline = true;
            this.txttotalamt.Name = "txttotalamt";
            this.txttotalamt.Size = new System.Drawing.Size(141, 28);
            this.txttotalamt.TabIndex = 6;
            this.txttotalamt.TextChanged += new System.EventHandler(this.txttotalamt_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(642, 603);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 17);
            this.label16.TabIndex = 5;
            this.label16.Text = "Total Amount";
            // 
            // txtgstp
            // 
            this.txtgstp.Location = new System.Drawing.Point(208, 631);
            this.txtgstp.Multiline = true;
            this.txtgstp.Name = "txtgstp";
            this.txtgstp.Size = new System.Drawing.Size(141, 28);
            this.txtgstp.TabIndex = 8;
            this.txtgstp.TextChanged += new System.EventHandler(this.txtgstp_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(143, 636);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 17);
            this.label17.TabIndex = 7;
            this.label17.Text = "GST%";
            // 
            // txtnetamt
            // 
            this.txtnetamt.Location = new System.Drawing.Point(752, 640);
            this.txtnetamt.Multiline = true;
            this.txtnetamt.Name = "txtnetamt";
            this.txtnetamt.Size = new System.Drawing.Size(141, 28);
            this.txtnetamt.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(642, 643);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 17);
            this.label18.TabIndex = 9;
            this.label18.Text = "Net Amount";
            // 
            // txtgstamt
            // 
            this.txtgstamt.Location = new System.Drawing.Point(473, 634);
            this.txtgstamt.Multiline = true;
            this.txtgstamt.Name = "txtgstamt";
            this.txtgstamt.Size = new System.Drawing.Size(141, 28);
            this.txtgstamt.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(368, 637);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "GST Price";
            // 
            // txtdiscamt
            // 
            this.txtdiscamt.Location = new System.Drawing.Point(473, 594);
            this.txtdiscamt.Multiline = true;
            this.txtdiscamt.Name = "txtdiscamt";
            this.txtdiscamt.Size = new System.Drawing.Size(141, 28);
            this.txtdiscamt.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 600);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Disc Price";
            // 
            // txtpaid
            // 
            this.txtpaid.Location = new System.Drawing.Point(208, 675);
            this.txtpaid.Multiline = true;
            this.txtpaid.Name = "txtpaid";
            this.txtpaid.Size = new System.Drawing.Size(141, 28);
            this.txtpaid.TabIndex = 22;
            this.txtpaid.TextChanged += new System.EventHandler(this.txtpaid_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(102, 678);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Paid Amount";
            // 
            // lblchange
            // 
            this.lblchange.AutoSize = true;
            this.lblchange.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchange.Location = new System.Drawing.Point(382, 686);
            this.lblchange.Name = "lblchange";
            this.lblchange.Size = new System.Drawing.Size(84, 26);
            this.lblchange.TabIndex = 23;
            this.lblchange.Text = "Change";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 749);
            this.Controls.Add(this.lblchange);
            this.Controls.Add(this.txtpaid);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtgstamt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtdiscamt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtnetamt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtgstp);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txttotalamt);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtdiscp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Bill";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        public System.Windows.Forms.TextBox txtcname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnno;
        private System.Windows.Forms.DateTimePicker dtbilldate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtcno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button txtadd;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtunit;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtpno;
        public System.Windows.Forms.TextBox txtpname;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader coloumnHeader5;
        private System.Windows.Forms.ColumnHeader coloumnHeader6;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtdiscp;
        public System.Windows.Forms.TextBox txttotalamt;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtgstp;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtnetamt;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtgstamt;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtdiscamt;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtpaid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblchange;
        private System.Windows.Forms.ComboBox cmbmode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        //public System.Windows.Forms.TextBox txtuser;
        //public System.Windows.Forms.TextBox txtpass;
    }
}

