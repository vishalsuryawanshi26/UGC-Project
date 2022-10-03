using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectDemo
{
    public partial class Form2 : Form
    {
        SqlConnection cn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString="server=.\\sqlexpress;database=db1;integrated security=true";
            cn.Open();
            FillGrid(); //Method call

        }
        void FillGrid(string sql="select * from stud") //Method Definition
        {
            //SqlDataAdapter da = new SqlDataAdapter("select * from stud", cn);
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dg1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string roll = txtroll.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string sql = String.Format("Insert into stud values({0},'{1}','{2}')", roll, name, address);
            MessageBox.Show(sql);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery(); //Executes Insert/Update/Delete command via connection
            FillGrid();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtroll.Focus();
        }

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Hi");
            string roll=dg1.CurrentRow.Cells[0].Value.ToString();
            string name = dg1.CurrentRow.Cells[1].Value.ToString();
            string address = dg1.CurrentRow.Cells[2].Value.ToString();
            txtroll.Text = roll;
            txtname.Text = name;
            txtaddress.Text = address;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string roll = txtroll.Text;
            string sql = "delete from stud where rollno=" + roll;
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            FillGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roll = txtroll.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string sql = string.Format("Update Stud set Name='{0}',Address='{1}' where RollNo={2}", name, address, roll);
            MessageBox.Show(sql);
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            FillGrid();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtsearch.Text;
            string field = cmbfield.Text;
            //if (!string.IsNullOrEmpty(search))
            //{
                String sql = string.Format("select * from stud where {0} like '%{1}%'", field, search);
                FillGrid(sql);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm();
            f.ShowStudReport(cn);
            f.Show(); //Display Report Form
        }
    }
}
