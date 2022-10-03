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
    public partial class UserManagementForm : Form
    {
         DBClass db=new DBClass();
         public UserManagementForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
            txtuser.Focus();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = txtpass.Text;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@user", user);
            dic.Add("@pass", pass);
            db.Execute("Insert into Login values(@user,@pass)", dic);
            MessageBox.Show("Login Created Successfully....", "Sucess Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.FillGrid(dg1, "select username,password from login");
            txtuser.Clear();
            txtpass.Clear();
            txtuser.Focus();
            
        }


            

        private void LoginForm_Load(object sender, EventArgs e)
        {
           db.FillGrid(dg1,"select username,password from login");
            db.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected user?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string user = dg1.CurrentRow.Cells[0].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@user", user);
                    db.Execute("delete from Login where UserName=@user", dic);
                    db.FillGrid(dg1, "select username,password from login");
                }
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
                txtpass.UseSystemPasswordChar = false;
            else
                txtpass.UseSystemPasswordChar = true;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            /*if (dg1.CurrentRow != null)    //row is selected in Gredview
            {
                string user = dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from Login where UserName=" + user);
                txtuser.Text = dt.Rows[0][0].ToString();
                txtpass.Text = dt.Rows[0][1].ToString();
                //txtaddress.Text = dt.Rows[0][2].ToString();
                btnedit.Text = "Update";
                txtuser.Focus();
            }


            else
            {
                MessageBox.Show("Please select row", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }*/
        }
    }
}
