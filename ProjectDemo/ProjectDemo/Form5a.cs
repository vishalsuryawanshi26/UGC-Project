using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace ProjectDemo
{
    public partial class Form5a : Form
    {
        DBClass db = new DBClass();
        string fname;
        public Form5a()
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
            byte[] b = File.ReadAllBytes(fname);
            dic.Add("@photo", b);

            if (btnval == "Save")
            {
                db.Execute("Insert into StudPhoto values(@roll,@name,@address,@photo)", dic);
                MessageBox.Show("Student Record is Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                db.Execute("Update StudPhoto set Name=@name,Address=@address,Photo=@photo where RollNo=@roll", dic);
                MessageBox.Show("Student Record is Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           db.FillGrid(dg1,"select * from StudPhoto");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txtname.Clear();
            txtaddress.Clear();
            pictureBox1.Image = null;
            txtroll.ReadOnly = false;
            btnsave.Text = "Save";
            txtroll.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbfield.SelectedIndex = 0;  //-1 means not selected
            db.FillGrid(dg1,"select * from StudPhoto");
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from studhoto where "+cmbfield.Text+" like '%"+txtsearch.Text+"%'");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //check whether row is selected or not
            if (dg1.CurrentRow != null)
            {
                //get delete confirmation
                if (MessageBox.Show("Do you want to remove selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {

                    //when you click on yes button ==> DialogResult.Yes
                    //when you click on No button ==> DialogResult.No
                    string roll = dg1.CurrentRow.Cells[0].Value.ToString();
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@roll", roll);
                    db.Execute("delete from studphoto where Rollno=@roll", dic);

                    //db.FillGrid("Select * from StudPhoto");
                    db.FillGrid(dg1, "select * from StudPhoto");
                }
            }
            else
            {
                MessageBox.Show("Please select row", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            string roll = dg1.CurrentRow.Cells[0].Value.ToString();
            string name = dg1.CurrentRow.Cells[1].Value.ToString();
            string address = dg1.CurrentRow.Cells[2].Value.ToString();
            byte[] b = (byte[])dg1.CurrentRow.Cells[3].Value;
            txtroll.Text = roll;
            txtname.Text = name;
            txtaddress.Text = address;
            fname = Path.GetTempFileName();
            File.WriteAllBytes(fname, b);
            pictureBox1.Image = Image.FromFile(fname);
            btnsave.Text = "Update";
            txtroll.ReadOnly = true;
            txtname.Focus();

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CrystalReport2(), "select * from studphoto", "StudPhoto");
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose Student Image";
            fd.Filter = "Image Files(*jpg)|*.jpg";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fname = fd.FileName;
                MessageBox.Show(fname);
                pictureBox1.Image = Image.FromFile(fname);
            }
        }
    }
}
