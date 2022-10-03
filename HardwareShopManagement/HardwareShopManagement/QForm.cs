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
    public partial class QForm : Form
    {
         DBClass db=new DBClass();
         SupplierForm f;
         ProductForm p;
         public QForm()
        {
            InitializeComponent();
            txtno.Text = db.GetID("QNo");
        }
         public QForm(string no)
         {
             InitializeComponent();
             DataTable dt = db.GetTable("Select * from Quotation where QNo=" +no);
             if (dt.Rows.Count > 0)
             {
                 txtno.Text = dt.Rows[0]["QNo"].ToString();
                 dtpmdate.Value=DateTime.Parse(dt.Rows[0]["QDate"].ToString());
                 txtcname.Text=dt.Rows[0]["Customer"].ToString();
                 txttotalamt.Text = dt.Rows[0]["BillAmt"].ToString();
                 txtdiscp.Text = dt.Rows[0]["DiscP"].ToString();
                 txtdiscamt.Text = dt.Rows[0]["DiscAmt"].ToString();
                 txtgstp.Text = dt.Rows[0]["GSTP"].ToString();
                 txtgstamt.Text = dt.Rows[0]["GSTAmt"].ToString();
                 txtnetamt.Text = dt.Rows[0]["NetAmt"].ToString();
                 db.FillListView(listView1, "select ProdNo,ProdName,Price,Qty,Unit,Total from QuotationItems where QNo=" + no);

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

        
        private void QForm_Load(object sender, EventArgs e)
        {
            
            dtpmdate.Focus();
            
            db.Close();
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtcname, "Customer", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtpname, "ProdName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtprice, "Price", new string[] { "Empty" });
            ValidationUtil.CheckDateBeforeCombo(dtpmdate, "QDate", 5);
            ValidationUtil.ApplyRules(txtqty, "Qty", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtunit, "Unit", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txttotalamt, "Total", new string[] { "Empty" });
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
                txtunit.Text = dg.CurrentRow.Cells[6].Value.ToString();
                txtprice.Text = dg.CurrentRow.Cells[4].Value.ToString();
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

        private void QForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                //MessageBox.Show("F3 Pressed");
                listView1.FocusedItem.Remove();
                listView1.Refresh();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string Qno = txtno.Text;
            string Qdate = dtpmdate.Value.ToString("yyyy-MM-dd");
            string cname = txtcname.Text;
            string billamt = txttotalamt.Text;
            string discp = txtdiscp.Text;
            string discamt = txtdiscamt.Text;
            string gstp = txtgstp.Text;
            string gstamt = txtgstamt.Text;
            string netamt = txtnetamt.Text;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@Qno", Qno);
            dic.Add("@Qdate", Qdate);
            dic.Add("@cname", cname);
            dic.Add("@billamt", billamt);
            dic.Add("@discp", discp);
            dic.Add("@discamt", discamt);
            dic.Add("@gstp", gstp);
            dic.Add("@gstamt", gstamt);
            dic.Add("@netamt", netamt);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into Quotation values(@Qno,@Qdate,@cname,@billamt,@discp,@discamt,@gstp,@gstamt,@netamt)", dic);
                dic = new Dictionary<string, object>();
                foreach (ListViewItem lt in listView1.Items)
                {
                    dic.Add("@Qno", Qno);
                    dic.Add("@prno", lt.Text);
                    dic.Add("@prname", lt.SubItems[1].Text);
                    dic.Add("@price",lt.SubItems[2].Text);
                    dic.Add("@qty", lt.SubItems[3].Text);
                    dic.Add("@unit", lt.SubItems[4].Text);
                    dic.Add("@total",lt.SubItems[5].Text);
                    db.Execute("Insert into QuotationItems values(@Qno,@prno,@prname,@price,@qty,@unit,@total)", dic);
                    dic.Clear();
                }
                MessageBox.Show("Purchase Order Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("QNo");
                Close();
            }
            else
            {
                 db.Execute("Update Quotation set QDate=@qdate,Customer=@cname,BillAmt=@billamt,Discp=@discp,DiscAmt=@discamt,GSTP=@gstp,GSTAmt=@gstamt,NetAmt=@netamt where QNo=@Qno", dic);
                 db.Execute("Delete from QuotationItems where QNo=" + Qno);
                 
                 dic = new Dictionary<string, object>();
                 foreach (ListViewItem lt in listView1.Items)
                 {
                     dic.Add("@Qno", Qno);
                     dic.Add("@prno", lt.Text);
                     dic.Add("@prname", lt.SubItems[1].Text);
                     dic.Add("@price",lt.SubItems[2].Text);
                     dic.Add("@qty", lt.SubItems[3].Text);
                     dic.Add("@unit", lt.SubItems[4].Text);
                     dic.Add("@total",lt.SubItems[5].Text);
                     db.Execute("Insert into QuotationItems values(@Qno,@prno,@prname,@price,@qty,@unit,@total)", dic);
                     dic.Clear();
                 }
                 MessageBox.Show("Quatation Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                //db.UpdateId("QNo");
                 Close(); 
            }
            txtcname.Focus();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MRForm_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {
        
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtno.Text = db.GetID("QNo");
            txtcname.Clear();
            dtpbdate.Value = DateTime.Now;
            txtdiscp.Clear();
            txtdiscamt.Clear();
            txtgstp.Clear();
            txtgstamt.Clear();
            listView1.Items.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {

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
    }
}
