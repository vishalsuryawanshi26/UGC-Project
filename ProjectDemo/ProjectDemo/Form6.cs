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
    public partial class Form6 : Form
    {
        SqlConnection cn;
        string fname;
        public Form6()
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
                SqlCommand cmd = new SqlCommand("Insert into StudPhoto values(@roll,@name,@address,@photo)", cn);
                cmd.Parameters.AddWithValue("@roll", txtroll.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                byte[] b = File.ReadAllBytes(fname);
                cmd.Parameters.AddWithValue("@photo",b);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Update StudPhoto set Name=@name,Address=@address,Photo=@photo where RollNo=@roll", cn);
                cmd.Parameters.AddWithValue("@roll", txtroll.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                byte[] b = File.ReadAllBytes(fname);
                cmd.Parameters.AddWithValue("@photo", b);
                cmd.ExecuteNonQuery();
                
            }
           FillGrid("select * from StudPhoto");
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
            cn=new SqlConnection("server=.\\sqlexpress;database=db1;integrated security=true");
            cn.Open();
            cmbfield.SelectedIndex = 0;  //-1 means not selected
            FillGrid("select * from StudPhoto");
        }
        void FillGrid(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dg1.DataSource = dt;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            //db.FillGrid(dg1, "select * from stud where "+cmbfield.Text+" like '%"+txtsearch.Text+"%'");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string roll = dg1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand("delete from studphoto where Rollno=@roll", cn);
            cmd.Parameters.AddWithValue("@roll", roll);
            cmd.ExecuteNonQuery();
            FillGrid("Select * from StudPhoto");
            //db.FillGrid(dg1, "select * from stud");
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
            ReportForm f = new ReportForm();
            f.ShowStudphotoReport(cn);
            f.Show();
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
