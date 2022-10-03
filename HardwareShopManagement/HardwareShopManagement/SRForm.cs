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
    public partial class SRForm : Form
    {
         DBClass db=new DBClass();
         CustomerForm f;
         ProductForm p;
         string oldamt;
         public SRForm()
        {
            InitializeComponent();
            txtno.Text = db.GetID("SRNo");
        }
         public SRForm(string SRNo)
         {
             InitializeComponent();
             DataTable dt = db.GetTable("Select * from SR where SRNo=" +SRNo);
             if (dt.Rows.Count > 0)
             {
                 txtno.Text = dt.Rows[0]["SRNo"].ToString();
                 dtpdate.Value=DateTime.Parse(dt.Rows[0]["SRDate"].ToString());
                 txtcustno.Text=dt.Rows[0]["CustNo"].ToString();
                 txtcustname.Text=dt.Rows[0]["CustName"].ToString();
                 txtfinal.Text=dt.Rows[0]["SRAmt"].ToString();
                 oldamt = txtfinal.Text;
                 db.FillListView(listView1, "select ProdNo,ProdName,Price,Qty,Unit,Total from SRItems where SRNo=" +SRNo );

                 btnsave.Text = "Update";
                 txtcustname.Focus();
             }

         }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void PRForm_Load(object sender, EventArgs e)
        {
            
            dtpdate.Focus();
            
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
                txtcustno.Text = dg.CurrentRow.Cells[0].Value.ToString();
                txtcustname.Text = dg.CurrentRow.Cells[1].Value.ToString();
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
            string total = (double.Parse(price) * int.Parse(qty)).ToString();

            //listView1.Items.Add(ListViewItem Item);
            ListViewItem lt = new ListViewItem();
            //It consists of parent item and parent has child/sub items
            lt.Text = pno;
            lt.SubItems.Add(pname);
            lt.SubItems.Add(price);
            lt.SubItems.Add(qty);
            lt.SubItems.Add(unit);
            lt.SubItems.Add(total);
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
            txtfinal.Text = total.ToString();
        }

        private void POForm_KeyDown(object sender, KeyEventArgs e)
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
            string no = txtno.Text;
            string pdate = dtpdate.Value.ToString("yyyy-MM-dd");
            string CustNo = txtcustno.Text;
            string CustName = txtcustname.Text;
            string finalamt = txtfinal.Text;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@pdate", pdate);
            dic.Add("@CustNo", CustNo);
            dic.Add("@CustName", CustName);
            dic.Add("@finalamt", finalamt);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into SR values(@no,@pdate,@CustNo,@CustName,@finalamt)", dic);
                db.Execute("Update Customer Set ACBalance=ACBalance-" + finalamt + "where CustNo=" + CustNo);
                
                dic = new Dictionary<string, object>();
                foreach (ListViewItem lt in listView1.Items)
                {
                    dic.Add("@no", no);
                    dic.Add("@pno", lt.Text);
                    dic.Add("@pname", lt.SubItems[1].Text);
                    dic.Add("@price",lt.SubItems[2].Text);
                    dic.Add("@qty", lt.SubItems[3].Text);
                    dic.Add("@unit", lt.SubItems[4].Text);
                    dic.Add("@total",lt.SubItems[5].Text);

                    db.Execute("Insert into SRItems values(@no,@pno,@pname,@price,@qty,@unit,@total)", dic);
                    db.Execute("Update Product Set Qty=Qty-" + lt.SubItems[3].Text + "where ProdNo=" + lt.Text);
                    dic.Clear();
                }
                MessageBox.Show("Sell Returns Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("SRNo");
                Close();
            }
            else
            {
                db.Execute("Update Customer Set ACBalance=AcBalance+" + oldamt + "where CustNo=" + CustNo);
                db.Execute("Update SR set SRDate=@pdate,CustNo=@CustNo,CustName=@CustName,SRAmt=@finalamt where SRNo=@no", dic);
                db.Execute("Update Customer set ACBalance=ACBalance+" + finalamt + "where CustNo=" + CustNo);
                DataTable dt = db.GetTable("Select * from SRItems where SRNo=" +no);
                foreach(DataRow dr in dt.Rows)
                {
                    db.Execute("Update Product Set Qty=Qty-" + dr[4].ToString() + "where ProdNo=" + dr[1].ToString());
                }
                db.Execute("Delete from SRItems where SRNo=" +no );
                 
                 dic = new Dictionary<string, object>();
                 foreach (ListViewItem lt in listView1.Items)
                 {
                     dic.Add("@no", no);
                     dic.Add("@pno", lt.Text);
                     dic.Add("@pname", lt.SubItems[1].Text);
                     dic.Add("@price", lt.SubItems[2].Text);
                     dic.Add("@qty", lt.SubItems[3].Text);
                     dic.Add("@unit", lt.SubItems[4].Text);
                     dic.Add("@total", lt.SubItems[5].Text);
                     db.Execute("Insert into SRItems values(@no,@pno,@pname,@price,@qty,@unit,@total)", dic);
                     db.Execute("Update Product set Qty=Qty+" + lt.SubItems[3].Text + "where ProdNo=" + lt.Text);
                     dic.Clear();
                 }
                 MessageBox.Show("Sell Return Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 db.UpdateId("SRNo");
                 Close(); 
            }
            txtcustname.Focus();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PRForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtno.Text = db.GetID("SRNo");
            txtcustno.Clear();
            txtcustname.Clear();
            dtpdate.Value = DateTime.Now;
            txtfinal.Clear();
            listView1.Items.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }
    }
}
