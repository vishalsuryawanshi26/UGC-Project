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
    public partial class PRForm : Form
    {
         DBClass db=new DBClass();
         SupplierForm f;
         ProductForm p;
         string oldamt;
         int qty1;
         public PRForm()
        {
            InitializeComponent();
            txtno.Text = db.GetID("PRNo");
        }
         public PRForm(string PRNo)
         {
             InitializeComponent();
             DataTable dt = db.GetTable("Select * from PR where PRNo=" +PRNo);
             if (dt.Rows.Count > 0)
             {
                 txtno.Text = dt.Rows[0]["PRNo"].ToString();
                 dtpdate.Value=DateTime.Parse(dt.Rows[0]["PRDate"].ToString());
                 txtsuppno.Text=dt.Rows[0]["SuppNo"].ToString();
                 txtsuppname.Text=dt.Rows[0]["SuppName"].ToString();
                 txtfinal.Text=dt.Rows[0]["PRAmt"].ToString();
                 oldamt = txtfinal.Text;
                 db.FillListView(listView1, "select ProdNo,ProdName,Price,Qty,Unit,Total from PRItems where PRNo=" +PRNo );

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

        
        private void PRForm_Load(object sender, EventArgs e)
        {
            
            dtpdate.Focus();
            
            db.Close();
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtsuppname, "SuppName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtpname, "ProdName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtprice, "Price", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtqty, "Qty", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtunit, "Unit", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtfinal, "Total", new string[] { "Empty" });
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
                qty1 = int.Parse(dg.CurrentRow.Cells[5].Value.ToString());
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

            if (int.Parse(qty) > qty1)
            {
                MessageBox.Show("Entered Quantity " + qty + " must be less than available quantiy " + qty1);
                return;
            }


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
            string suppno = txtsuppno.Text;
            string suppname = txtsuppname.Text;
           // string total = txtfinal.Text;
            string final = txtfinal.Text;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@pdate", pdate);
            dic.Add("@suppno", suppno);
            dic.Add("@suppname", suppname);
            //dic.Add("@total", total);
            dic.Add("@final", final);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into PR values(@no,@pdate,@suppno,@suppname,@final)", dic);
                db.Execute("Update Supplier Set ACBalance=ACBalance-" + final + " where SuppNo=" + suppno);
                
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

                    db.Execute("Insert into PRItems values(@no,@pno,@pname,@price,@qty,@unit,@total)", dic);
                    db.Execute("Update Product Set Qty=Qty-" + lt.SubItems[3].Text + " where ProdNo=" + lt.Text);
                    dic.Clear();
                }
                MessageBox.Show("PR Returns Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("PRNo");
                Close();
            }
            else
            {
                db.Execute("Update Supplier Set ACBalance=AcBalance+" + oldamt + " where SuppNo=" + suppno);
                db.Execute("Update PR set PRDate=@pdate,SuppNo=@suppno,SuppName=@suppname,PRAmt=@final where PRNo=@no", dic);
                db.Execute("Update Supplier set ACBalance=ACBalance-" + final + " where SuppNo=" + suppno);
                DataTable dt = db.GetTable("Select * from PRItems where PRNo=" +no);
                foreach(DataRow dr in dt.Rows)
                {
                    db.Execute("Update Product Set Qty=Qty+"+dr[4].ToString()+" where ProdNo="+dr[1].ToString());
                }
                db.Execute("Delete from PRItems where PRNo=" +no );
                 
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
                     db.Execute("Insert into PRItems values(@no,@pno,@pname,@price,@qty,@unit,@total)", dic);
                     db.Execute("Update Product set Qty=Qty-" + lt.SubItems[3].Text + "where ProdNo=" + lt.Text);
                     dic.Clear();
                 }
                 MessageBox.Show("Purchase Order Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 db.UpdateId("PRNo");
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

        private void PRForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtno.Text = db.GetID("PRNo");
            txtsuppno.Clear();
            txtsuppname.Clear();
            dtpdate.Value = DateTime.Now;
            txtfinal.Clear();
            listView1.Items.Clear();
            btnsave.Text = "Save";
            txtno.Focus();
        }
    }
}
