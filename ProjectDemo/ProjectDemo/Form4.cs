using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO; //File==> provides static method for reading and writing to file

namespace ProjectDemo
{
    public partial class Form4 : Form
    {
        SqlConnection cn;
        string fname;
        public Form4()
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
                //Photo Data ==> Binary data ==> Byte Array
                byte[] b=File.ReadAllBytes(fname); //static byte[] ReadAllBytes(String filepath)
                cmd.Parameters.AddWithValue("@photo",b);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Update StudPhoto set Name=@name,Address=@address,Photo=@photo where RollNo=@roll", cn);
                cmd.Parameters.AddWithValue("@roll", txtroll.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                //Photo Data ==> Binary data ==> Byte Array
                byte[] b = File.ReadAllBytes(fname); //static byte[] ReadAllBytes(String filepath)
                cmd.Parameters.AddWithValue("@photo", b);
                cmd.ExecuteNonQuery();
                
            }
            FillGrid("select * from studphoto");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txtname.Clear();
            txtaddress.Clear();
            pictureBox1.Image = null; //No Image
            txtroll.ReadOnly = false;
            btnsave.Text = "Save";
            txtroll.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("server=.\\sqlexpress;database=db1;integrated security=true");
            cn.Open();
            cmbfield.SelectedIndex = 0;  //-1 means not selected
            FillGrid("select * from studphoto");
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
            //db.Execute("delete from stud where rollno=" + roll);
            //db.FillGrid(dg1, "select * from stud");
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string roll = dg1.CurrentRow.Cells[0].Value.ToString();
            string name = dg1.CurrentRow.Cells[1].Value.ToString();
            string address = dg1.CurrentRow.Cells[2].Value.ToString();
            byte[] b = (byte[])dg1.CurrentRow.Cells[3].Value; //Convert from object to byte[]
            txtroll.Text = roll;
            txtname.Text = name;
            txtaddress.Text = address;
            //Steps
            //1. Write byte array to file (temp file)
            //2. Show Image file in PictureBox
            fname=Path.GetTempFileName(); //returns temp file path
            File.WriteAllBytes(fname, b);
            pictureBox1.Image = Image.FromFile(fname);
            btnsave.Text = "Update";
            txtroll.ReadOnly = true;
            txtname.Focus();

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            //db.ShowReport(new CrystalReport1(), "select * from stud", "Stud");
            //db.ShowReport(new CrystalReport1(), "Select * from Stud", "Stud");
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose Student Image";
            fd.Filter = "Image Files(*.jpg)|*.jpg";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fname=fd.FileName;
                MessageBox.Show(fname);
                //pictureBox1.Image=Image class object;
                //Image class has static method (FromFile) to create Image class object based on filename
                pictureBox1.Image = Image.FromFile(fname);

            }
            //When u click on open button, it returns DialogResult.OK 
            //When u click on cancel button, it returns DialogResult.Cancel 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
