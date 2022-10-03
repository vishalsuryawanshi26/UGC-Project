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
    public partial class MRForm : Form
    {
         DBClass db=new DBClass();
         SupplierForm f;
         ProductForm p;
         POListForm q;
         bool add = true;
         int index;
         public MRForm()
        {
            InitializeComponent();
            txtno.Text = db.GetID("MRNo");
        }
         public MRForm(string MRNo)
         {
             InitializeComponent();
             DataTable dt = db.GetTable("Select * from MaterialReceipt where MRNo=" +MRNo);
             if (dt.Rows.Count > 0)
             {
                 txtno.Text = dt.Rows[0]["MRNo"].ToString();
                 dtpmdate.Value=DateTime.Parse(dt.Rows[0]["MRDate"].ToString());
                 txtsuppno.Text=dt.Rows[0]["SuppNo"].ToString();
                 txtsuppname.Text=dt.Rows[0]["SuppName"].ToString();
                 //txtbno.Text=dt.Rows[0]["Transport"].ToString();
                 //txtprepared.Text=dt.Rows[0]["PreparedBy"].ToString();

                 db.FillListView(listView1, "select ProdNo,ProdName,Price,Qty,Unit,Total from MaterialReceiptItems where MRNo=" + MRNo);

                 btnsave.Text = "Update";
                 txtsuppname.Focus();
             }

         }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void MRForm_Load(object sender, EventArgs e)
        {
            
            dtpmdate.Focus();
            
            db.Close();
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtbno, "BillNo", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtsuppname, "SuppName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtpname, "ProdName", new string[] { "Empty" });
            ValidationUtil.CheckDateBeforeCombo(dtpbdate, "BillDate", 5);
            ValidationUtil.ApplyRules(txtprice, "Price", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtqty, "Qty", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtunit, "Unit", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtdisc, "DiscP", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtdiscamt, "DiscAmt", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtgst, "GSTP", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtgstamt, "GSTAmt", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtnetamt, "NetAmt", new string[] { "Empty" });
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
            f = new SupplierForm();
            f.dg1.Click += new EventHandler(dg1_Click);
            f.Show();
        }

        void dg1_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentRow != null)
            {
                txtsuppno.Text = dg.CurrentRow.Cells[0].Value.ToString();
                txtsuppname.Text = dg.CurrentRow.Cells[1].Value.ToString();
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            string pno = txtpno.Text;
            string pname = txtpname.Text;
            string price = txtprice.Text;
            string qty = txtqty.Text;
            string unit = txtunit.Text;
            double total = double.Parse(price) * int.Parse(qty);


            //listView1.Items.Add(ListViewItem Item);
            ListViewItem lt = new ListViewItem();

            if (add == false)
            {
                lt = listView1.Items[index];
                lt.Text = pno;
                lt.SubItems[1].Text=pname;
                lt.SubItems[2].Text=price;
                lt.SubItems[3].Text=qty;
                lt.SubItems[4].Text=unit;
                lt.SubItems[5].Text=total.ToString();

                add = true;
            }
            else
            {
                lt.Text = pno;
                lt.SubItems.Add(pname);
                lt.SubItems.Add(price);
                lt.SubItems.Add(qty);
                lt.SubItems.Add(unit);
                lt.SubItems.Add(total.ToString());
            
                //It consists of parent item and parent has child/sub items
                //lt.SubItems.Add(total.ToString());
                listView1.Items.Add(lt);
            }
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

        private void MRForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                //MessageBox.Show("F3 Pressed");
                listView1.FocusedItem.Remove();
                listView1.Refresh();
            }
            if (e.KeyCode == Keys.F4)
            {
                add = false;
                //MessageBox.Show("F3 Pressed");
                index = listView1.FocusedItem.Index;
                ListViewItem lt = listView1.FocusedItem;
                txtpno.Text = lt.Text;
                txtpname.Text = lt.SubItems[1].Text;
                txtprice.Text = lt.SubItems[2].Text;
                txtqty.Text = lt.SubItems[3].Text;
                txtunit.Text = lt.SubItems[4].Text;
                
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string MRNo = txtno.Text;
            string pmdate = dtpmdate.Value.ToString("yyyy-MM-dd");
            string billno = txtbno.Text;
            string pdate = dtpbdate.Value.ToString("yyyy-MM-dd");
            string suppno = txtsuppno.Text;
            string suppname = txtsuppname.Text;
            string pono = txtpono.Text;
            string totalamt = txttotalamt.Text;
            string discp = txtdisc.Text;
            string discamt = txtdiscamt.Text;
            string gstp = txtgst.Text;
            string gstamt = txtgstamt.Text;
            string netamt = txtnetamt.Text;
            //string transport = txtbno.Text;
            //string prepared = txtprepared.Text;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@MRNo", MRNo);
            dic.Add("@pmdate", pmdate);
            dic.Add("@billno", billno);
            dic.Add("@pdate", pdate);
            dic.Add("@suppno", suppno);
            dic.Add("@suppname", suppname);
            dic.Add("@pono", pono);
            dic.Add("@totalamt", totalamt);
            dic.Add("@discp", discp);
            dic.Add("@discamt", discamt);
            dic.Add("@gstp", gstp);
            dic.Add("@gstamt", gstamt);
            dic.Add("@netamt", netamt);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into MaterialReceipt values(@MRNo,@pmdate,@billno,@pdate,@suppno,@suppname,@pono,@totalamt,@discp,@discamt,@gstp,@gstamt,@netamt)", dic);
                dic = new Dictionary<string, object>();
                foreach (ListViewItem lt in listView1.Items)
                {
                    dic.Add("@MRNo", MRNo);
                    dic.Add("@prno", lt.Text);
                    dic.Add("@prname", lt.SubItems[1].Text);
                    dic.Add("@price", lt.SubItems[2].Text);
                    dic.Add("@qty", lt.SubItems[3].Text);
                    dic.Add("@unit", lt.SubItems[4].Text);
                    dic.Add("@total", lt.SubItems[5].Text);
                    db.Execute("Insert into MaterialReceiptItems values(@MRNo,@prno,@prname,@price,@qty,@unit,@total)", dic);
                    dic.Clear();
                }
                MessageBox.Show("MaterialReceipt Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("MRNo");
                Close();
            }
            else
            {
                 db.Execute("Update MaterialReceipt set MRDate=@pmdate,BillNo=@billno,BillDate=@pdate,SuppNo=@suppno,SuppName=@suppname,PONo=@pono,TotalAmt=@totalamt,DiscP=@discp,DiscAmt=@discamt,GSTP=@gstp,GSTAmt=@gstamt,NetAmt=@netamt where MRNo=@MRNo", dic);
                 db.Execute("Delete from MaterialReceiptItems where MRNo=" + MRNo);
                 
                 dic = new Dictionary<string, object>();
                 foreach (ListViewItem lt in listView1.Items)
                 {
                     dic.Add("@MRNo", MRNo);
                     dic.Add("@prno", lt.Text);
                     dic.Add("@prname", lt.SubItems[1].Text);
                     dic.Add("@price", lt.SubItems[2].Text);
                     dic.Add("@qty", lt.SubItems[3].Text);
                     dic.Add("@unit", lt.SubItems[4].Text);
                     dic.Add("@total", lt.SubItems[5].Text);
                     db.Execute("Insert into MaterialReceiptItems values(@MRNo,@prno,@prname,@price,@qty,@unit,@total)", dic);
                     dic.Clear();
                 }
                 MessageBox.Show("MaterialReceipt Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 db.UpdateId("MRNo");
                 Close(); 
            }
            txtsuppname.Focus();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MRForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnpo_Click(object sender, EventArgs e)
        {
            q = new POListForm();
            q.dg1.Click += new EventHandler(dg3_Click);
            q.Show();
        }
        void dg3_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentRow != null)
            {
                txtpono.Text = dg.CurrentRow.Cells[0].Value.ToString();
                db.FillListView(listView1, "select ProdNo,ProdName,Price,Qty,Unit,Total from POItemsView where PONo=" + txtpono.Text);
                
                
                if (q != null)
                {
                    q.Close();
                }
            }
        }

        private void txtdisc_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void txtgst_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }
        void CalculateNet()
        {
            double disc = 0;
            if (!string.IsNullOrEmpty(txtdisc.Text))
            {
                disc = double.Parse(txtdisc.Text);
            }
            double totalamt = double.Parse(txttotalamt.Text);
            double discamt = totalamt * (disc / 100);
            totalamt = totalamt - discamt;
            txtdiscamt.Text = discamt.ToString();

            double gst = 0;
            if (!string.IsNullOrEmpty(txtgst.Text))
            {
                gst = double.Parse(txtgst.Text);
            }
            double gstamt = totalamt * (gst / 100);
            txtgstamt.Text = gstamt.ToString();
            totalamt = totalamt + gstamt;
            txtnetamt.Text = totalamt.ToString();
        }

        private void txttotalamt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtno.Text = db.GetID("MRNo");
            txtpname.Clear();
            dtpbdate.Value = DateTime.Now;
            dtpmdate.Value = DateTime.Now;
            txtdisc.Clear();
            txtdiscamt.Clear();
            txtgst.Clear();
            txtgstamt.Clear();
            listView1.Items.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
