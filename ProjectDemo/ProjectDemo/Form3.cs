using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectDemo
{
    public partial class Form3 : Form
    {
        DBClass db = new DBClass();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roll = txtroll.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string btnval = btnsave.Text; //Save or Update

            if (btnval == "Save")
            {
                string sql = String.Format("Insert into Stud values({0},'{1}','{2}')", roll, name, address);
                db.Execute(sql);
            }
            else
            {
                string sql = String.Format("Update Stud set Name='{0}',Address='{1}' where RollNo={2}", name, address,roll);
                db.Execute(sql);
            }
            db.FillGrid(dg1, "select * from stud");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtroll.ReadOnly = false;
            btnsave.Text = "Save";
            txtroll.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbfield.SelectedIndex = 0;  //-1 means not selected
            db.FillGrid(dg1, "select * from stud");
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from stud where "+cmbfield.Text+" like '%"+txtsearch.Text+"%'");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string roll = dg1.CurrentRow.Cells[0].Value.ToString();
            db.Execute("delete from stud where rollno=" + roll);
            db.FillGrid(dg1, "select * from stud");
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string roll = dg1.CurrentRow.Cells[0].Value.ToString();
            string name = dg1.CurrentRow.Cells[1].Value.ToString();
            string address = dg1.CurrentRow.Cells[2].Value.ToString();
            txtroll.Text = roll;
            txtname.Text = name;
            txtaddress.Text = address;
            btnsave.Text = "Update";
            txtroll.ReadOnly = true;
            txtname.Focus();

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CrystalReport1(), "select * from stud", "Stud");
            //db.ShowReport(new CrystalReport1(), "Select * from Stud", "Stud");
        }
    }
}
