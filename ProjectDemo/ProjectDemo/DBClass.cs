using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ProjectDemo
{
    class DBClass
    {
        SqlConnection cn;
        public void Connect()
        {
            cn = new SqlConnection("server=.\\sqlexpress;database=db1;integrated security=true");
            cn.Open();
        }
        public void Close()
        {
            cn.Close();
        }
        public void Execute(string sql)
        {
            Connect();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery(); //Executes Insert,Update and delete command
            Close();
        }
        public void Execute(string sql,Dictionary<string,object>dic)
        {
            Connect();
            SqlCommand cmd = new SqlCommand(sql, cn);
            foreach (string key in dic.Keys)
            {
                cmd.Parameters.AddWithValue(key, dic[key]);
            }
            cmd.ExecuteNonQuery(); //Executes Insert,Update and delete command
            Close();
        }
        public DataTable GetTable(string sql)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt); //executes select command via cn and fills its result in dt
            Close();
            return dt;
        }
        public void FillGrid(DataGridView dg, string sql)
        {
            DataTable dt = GetTable(sql);
            dg.DataSource = dt;
        }
        public DataSet1 GetTable(string sql,String table)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataSet1 ds=new DataSet1();
            //da.Fill(dt);
            //da.Fill(DataSet ds,String tablename)
            //executes select command via cn and fills its result in DataSet1's given 'Table'
            da.Fill(ds,table); 
            Close();
            return ds;
        }
        //db.ShowReport(new CrystalReport1(),"select * from stud","Stud");
         public void ShowReport(ReportClass rpt, String sql, String table)
         {
             DataSet1 ds=GetTable(sql,table);
             rpt.SetDataSource(ds);
             ReportForm f = new ReportForm();
             f.crystalReportViewer1.ReportSource = rpt;
             f.Show();//Show Report Form
         }

    }
}
