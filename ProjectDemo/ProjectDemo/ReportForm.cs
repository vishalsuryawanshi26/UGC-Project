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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
        public void ShowStudphotoReport(SqlConnection cn)
        {
            DataSet1 ds = new DataSet1();
            DataTable dt=ds.Tables["StudPhoto"]; //returns Datatable object from dataset whose name is Stud
            SqlDataAdapter da = new SqlDataAdapter("select * from studphoto", cn);
            da.Fill(dt);

            //Steps
            //1. Create an object of CrystalReport class
            CrystalReport2 rpt = new CrystalReport2();
            //2. Set its DataSource
            rpt.SetDataSource(ds);
            //3. Set Crystal Report Object to CrystalReportViewer
            crystalReportViewer1.ReportSource = rpt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        public void ShowStudReport(SqlConnection cn)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from StudPhoto", cn);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "StudPhoto");
            CrystalReport2 obj = new CrystalReport2();
            obj.SetDataSource(ds);
            crystalReportViewer1.ReportSource = obj;
        }
    }
}
