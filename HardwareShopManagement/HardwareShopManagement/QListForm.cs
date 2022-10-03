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
    public partial class QListForm : Form
    {
         DBClass db=new DBClass();
         public QListForm()
        {
            InitializeComponent();
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (dg1.CurrentRow != null)
            {
                if(MessageBox.Show("Do you want to remove selected Material Receipt?","Confirm Remove",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==System.Windows.Forms.DialogResult.Yes)
                {
                    string no = dg1.CurrentRow.Cells[0].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@no", no);
                    db.Execute("delete from Quotation where MaterialReceiptNo=@no", dic);
                    db.FillGrid(dg1, "select * from Quotation");
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
                string qno = dg1.CurrentRow.Cells[0].Value.ToString();
                QForm f = new QForm(qno);
                f.ShowDialog();
                db.FillGrid(dg1, "select * from Quotation");
            }
            else
            {
                MessageBox.Show("Please select row to edit", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void QListForm_Load(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from Quotation");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load_2(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "Select * from Quotation where " + cmbfield.Text + " like'%" + txtsearch.Text + "%'");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new QReport(), "select * from Quotation", "Quotation");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            QForm f = new QForm();
            f.ShowDialog();
            db.FillGrid(dg1, "select * from Quotation");
        }

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dg1.CurrentRow!=null)
            {
                String QNo=dg1.CurrentRow.Cells[0].Value.ToString();
                db.ShowReport (new Q2Report(),"select * from  QView where QNo="+QNo,"QView");
            }
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from Quotation where " + cmbfield.Text + " like '%" + txtsearch.Text + "%'");
        }
    }
}
