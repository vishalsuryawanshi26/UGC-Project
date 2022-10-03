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
    public partial class CompanyForm : Form
    {
         DBClass db=new DBClass();
         string oldname;
         public CompanyForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            btnsave.Text = "Save";
            txtname.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            //string pass = txtpass.Text;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@name", name);
            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into Company values(@name)", dic);
                MessageBox.Show("Product Company Created Successfully....", "Sucess Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dic.Add("@oldname", oldname);
                db.Execute("Update Company set  CompanyName=@name where CompanyName=@oldname", dic);
                MessageBox.Show("Update Product Company Successfully....", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.FillGrid(dg1, "select * from Company");
            txtname.Focus();
            
        }         

        private void CompanyForm_Load(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected Company?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string name = dg1.CurrentRow.Cells[0].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@name", name);
                    db.Execute("delete from Company where CompanyName=@name", dic);
                    db.FillGrid(dg1, "select * from Company");
                }
            }
        }

        /*private void btnedit_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)    //row is selected in Gredview
            {
                string user = dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from Company where UserName=" + user);
                txtname.Text = dt.Rows[0][0].ToString();
                btnedit.Text = "Update";
                txtname.Focus();
            }


            else
            {
                MessageBox.Show("Please select row", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }*/

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnedit_Click_1(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                oldname = dg1.CurrentRow.Cells[0].Value.ToString();
                txtname.Text = oldname;
                btnsave.Text = "Update";
                txtname.Focus();
            }
            else
            {
                MessageBox.Show("Please select row to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CompanyForm_Load_1(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from Company");
            db.Close();
        }
    }
}
