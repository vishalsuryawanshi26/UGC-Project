using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HardwareShopManagement
{
    public partial class LoginForm : Form
    {
         DBClass db=new DBClass();
         Forgot_Password p = new Forgot_Password();
         SignUpForm s = new SignUpForm();
         CPasswordForm c = new CPasswordForm();
         
         public LoginForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        { 
            string user = txtuser.Text;
            string pass = txtpass.Text;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@user", user);
            dic.Add("@pass", pass);
            DataTable dt = db.GetTable("select * from Login where UserName=@user and Password=@pass", dic);
            if (dt.Rows.Count>0)
            {
                ProjectEnv.UserName = user;
                ProjectEnv.Password = pass;

                Hide();
                MainForm f = new MainForm();
                f.loginForm = this;     //Current class object
                f.Show();
            }
            else
            {
                MessageBox.Show("Login Failed....", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Clear();
                txtpass.Focus();
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
                txtpass.UseSystemPasswordChar = false;
            else
                txtpass.UseSystemPasswordChar = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtuser,"UserName",new string[]{"Empty"});
            ValidationUtil.ApplyRules(txtpass,"Password",new string[]{"Empty"});
            ValidationUtil.disableValidationOnClose(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            p = new Forgot_Password();
            //p.dg1.Click += new EventHandler(dg1_Click);
            p.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            s = new SignUpForm();
            //f.dg1.Click += new EventHandler(dg1_Click);
            s.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            c = new CPasswordForm ();
            c.Show();
        }
    }
}
