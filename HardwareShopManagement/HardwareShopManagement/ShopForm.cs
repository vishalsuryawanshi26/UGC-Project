using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HardwareShopManagement
{
    public partial class ShopForm : Form
    {
         DBClass db=new DBClass();
         bool add=false;
         public ShopForm()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        { 
            string name = txtname.Text;
            string address = txtaddress.Text;
            string owner = txtowner.Text;
            string contact = txtcontact.Text;
            string email = txtmail.Text;
            string web = txtweb.Text;
            string gst = txtgst.Text;
            string shopact = txtact.Text;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@name", name);
            dic.Add("@address", address);
            dic.Add("@owner", owner);
            dic.Add("@contact", contact);
            dic.Add("@email", email);
            dic.Add("@web", web);
            dic.Add("@gst", gst);
            dic.Add("@shopact", shopact);
            
            if(add==false)
            {
            db.Execute("Insert into ShopInfo values(@name,@address,@owner,@contact,@email,@web,@gst,@shopact)",dic);
            }
            else
            {
                db.Execute("Update ShopInfo set Name=@name,Address=@address,Owner=@owner,ContactNo=@contact,Email=@email,Website=@web,GST=@gst,ShopActNo=@shopact",dic);
            }
                MessageBox.Show("Shop Information Updated Successfully....", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                
            
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

        }

        private void ShopForm_Load_1(object sender, EventArgs e)
        {
            DataTable dt = db.GetTable("select * from ShopInfo");
            if (dt.Rows.Count > 0)
            {
                add = true;
                txtname.Text = dt.Rows[0][0].ToString();
                txtaddress.Text = dt.Rows[0][1].ToString();
                txtowner.Text = dt.Rows[0][2].ToString();
                txtcontact.Text = dt.Rows[0][3].ToString();
                txtmail.Text = dt.Rows[0][4].ToString();
                txtweb.Text = dt.Rows[0][5].ToString();
                txtgst.Text = dt.Rows[0][6].ToString();
                txtact.Text = dt.Rows[0][7].ToString();
            }
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtname, "Name", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtaddress, "Address", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtowner, "Owner", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtcontact, "ContactNo", new string[] { "Empty","Mobile No" });
            ValidationUtil.ApplyRules(txtmail, "Email", new string[] { "Empty","Email" });
            //ValidationUtil.ApplyRules(txtweb, "WebSite", new string[] { "Empty","Web" });
            ValidationUtil.ApplyRules(txtgst, "GST", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtact, "ShopActNo", new string[] { "Empty" });
            ValidationUtil.disableValidationOnClose(this);
        }

        /*private void LoginForm_Load(object sender, EventArgs e)
        {
           db.Connect();
            db.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }*/
    }
}
