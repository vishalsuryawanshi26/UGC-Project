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
    public partial class CPasswordForm : Form
    {
        DBClass db = new DBClass();
         public CPasswordForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        { 
            string pass = txtpass.Text;
            string pass1 = txtpass1.Text;
            string pass2 = txtpass2.Text;
            //check old password is valid or not
            if (pass != ProjectEnv.Password)
            {
                MessageBox.Show("Wrong Old Password....", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();
                return;
            }
                //check new password and confirm new password must be same
            if(pass1 != pass2)
            {
                MessageBox.Show("Password Mismatch....", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass2.Focus();
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@user", ProjectEnv.UserName);
            dic.Add("@pass", pass1);
            db.Execute("Update Login Set Password=@pass where UserName=@user", dic);
            db.Execute("Update Signup Set Password=@pass where UserName=@user", dic);
            ProjectEnv.Password = pass1;
            MessageBox.Show("Password Changed Successfully.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtpass.Clear();
            txtpass1.Clear();
            txtpass2.Clear();
            txtpass.Focus();
            return;
        }

        private void CPasswordForm_Load(object sender, EventArgs e)
        {
        
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            

        }
    }
}
