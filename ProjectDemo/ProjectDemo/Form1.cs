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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //method called after loading form in memory
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString="server=.\\sqlexpress;database=db1;Integrated Security=true";
            //server=servername
            //database=databasename
            //integrated security=true <=== use windows authentication
            //key=value;key=value;key=value

            cn.Open(); //Connect to SQL Sever using Connection String

            SqlDataAdapter da = new SqlDataAdapter("select * from stud",cn);
            DataTable dt = new DataTable();
            da.Fill(dt); //Executes Select command via cn and fill its result in DataTable

            dg1.DataSource = dt;

            cn.Close();
        }
    }
}
