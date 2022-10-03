using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace HardwareShopManagement
{
    class DBClass
    {
        SqlConnection cn;
        public void Connect()
        {
            FileInfo f = new FileInfo("../../Database/HardwareShopManagementDB.mdf");
            //MessageBox.Show(f.FullName);
            cn = new SqlConnection("server=.\\sqlexpress;AttachDBFileName="+ f.FullName+";integrated security=true;user instance=true");
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
        public DataTable GetTable(string sql,Dictionary<string,object>dic)
        {
            Connect();
            SqlCommand cmd = new SqlCommand(sql, cn);
            foreach (string key in dic.Keys)
            {
                cmd.Parameters.AddWithValue(key, dic[key]);
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
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
         public void ShowReport(ReportClass rpt, String sql, String table,String pval)
         {
             DataSet1 ds = GetTable(sql, table);
             rpt.SetDataSource(ds);
             ReportForm f = new ReportForm();
             f.crystalReportViewer1.ReportSource = rpt;
             f.crystalReportViewer1.ReportSource = rpt;
             rpt.SetParameterValue("p1", pval);
             f.Show();//Show Report Form
         }
        //txtno.Text=db.GetID(string field)
         public string GetID(string field)
         {
             DataTable dt = GetTable("select " + field +"  from PKeys");
             return dt.Rows[0][0].ToString();
         }
         //db.GetID(string field)
         public void UpdateId(string field)
         {
             Execute("Update PKeys set " + field + "=" + field + "+1");
             
         }
        //db.Fillcombo(cmbcategory,"select * from Category",CategoryName","CategoryName");
         public void FillCombo(ComboBox cmb, string sql, string displayfield, string returnfield)
         {
             DataTable dt = GetTable(sql);
             cmb.DataSource = dt;
             cmb.DisplayMember = displayfield;
             cmb.ValueMember = returnfield;
         }
        //FillListView(listView1,"select command")
        public void FillListView(ListView listView1,string sql)
        {
            DataTable dt=GetTable(sql);
            //Clear all items in ListView
            listView1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lt = new ListViewItem();
                lt.Text = dr[0].ToString();
                for(int i=1;i<listView1.Columns.Count;i++)
                {
                    lt.SubItems.Add(dr[i].ToString());
                }
                listView1.Items.Add(lt);
            }
        }
    }
}
