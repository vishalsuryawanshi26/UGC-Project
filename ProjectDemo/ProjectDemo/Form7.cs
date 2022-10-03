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
    public partial class Form7 : Form
    {
        DBClass db = new DBClass();
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string roll = txtroll.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string btnval = btnsave.Text; //Save or Update
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@roll",roll);
            dic.Add("@name",name);
            dic.Add("@address",address);

            if (btnval == "Save")
            {
                db.Execute("Insert into Stud values(@roll,@name,@address)",dic);
            }
            else
            {
                db.Execute("Update Stud set Name=@name,Address=@address where RollNo=@roll", dic);  
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
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@roll", roll);
            db.Execute("delete from stud where rollno=@roll",dic);
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
            //db.ShowReport(new CrystalReport2(), "Select * from Stud", "Stud");
        }

        private void cmbfield_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
