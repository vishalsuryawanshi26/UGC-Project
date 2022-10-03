using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HardwareShopManagement.Reports;

namespace HardwareShopManagement
{
    public partial class CustomerForm : Form
    {
         DBClass db=new DBClass();
         string oldname;
         public CustomerForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtno.Text=db.GetID("CustNumber");
            txtname.Clear();
            txtaddress.Clear();
            dtbdate.Value = DateTime.Now;
            txtcontact.Clear();
            txtbal.Clear();
            txtemail.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string no = txtno.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string bdate = dtbdate.Value.ToString("yyyy-MM-dd");
            string contactno = txtcontact.Text;
            string email = txtemail.Text;
            string balance = txtbal.Text;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@name", name);
            dic.Add("@address", address);
            dic.Add("@bdate", bdate);
            dic.Add("@contactno", contactno);
            dic.Add("@email", email);
            dic.Add("@balance", balance);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into Customer values(@no,@name,@address,@bdate,@contactno,@email,@balance)", dic);
                MessageBox.Show("Product Customer Created Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("CustNumber");
            }
            else
            {
                
                db.Execute("Update Customer set CustName=@name,CustAddress=@address,BirthDate=@bdate,ContactNo=@contactno,EmailID=@email,ACBalance=@balance where CustNo=@no", dic);
                MessageBox.Show("Customer Updated Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.FillGrid(dg1, "select * from Customer");
            txtname.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected Customer?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string no = dg1.CurrentRow.Cells[0].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@no", no);
                    db.Execute("delete from Customer where CustNo=@no", dic);
                    db.FillGrid(dg1, "select * from Customer");
                    db.UpdateId("CustNumber");
                }
            }
        }

        /*private void btnedit_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)    //row is selected in Gredview
            {
                string user = dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from Customer where UserName=" + user);
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
                string no = dg1.CurrentRow.Cells[0].Value.ToString();
                string name = dg1.CurrentRow.Cells[1].Value.ToString();
                string address = dg1.CurrentRow.Cells[2].Value.ToString();
                string bdate = dg1.CurrentRow.Cells[3].Value.ToString();
                string contactno = dg1.CurrentRow.Cells[4].Value.ToString();
                string email = dg1.CurrentRow.Cells[5].Value.ToString();
                string bal = dg1.CurrentRow.Cells[6].Value.ToString();
                txtno.Text = no;
                txtname.Text = name;
                txtaddress.Text = address;
                dtbdate.Value = DateTime.Parse(bdate);
                txtcontact.Text= contactno;
                txtemail.Text = email;
                txtbal.Text = bal;
                btnsave.Text = "Update";
                txtname.Focus();
            }
            else
            {
                MessageBox.Show("Please select row to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CustomerForm_Load_1(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from Customer");
            txtno.Text = db.GetID("CustNumber");
            txtname.Focus();
            
            db.Close();

            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtno, "CustNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtname, "CustName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtaddress, "CustAdress", new string[] { "Empty" });
            ValidationUtil.CheckDateBeforeCombo(dtbdate, "BirthDate", 5);
            ValidationUtil.ApplyRules(txtcontact, "ContactNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtemail, "EmailID", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtbal, "ACBalance", new string[] { "Empty" });

            //ValidationUtil.CheckCombo(
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load_2(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "Select * from Customer where " + comboBox1.Text + " like'%" + txtsearch.Text + "%'");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CustomerReport(), "select * from Customer", "Customer");
        }
    }
}
