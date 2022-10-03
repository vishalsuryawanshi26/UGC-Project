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
    public partial class BillForm : Form
    {
         DBClass db=new DBClass();
         CustomerForm f;
         ProductForm p;
         string oldamt;
         public BillForm()
        {
            InitializeComponent();
            txtno.Text = db.GetID("BillNo");
            cmbmode.SelectedIndex = 0;
        }
         public BillForm(string BillNo)
         {
             InitializeComponent();
             DataTable dt = db.GetTable("Select * from Bill where BillNo=" +BillNo);
             if (dt.Rows.Count > 0)
             {
                 cmbmode.SelectedIndex = 0;
                 txtno.Text = dt.Rows[0]["BillNo"].ToString();
                 dtbilldate.Value=DateTime.Parse(dt.Rows[0]["BillDate"].ToString());
                 txtcno.Text=dt.Rows[0]["CustNo"].ToString();
                 txtcname.Text = dt.Rows[0]["CustName"].ToString();
                 txttotalamt.Text = dt.Rows[0]["TotalAmt"].ToString();
                 txtdiscp.Text = dt.Rows[0]["DiscP"].ToString();
                 txtdiscamt.Text = dt.Rows[0]["DiscAmt"].ToString();
                 txtgstp.Text = dt.Rows[0]["GSTP"].ToString();
                 txtgstamt.Text = dt.Rows[0]["GSTAmt"].ToString();
                 txtnetamt.Text = dt.Rows[0]["NetAmt"].ToString();
                 cmbmode.Text=dt.Rows[0]["Mode"].ToString();
                 dt=db.GetTable("select * from Customer where CustNo="+txtcno.Text);
                 db.FillListView(listView1, "select ProdNo,ProdName,Price,Qty,Unit,Total from BillItems where BillNo=" + BillNo);
                 oldamt = dt.Rows[0]["ACBalance"].ToString();
                 btnsave.Text = "Update";
                 txtcname.Focus();
             }

         }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void MaterialReceiptForm_Load_1(object sender, EventArgs e)
        {
            
            dtbilldate.Focus();
            
            db.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load_2(object sender, EventArgs e)
        {

        }

       

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CustomerReport(), "select * from Customer", "Customer");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnno_Click(object sender, EventArgs e)
        {
            f = new CustomerForm();
            f.dg1.Click += new EventHandler(dg1_Click);
            f.Show();
        }

        void dg1_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentRow != null)
            {
                txtcno.Text = dg.CurrentRow.Cells[0].Value.ToString();
                txtcname.Text = dg.CurrentRow.Cells[1].Value.ToString();
                oldamt = dg.CurrentRow.Cells[6].Value.ToString();
                if (f != null)
                {
                    f.Close();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            p = new ProductForm();
            p.dg1.Click += new EventHandler(dg2_Click);
            p.Show();
        }
        void dg2_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentRow != null)
            {
                txtpno.Text = dg.CurrentRow.Cells[0].Value.ToString();
                txtpname.Text = dg.CurrentRow.Cells[1].Value.ToString();
                txtprice.Text = dg.CurrentRow.Cells[4].Value.ToString();
                txtunit.Text = dg.CurrentRow.Cells[6].Value.ToString();
                if (p != null)
                {
                    p.Close();
                    txtqty.Focus();
                }
            }
        }

        private void txtadd_Click(object sender, EventArgs e)
        {
            string pno = txtpno.Text;
            string pname = txtpname.Text;
            string price = txtprice.Text;
            string qty = txtqty.Text;
            string unit = txtunit.Text;
            double total = double.Parse(price) * int.Parse(qty);
            

            //listView1.Items.Add(ListViewItem Item);
            ListViewItem lt = new ListViewItem();
            //It consists of parent item and parent has child/sub items
            lt.Text = pno;
            lt.SubItems.Add(pname);
            lt.SubItems.Add(price);
            lt.SubItems.Add(qty);
            lt.SubItems.Add(unit);
            lt.SubItems.Add(total.ToString());
            
            listView1.Items.Add(lt);
            CalculateTotal();
        }
        void CalculateTotal()
        {
            double total = 0;
            foreach (ListViewItem lt in listView1.Items)
            {
                total = total + double.Parse(lt.SubItems[5].Text);
            }
            txttotalamt.Text = total.ToString();
        }

        private void BillForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                //MessageBox.Show("F3 Pressed");
                listView1.FocusedItem.Remove();
                listView1.Refresh();
                CalculateTotal();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcname.Text == "" || cmbmode.Text == "" || txtdiscamt.Text == "" || txtcno.Text == "" || txtgstamt.Text == "" || txtgstp.Text == "")
            {
                MessageBox.Show("missing fields");
                txtcname.Focus();
            }
            else
            {
                string billno = txtno.Text;
                string billdate = dtbilldate.Value.ToString("yyyy-MM-dd");
                string cno = txtcno.Text;
                string cname = txtcname.Text;
                string totalamt = txttotalamt.Text;
                string discp = txtdiscp.Text;
                string discamt = txtdiscamt.Text;
                string gstp = txtgstp.Text;
                string gstamt = txtgstamt.Text;
                string netamt = txtnetamt.Text;
                string mode = cmbmode.Text;

                //string prepared = txtprepared.Text;

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@billno", billno);
                dic.Add("@billdate", billdate);
                dic.Add("@cno", cno);
                dic.Add("@cname", cname);
                dic.Add("@totalamt", totalamt);
                dic.Add("@discp", discp);
                dic.Add("@discamt", discamt);
                dic.Add("@gstp", gstp);
                dic.Add("@gstamt", gstamt);
                dic.Add("@netamt", netamt);
                dic.Add("@mode", mode);

                //dic.Add("@prepared", prepared);

                if (btnsave.Text == "Save")
                {
                    db.Execute("Insert into Bill values(@billno,@billdate,@cno,@cname,@totalamt,@discp,@discamt,@gstp,@gstamt,@netamt,@mode)", dic);
                    dic = new Dictionary<string, object>();
                    foreach (ListViewItem lt in listView1.Items)
                    {
                        dic.Add("@billno", billno);
                        dic.Add("@prno", lt.Text);
                        dic.Add("@prname", lt.SubItems[1].Text);
                        dic.Add("@price", lt.SubItems[2].Text);
                        dic.Add("@qty", lt.SubItems[3].Text);
                        dic.Add("@unit", lt.SubItems[4].Text);
                        dic.Add("@netamt", lt.SubItems[5].Text);
                        //dic.Add("@mode", lt.SubItems[6].Text);
                        db.Execute("Insert into BillItems values(@billno,@prno,@prname,@price,@qty,@unit,@netamt)", dic);
                        dic.Clear();
                        db.Execute("Update Product set Qty=Qty-" + lt.SubItems[3].Text + " where ProdNo=" + lt.Text);

                    }
                    db.Execute("Update Customer Set ACBalance=ACBalance+" + netamt + "where CustNo=" + cno);
                    MessageBox.Show("Bill Generated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.UpdateId("BillNo");
                    Close();
                }
                else
                {
                    if (txtcname.Text == "" || cmbmode.Text == "" || txtdiscamt.Text == "" || txtcno.Text == "" || txtgstamt.Text == "" || txtgstp.Text == "")
                    {
                        MessageBox.Show("missing fields");
                    }
                    db.Execute("Update Customer set ACBalance=ACBalance+" + oldamt + "where CustNo=" + cno);
                    db.Execute("Update Bill set BillDate=@billdate,CustNo=@cno,CustName=@cname,TotalAmt=@totalamt,Discp=@discp,DiscAmt=@discamt,GSTP=@gstp,GSTAmt=@gstamt,NetAmt=@netamt,Mode=@mode where BillNo=@billno", dic);

                    db.Execute("Update Customer set ACBalance=ACBalance+" + netamt + "where CustNo=" + cno);

                    DataTable dt = db.GetTable("select * from BillItems where BillNo=" + billno);
                    foreach (DataRow dr in dt.Rows)
                    {
                        db.Execute("Update Product set Qty=Qty+" + dr[4].ToString() + "where ProdNo=" + dr[1].ToString());
                    }
                    db.Execute("Delete from BillItems where BillNo=" + billno);

                    dic = new Dictionary<string, object>();
                    foreach (ListViewItem lt in listView1.Items)
                    {
                        dic.Add("@billno", billno);
                        dic.Add("@prno", lt.Text);
                        dic.Add("@prname", lt.SubItems[1].Text);
                        dic.Add("@price", lt.SubItems[2].Text);
                        dic.Add("@qty", lt.SubItems[3].Text);
                        dic.Add("@unit", lt.SubItems[4].Text);
                        dic.Add("@totalamt", lt.SubItems[5].Text);
                        db.Execute("Insert into BillItems values(@billno,@prno,@prname,@price,@qty,@unit,@totalamt)", dic);
                        dic.Clear();
                        db.Execute("Update Product set Qty=Qty-" + lt.SubItems[3].Text + "where ProdNo=" + lt.Text);
                    }
                    MessageBox.Show("Purchase Order Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //db.UpdateId("BillNo");
                    Close();
                }
            }
            txtcname.Focus();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            
            dtbilldate.Focus();

            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtno, "BillNo", new string[] { "Empty" });
            //ValidationUtil.ApplyRules(dtbilldate, "BillDate", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtcno, "CustNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtcname, "CustName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txttotalamt, "TotalAmt", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtdiscp, "DiscP", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtdiscamt, "DiscAmt", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtgstp, "GSTP", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtgstamt, "GSTAmt", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtnetamt, "NetAmt", new string[] { "Empty" });
            //ValidationUtil.ApplyRules(cmbmode, "Mode", new string[] { "Empty" });

            ValidationUtil.disableValidationOnClose(this);
           
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtno.Text = db.GetID("BillNo");
            txtcname.Clear();
            dtbilldate.Value = DateTime.Now;
            txtdiscp.Clear();
            txtdiscamt.Clear();
            txtgstp.Clear();
            txtgstamt.Clear();
            listView1.Items.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void txtdiscp_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void txtgstp_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }
        void CalculateNet()
        {
            double discp = 0;
            if (!string.IsNullOrEmpty(txtdiscp.Text))
            {
                discp = double.Parse(txtdiscp.Text);
            }
            double totalamt = double.Parse(txttotalamt.Text);
            double discamt = totalamt * (discp / 100);
            totalamt = totalamt - discamt;
            txtdiscamt.Text = discamt.ToString();

            double gstp = 0;
            if (!string.IsNullOrEmpty(txtgstp.Text))
            {
                gstp = double.Parse(txtgstp.Text);
            }
            double gstamt = totalamt * (gstp / 100);
            txtgstamt.Text = gstamt.ToString();
            totalamt = totalamt + gstamt;
            txtnetamt.Text = totalamt.ToString();
        }

        private void txtpaid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaid.Text))
            {
                double paid = double.Parse(txtpaid.Text);
                double net = double.Parse(txtnetamt.Text);
                double change = paid - net;
                lblchange.Text = "change:" + change;
            }
            else
            {
                lblchange.Text = "Change:0";
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbmode.Text == "Cash")
            {
                txtcno.Text = "0";
                txtcname.Clear();
                txtcname.Focus();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txttotalamt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
