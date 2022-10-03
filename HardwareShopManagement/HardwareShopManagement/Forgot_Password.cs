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
    public partial class Forgot_Password : Form
    {
        DBClass db = new DBClass();
        public Forgot_Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void btnretrive_Click(object sender, EventArgs e)
        {
            DataTable dt = db.GetTable("select * from SignUp where UserName='" + txtuser.Text + "' and Answer='" + txtans.Text + "'");

                      if (dt.Rows.Count > 0)
            {      
                        txtpass.Text = dt.Rows[0]["Password"].ToString();
                        
                        MessageBox.Show("Retrieve Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
            }
            else
            {
                MessageBox.Show("Wrong Information....", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtans.Focus();
                return;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void Forgot_Password_Load(object sender, EventArgs e)
        {

        }

    }
}
