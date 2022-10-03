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
    public partial class SupplierPaymentForm : Form
    {
         DBClass db=new DBClass();
         SupplierForm f;
         double bal;
         string mamt;
         public SupplierPaymentForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtno.Text=db.GetID("PayNo");
            dtpdate.Value = DateTime.Now;
            txtsuppno.Clear();
            txtsuppname.Clear();
            txtamt.Clear();
            cmbmode.SelectedIndex = -1;
            //txtname.Clear();
            txtsummary.Clear();
            dtpdate.Value = DateTime.Now;
            txtsuppname.Clear();
            label11.ResetText();
            txtamt.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string no = txtno.Text;
            string pdate = dtpdate.Value.ToString("yyyy-MM-dd hh:mm:ss tt");
            string suppno = txtsuppno.Text;
            string suppname = txtsuppname.Text;
            string amt = txtamt.Text;
            string mode = cmbmode.Text;
            string details = txtsummary.Text; 
          
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@pdate", pdate);
            dic.Add("@suppno", suppno);
            dic.Add("@suppname", suppname);
            dic.Add("@amt", amt);
            dic.Add("@mode", mode);
            dic.Add("@details", details);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into SupplierPayment values(@no,@pdate,@suppno,@suppname,@amt,@mode,@details)", dic);
                Dictionary<string, object> dic1 = new Dictionary<string, object>();
                dic1.Add("@amt",amt);
                dic1.Add("@suppno",suppno);
                db.Execute("Update Supplier set ACBalance=ACBalance-@amt where SuppNo=@suppno", dic1);
                MessageBox.Show("Product SupplierPayment Created Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("PayNo");
            }
            else
            {
                //Before update restore/reset balance
                db.Execute("Update Supplier set ACBalance=ACBalance+" + mamt + " where SuppNo=" + suppno);
                db.Execute("Update SupplierPayment set PayDate=@pdate,SuppNo=@suppno,PaidAmt=@amt,PayMode=@mode,PayDetails=@details where PayNo=@no", dic);
                db.Execute("Update Supplier set ACBalance=ACBalance-" + amt + " where SuppNo=" + suppno);
                //db.Execute("Update SupplierPayment set PayDate=@pdate,SuppNo=@suppno,SuppName=@suppname,PaidAmt=@amt,PayMode=@mode,PayDetails=@details where PayNo=@no", dic);
                MessageBox.Show("SupplierPayment Updated Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.FillGrid(dg1, "select * from SupplierPayment");
            txtsuppno.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected SupplierPayment?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string no = dg1.CurrentRow.Cells[0].Value.ToString();
                    string suppno = dg1.CurrentRow.Cells[0].Value.ToString();
                    string amt = dg1.CurrentRow.Cells[4].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@no", no);
                    db.Execute("delete from SupplierPayment where PayNo=@no", dic);
                    db.Execute("Update Supplier set ACBalance=ACBalance+"+amt+"where SuppNo="+suppno);
                    db.FillGrid(dg1, "select * from SupplierPayment");
                    db.UpdateId("PayNo");
                }
            }
        }

        /*private void btnedit_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)    //row is selected in Gredview
            {
                string user = dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from SupplierPayment where UserName=" + user);
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
                string pdate = dg1.CurrentRow.Cells[1].Value.ToString();
                string suppno = dg1.CurrentRow.Cells[2].Value.ToString();
                string suppname = dg1.CurrentRow.Cells[3].Value.ToString();
                string amt = dg1.CurrentRow.Cells[4].Value.ToString();
                mamt=amt;

                string mode = dg1.CurrentRow.Cells[5].Value.ToString();
                string summary = dg1.CurrentRow.Cells[6].Value.ToString();
                
                txtno.Text = no;
                dtpdate.Value = DateTime.Parse(pdate);
                txtsuppno.Text = suppno;
                txtsuppname.Text = suppname;
                DataTable dt = db.GetTable("select ACBalance from Supplier where SuppNo=" + suppno);
                bal = double.Parse(dt.Rows[0][0].ToString());
                label11.Text = "[Outstanding Balance:" + dt.Rows[0][0].ToString()+"]";
                txtamt.Text= amt;
                cmbmode.Text = mode;
                txtsummary.Text = summary;
                btnsave.Text = "Update";
                txtsuppno.Focus();
            }
            else
            {
                MessageBox.Show("Please select row to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SupplierPaymentForm_Load_1(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from SupplierPayment");
            txtno.Text = db.GetID("PayNo");
            txtsuppno.Focus();
            
            db.Close();
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtno, "PayNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtsuppno, "SuppNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtsuppname, "SuppName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtamt, "PaidAmt", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtsummary, "PayDetails", new string[] { "Empty" });
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void SupplierPaymentForm_Load_2(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "Select * from SupplierPayment where " + comboBox1.Text + " like'%" + txtsearch.Text + "%'");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new SupplierPaymentReport(), "select * from SupplierPayment", "SupplierPayment");
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {

        }

        private void btnsupp_Click_1(object sender, EventArgs e)
        {
            //Open Supplier Form
            f = new SupplierForm();
            f.dg1.Click += new EventHandler(dg1_Click);
            f.Show();
        }

        void dg1_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView) sender;
            if (dg.CurrentRow != null)
            {
                txtsuppno.Text = dg.CurrentRow.Cells[0].Value.ToString();
                txtsuppname.Text = dg.CurrentRow.Cells[1].Value.ToString();
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
