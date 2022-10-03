namespace ProjectDemo
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkhobbies = new System.Windows.Forms.CheckedListBox();
            this.txtmobno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.cmbcourses = new System.Windows.Forms.ComboBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.picphoto = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.dtbdate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.rbfemale = new System.Windows.Forms.RadioButton();
            this.rbmale = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtroll = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbsearch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picphoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 70);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(149, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Management";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.chkhobbies);
            this.groupBox1.Controls.Add(this.txtmobno);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnbrowse);
            this.groupBox1.Controls.Add(this.cmbcourses);
            this.groupBox1.Controls.Add(this.btnreset);
            this.groupBox1.Controls.Add(this.picphoto);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.dtbdate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rbfemale);
            this.groupBox1.Controls.Add(this.rbmale);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtroll);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 537);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Edit Student";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(109, 271);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(229, 25);
            this.txtemail.TabIndex = 19;
            this.txtemail.Validating += new System.ComponentModel.CancelEventHandler(this.txtemail_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(9, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 19);
            this.label12.TabIndex = 18;
            this.label12.Text = "Email Id";
            // 
            // chkhobbies
            // 
            this.chkhobbies.FormattingEnabled = true;
            this.chkhobbies.Items.AddRange(new object[] {
            "Cricket",
            "Swimming",
            "Reading",
            "Singing",
            "Others"});
            this.chkhobbies.Location = new System.Drawing.Point(106, 354);
            this.chkhobbies.Name = "chkhobbies";
            this.chkhobbies.Size = new System.Drawing.Size(120, 104);
            this.chkhobbies.TabIndex = 17;
            this.chkhobbies.Validating += new System.ComponentModel.CancelEventHandler(this.chkhobbies_Validating);
            // 
            // txtmobno
            // 
            this.txtmobno.Location = new System.Drawing.Point(106, 306);
            this.txtmobno.Name = "txtmobno";
            this.txtmobno.Size = new System.Drawing.Size(173, 25);
            this.txtmobno.TabIndex = 16;
            this.txtmobno.Validating += new System.ComponentModel.CancelEventHandler(this.txtmobno_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(8, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Hobbies";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(7, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Mobile No";
            // 
            // btnbrowse
            // 
            this.btnbrowse.BackColor = System.Drawing.Color.Silver;
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowse.ForeColor = System.Drawing.Color.Maroon;
            this.btnbrowse.Location = new System.Drawing.Point(387, 124);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(75, 34);
            this.btnbrowse.TabIndex = 3;
            this.btnbrowse.Text = "Browse";
            this.btnbrowse.UseVisualStyleBackColor = false;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // cmbcourses
            // 
            this.cmbcourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcourses.ForeColor = System.Drawing.Color.Maroon;
            this.cmbcourses.FormattingEnabled = true;
            this.cmbcourses.Items.AddRange(new object[] {
            "C Programming",
            "C++ Programming",
            "Java Advance",
            "C# Programming",
            "VB.Net"});
            this.cmbcourses.Location = new System.Drawing.Point(109, 227);
            this.cmbcourses.Name = "cmbcourses";
            this.cmbcourses.Size = new System.Drawing.Size(200, 27);
            this.cmbcourses.TabIndex = 13;
            this.cmbcourses.Validating += new System.ComponentModel.CancelEventHandler(this.cmbcourses_Validating);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.Silver;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.ForeColor = System.Drawing.Color.Maroon;
            this.btnreset.Location = new System.Drawing.Point(209, 485);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(118, 36);
            this.btnreset.TabIndex = 5;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // picphoto
            // 
            this.picphoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picphoto.Location = new System.Drawing.Point(375, 24);
            this.picphoto.Name = "picphoto";
            this.picphoto.Size = new System.Drawing.Size(100, 94);
            this.picphoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picphoto.TabIndex = 2;
            this.picphoto.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(7, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "Courses";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Silver;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.Maroon;
            this.btnsave.Location = new System.Drawing.Point(60, 485);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(118, 36);
            this.btnsave.TabIndex = 4;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtbdate
            // 
            this.dtbdate.CalendarForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtbdate.Location = new System.Drawing.Point(109, 193);
            this.dtbdate.Name = "dtbdate";
            this.dtbdate.Size = new System.Drawing.Size(200, 25);
            this.dtbdate.TabIndex = 11;
            this.dtbdate.Validating += new System.ComponentModel.CancelEventHandler(this.dtbdate_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(7, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Birth Date";
            // 
            // rbfemale
            // 
            this.rbfemale.AutoSize = true;
            this.rbfemale.ForeColor = System.Drawing.Color.Maroon;
            this.rbfemale.Location = new System.Drawing.Point(172, 164);
            this.rbfemale.Name = "rbfemale";
            this.rbfemale.Size = new System.Drawing.Size(75, 23);
            this.rbfemale.TabIndex = 9;
            this.rbfemale.TabStop = true;
            this.rbfemale.Text = "Female";
            this.rbfemale.UseVisualStyleBackColor = true;
            this.rbfemale.Validating += new System.ComponentModel.CancelEventHandler(this.rbmale_Validating);
            // 
            // rbmale
            // 
            this.rbmale.AutoSize = true;
            this.rbmale.ForeColor = System.Drawing.Color.Maroon;
            this.rbmale.Location = new System.Drawing.Point(106, 164);
            this.rbmale.Name = "rbmale";
            this.rbmale.Size = new System.Drawing.Size(60, 23);
            this.rbmale.TabIndex = 8;
            this.rbmale.TabStop = true;
            this.rbmale.Text = "Male";
            this.rbmale.UseVisualStyleBackColor = true;
            this.rbmale.Validating += new System.ComponentModel.CancelEventHandler(this.rbmale_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(7, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Gender";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(109, 106);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(229, 52);
            this.txtaddress.TabIndex = 6;
            this.txtaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            this.txtaddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtaddress_Validating);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(109, 65);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(229, 25);
            this.txtname.TabIndex = 5;
            this.txtname.Validating += new System.ComponentModel.CancelEventHandler(this.txtname_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(21, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 19);
            this.label5.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(7, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(7, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // txtroll
            // 
            this.txtroll.Location = new System.Drawing.Point(109, 31);
            this.txtroll.Name = "txtroll";
            this.txtroll.Size = new System.Drawing.Size(100, 25);
            this.txtroll.TabIndex = 1;
            this.txtroll.Validating += new System.ComponentModel.CancelEventHandler(this.txtroll_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Roll No";
            // 
            // cmbsearch
            // 
            this.cmbsearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsearch.ForeColor = System.Drawing.Color.Maroon;
            this.cmbsearch.FormattingEnabled = true;
            this.cmbsearch.Items.AddRange(new object[] {
            "RollNo",
            "Name",
            "Address",
            "Course"});
            this.cmbsearch.Location = new System.Drawing.Point(607, 86);
            this.cmbsearch.Name = "cmbsearch";
            this.cmbsearch.Size = new System.Drawing.Size(121, 27);
            this.cmbsearch.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(524, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 19);
            this.label11.TabIndex = 18;
            this.label11.Text = "Search";
            // 
            // dg1
            // 
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(506, 152);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(629, 289);
            this.dg1.TabIndex = 20;
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.Silver;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.ForeColor = System.Drawing.Color.Maroon;
            this.btnedit.Location = new System.Drawing.Point(538, 470);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(118, 36);
            this.btnedit.TabIndex = 21;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Silver;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.ForeColor = System.Drawing.Color.Maroon;
            this.btndelete.Location = new System.Drawing.Point(676, 470);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(118, 36);
            this.btndelete.TabIndex = 22;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(750, 86);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(274, 27);
            this.txtsearch.TabIndex = 18;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Silver;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.ForeColor = System.Drawing.Color.Maroon;
            this.btnprint.Location = new System.Drawing.Point(812, 470);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(118, 36);
            this.btnprint.TabIndex = 23;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1147, 625);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.cmbsearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRUD Operations";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picphoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmobno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbcourses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtbdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbfemale;
        private System.Windows.Forms.RadioButton rbmale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtroll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkhobbies;
        private System.Windows.Forms.PictureBox picphoto;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.ComboBox cmbsearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}