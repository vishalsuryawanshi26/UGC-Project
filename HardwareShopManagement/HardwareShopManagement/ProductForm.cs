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
using System.IO;

namespace HardwareShopManagement
{
    public partial class ProductForm : Form
    {
         DBClass db=new DBClass();
         //string fname;
         //byte b;
         public ProductForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtno.Text=db.GetID("ProdNo");
            txtname.Clear();
            cmbcategory.SelectedIndex = -1;
            cmbcompany.SelectedIndex = -1;
            txtprice.Clear();
            txtqty.Clear();
            txtunit.Clear();
            txtspec.Clear();
            //pictureBox2.Image = null;
            btnsave.Text = "Save";
            txtno.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string no = txtno.Text;
            string name = txtname.Text;
            string category = cmbcategory.SelectedValue.ToString();
            string company = cmbcompany.SelectedValue.ToString();
            string price = txtprice.Text;
            string qty = txtqty.Text;
            string unit = txtunit.Text;
            string spec = txtspec.Text;
     
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@no", no);
            dic.Add("@name", name);
            dic.Add("@category", category);
            dic.Add("@company", company);
            dic.Add("@price", price);
            dic.Add("@qty", qty);
            dic.Add("@unit", unit);
            dic.Add("@spec", spec);
            //dic.Add("@fname", File.ReadAllBytes(fname));

            if (btnsave.Text == "Save")
            {
                db.Execute("Insert into Product values(@no,@name,@category,@company,@price,@qty,@unit,@spec)", dic);
                MessageBox.Show("Product Product Created Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.UpdateId("ProdNo");
            }
                
            else
            {
                
                db.Execute("Update Product set ProdName=@name,Category=@category,Company=@company,Price=@price,Qty=@qty,Unit=@unit,Specification=@spec where ProdNo=@no", dic);
                MessageBox.Show("Product Updated Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.FillGrid(dg1, "select * from Product");
            txtname.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected Product?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string no = dg1.CurrentRow.Cells[0].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@no", no);
                    db.Execute("delete from Product where ProdNo=@no", dic);
                    db.FillGrid(dg1, "select * from Product");
                    db.UpdateId("ProdNo");
                }
            }
        }

        /*private void btnedit_Click(object sender, EventArgs e)
        {
            if (dg1.CurrentRow != null)    //row is selected in Gredview
            {
                string user = dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from Product where UserName=" + user);
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
                DataTable dt = db.GetTable("select * from Product where ProdNo=" + no);
                txtno.Text = no;
                txtname.Text = dt.Rows[0][1].ToString();
                cmbcategory.SelectedValue = dt.Rows[0][2].ToString();
                cmbcompany.SelectedValue = dt.Rows[0][3].ToString();
                txtprice.Text = dt.Rows[0][4].ToString();
                txtqty.Text = dt.Rows[0][5].ToString();
                txtunit.Text = dt.Rows[0][6].ToString();
                txtspec.Text = dt.Rows[0][7].ToString();
                //byte[] b = (byte[])dt.Rows[0][8];
                //fname = Path.GetTempFileName();
                //File.WriteAllBytes(fname, b);
                //pictureBox2.Image = Image.FromFile(fname);

                btnsave.Text = "Update";
                txtname.Focus();
            }
            else
            {
                MessageBox.Show("Please select row to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProductForm_Load_1(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from Product");
            txtno.Text = db.GetID("ProdNo");
            db.FillCombo(cmbcategory, "select * from Category", "CategoryName", "CategoryName");
            db.FillCombo(cmbcompany, "select * from Company", "CompanyName", "CompanyName");
            txtname.Focus();
            
            db.Close();
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtname, "ProdName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtprice, "Price", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtqty, "Qty", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtunit, "Unit", new string[] { "Empty" });
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load_2(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "Select * from Product where " + cmbsearch.Text + " like'%" + txtsearch.Text + "%'");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new ProductReport(), "select * from Product", "Product");
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose Product Image";
            fd.Filter = "Image Files(*.jpg)|*.jpg";
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                fname = fd.FileName;//returns selected file path
                pictureBox2.Image = Image.FromFile(fname);
            }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
