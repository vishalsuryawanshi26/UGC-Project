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
    public partial class CustomerReceiptForm : Form
    {
         DBClass db=new DBClass();
         CustomerForm f;
         double bal;
         string mamt;
         public CustomerReceiptForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtno.Text=db.GetID("RecNo");
            dtrdate.Value = DateTime.Now;
            txtcustno.Clear();
            txtname.Clear();
            txtamt.Clear();
            cmbmode.SelectedIndex = -1;
            //txtname.Clear();
            txtsummary.Clear();
            dtrdate.Value = DateTime.Now;
            txtname.Clear();
            label11.ResetText();
            txtamt.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string no = txtno.Text;
            string rdate = dtrdate.Value.ToString("yyyy-MM-dd hh:mm:ss tt");
            string custno = txtcustno.Text;
            string custname = txtname.Text;
            string amt = txtamt.Text;
            string mode = cmbmode.Text;
            string details = txtsummary.Text; 
          
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@rdate", rdate);
            dic.Add("@custno", custno);
            dic.Add("@custname", custname);
            dic.Add("@amt", amt);
            dic.Add("@mode", mode);
            dic.Add("@details", details);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into CustomerReceipt values(@no,@rdate,@custno,@custname,@amt,@mode,@details)", dic);
                Dictionary<string, object> dic1 = new Dictionary<string, object>();
                dic1.Add("@amt",amt);
                dic1.Add("@custno",custno);
                db.Execute("Update Customer set ACBalance=ACBalance-@amt where custno=@custno", dic1);
                MessageBox.Show("Product CustomerReceipt Created Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("RecNo");
            }
            else
            {
                //Before Update restore/reset balance
                db.Execute("Update Customer set ACBalance=ACBalance+" + mamt + " where custno=" + custno);
                db.Execute("Update CustomerReceipt set RecDate=@rdate,custno=@custno,PaidAmt=@amt,PayMode=@mode,PayDetails=@details where RecNo=@no", dic);
                db.Execute("Update Customer set ACBalance=ACBalance-" + amt + " where custno=" + custno);
                //db.Execute("Update CustomerReceipt set PayDate=@rdate,custno=@custno,custname=@custname,PaidAmt=@amt,PayMode=@mode,PayDetails=@details where RecNo=@no", dic);
                MessageBox.Show("CustomerReceipt Updated Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.FillGrid(dg1, "select * from CustomerReceipt");
            txtcustno.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected CustomerReceipt?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string no = dg1.CurrentRow.Cells[0].Value.ToString();
                    string custno = dg1.CurrentRow.Cells[0].Value.ToString();
                    string amt = dg1.CurrentRow.Cells[4].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@no", no);
                    db.Execute("delete from CustomerReceipt where RecNo=@no", dic);
                    db.Execute("Update Customer set ACBalance=ACBalance+"+amt+"where custno="+custno);
                    db.FillGrid(dg1, "select * from CustomerReceipt");
                    db.UpdateId("RecNo");
                }
            }
        }

        /*private void btnedit_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)    //row is selected in Gredview
            {
                string user = dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from CustomerReceipt where UserName=" + user);
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
                string rdate = dg1.CurrentRow.Cells[1].Value.ToString();
                string custno = dg1.CurrentRow.Cells[2].Value.ToString();
                string custname = dg1.CurrentRow.Cells[3].Value.ToString();
                string amt = dg1.CurrentRow.Cells[4].Value.ToString();
                mamt=amt;

                string mode = dg1.CurrentRow.Cells[5].Value.ToString();
                string summary = dg1.CurrentRow.Cells[6].Value.ToString();
                
                txtno.Text = no;
                dtrdate.Value = DateTime.Parse(rdate);
                txtcustno.Text = custno;
                txtname.Text = custname;
                DataTable dt = db.GetTable("select ACBalance from Customer where custno=" + custno);
                bal = double.Parse(dt.Rows[0][0].ToString());
                label11.Text = "[Outstanding Balance:" + dt.Rows[0][0].ToString()+"]";
                txtamt.Text= amt;
                cmbmode.Text = mode;
                txtsummary.Text = summary;
                btnsave.Text = "Update";
                txtcustno.Focus();
            }
            else
            {
                MessageBox.Show("Please select row to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CustomerReceiptForm_Load_1(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from CustomerReceipt");
            txtno.Text = db.GetID("RecNo");
            txtcustno.Focus();
            
            db.Close();


            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtno, "RecNo", new string[] { "Empty" });
            //ValidationUtil.ApplyRules(dtrdate, "RecDate", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtcustno, "CustNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtname, "CustName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtamt, "PaidAmt", new string[] { "Empty" });
            //ValidationUtil.ApplyRules(cmbmode, "PayMode", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtsummary, "PayDetails", new string[] { "Empty" });

            ValidationUtil.disableValidationOnClose(this);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerReceiptForm_Load_2(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "Select * from CustomerReceipt where " + comboBox1.Text + " like'%" + txtsearch.Text + "%'");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CustomerRecReport(), "select * from CustomerReceipt", "CustomerReceipt");
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {

        }

        private void btnsupp_Click_1(object sender, EventArgs e)
        {
            //Open Customer Form
            f = new CustomerForm();
            f.dg1.Click += new EventHandler(dg1_Click);
            f.Show();
        }

        void dg1_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView) sender;
            if (dg.CurrentRow != null)
            {
                txtcustno.Text = dg.CurrentRow.Cells[0].Value.ToString();
                txtname.Text = dg.CurrentRow.Cells[1].Value.ToString();
                bal=double.Parse(dg.CurrentRow.Cells[6].Value.ToString());
                label11.Text = "[Outstanding Balance :"+dg.CurrentRow.Cells[6].Value.ToString()+"]";
                
                if(f !=null)
                {
                    f.Close();
                }
            }
        }
    }
}
