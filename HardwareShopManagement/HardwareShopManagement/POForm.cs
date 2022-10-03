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
    public partial class POForm : Form
    {
         DBClass db=new DBClass();
         SupplierForm f;
         ProductForm p;
         public POForm()
        {
            InitializeComponent();
            txtno.Text = db.GetID("PONo");
        }
         public POForm(string no)
         {
             InitializeComponent();
             DataTable dt = db.GetTable("Select * from PO where PONo=" +no);
             if (dt.Rows.Count > 0)
             {
                 txtno.Text = dt.Rows[0]["PONo"].ToString();
                 dtpdate.Value=DateTime.Parse(dt.Rows[0]["PODate"].ToString());
                 txtsuppno.Text=dt.Rows[0]["SuppNo"].ToString();
                 txtsuppname.Text=dt.Rows[0]["SuppName"].ToString();
                 txttransport.Text=dt.Rows[0]["Transport"].ToString();
                 txtprepared.Text=dt.Rows[0]["PreparedBy"].ToString();

                 db.FillListView(listView1, "select ProdNo,ProdName,Qty,Unit from POItems where PONo=" + no);

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

        
        private void POForm_Load_1(object sender, EventArgs e)
        {
            
            dtpdate.Focus();
            
            db.Close();
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtsuppname, "SuppName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtprepared, "PreparedBy", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txttransport, "Transport", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtpname, "ProdName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtqty, "Qty", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtunit, "Unit", new string[] { "Empty" });
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
            string qty = txtqty.Text;
            string unit = txtunit.Text;

            //listView1.Items.Add(ListViewItem Item);
            ListViewItem lt = new ListViewItem();
            //It consists of parent item and parent has child/sub items
            lt.Text = pno;
            lt.SubItems.Add(pname);
            lt.SubItems.Add(qty);
            lt.SubItems.Add(unit);
            listView1.Items.Add(lt);
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
            string transport = txttransport.Text;
            string prepared = txtprepared.Text;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@pdate", pdate);
            dic.Add("@suppno", suppno);
            dic.Add("@suppname", suppname);
            dic.Add("@transport", transport);
            dic.Add("@prepared", prepared);

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into PO values(@no,@pdate,@suppno,@suppname,@transport,@prepared)", dic);
                dic = new Dictionary<string, object>();
                foreach (ListViewItem lt in listView1.Items)
                {
                    dic.Add("@no", no);
                    dic.Add("@prno", lt.Text);
                    dic.Add("@prname", lt.SubItems[1].Text);
                    dic.Add("@qty", lt.SubItems[2].Text);
                    dic.Add("@unit", lt.SubItems[3].Text);
                    db.Execute("Insert into POItems values(@no,@prno,@prname,@qty,@unit)", dic);
                    dic.Clear();
                }
                MessageBox.Show("Purchase Order Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("PONo");
                Close();
            }
            else
            {
                 db.Execute("Update PO set PODate=@pdate,SuppNo=@suppno,SuppName=@suppname,Transport=@transport,PreparedBy=@prepared where PONo=@no", dic);
                 db.Execute("Delete from POItems where PONo=" + no);
                 
                 dic = new Dictionary<string, object>();
                 foreach (ListViewItem lt in listView1.Items)
                 {
                     dic.Add("@no", no);
                     dic.Add("@pno", lt.Text);
                     dic.Add("@pname", lt.SubItems[1].Text);
                     dic.Add("@qty", lt.SubItems[2].Text);
                     dic.Add("@unit", lt.SubItems[3].Text);
                     db.Execute("Insert into POItems values(@no,@pno,@pname,@qty,@unit)", dic);
                     dic.Clear();
                 }
                 MessageBox.Show("Purchase Order Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //db.UpdateId("PONo");
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
    }
}
