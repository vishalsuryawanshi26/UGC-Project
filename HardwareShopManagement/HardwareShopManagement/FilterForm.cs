using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using HardwareShopManagement.Reports;

namespace HardwareShopManagement
{
    public partial class FilterForm : Form
    {
         DBClass db=new DBClass();
         public FilterForm()
        {
            InitializeComponent();
        }


         private void FilterForm_Load(object sender, EventArgs e)
         {

         }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.ShowReport(new Bill3Report(), "select * from Bill where BillDate='" + dt1.Value.ToString("yyyy-MM-dd") + "'", "Bill","As on Date " + dt1.Value.ToString("yyyy-MM-dd"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.ShowReport(new Bill3Report(), "select * from Bill where BillDate between'" + dt2.Value.ToString("yyyy-MM-dd") + "' and '" + dt3.Value.ToString("yyyy-MM-dd") + "'", "Bill", "As on Date" + dt2.Value.ToString("yyyy-MM-dd")+ "To"+ dt3.Value.ToString("yyyy-MM-dd"));
        }
    }
}
