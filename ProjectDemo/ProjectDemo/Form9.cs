using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace ProjectDemo
{
    public partial class Form9 : Form
    {
        DBClass db = new DBClass();
        string fname;
        public Form9()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtroll, "RollNo",new string[]{"Empty","Integer"});
            ValidationUtil.ApplyRules(txtname, "Name",new string[]{"Empty","CharsSpaces"});
            ValidationUtil.ApplyRules(txtaddress, "Address", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtemail, "Email", new string[] { "Empty","Email"});
            ValidationUtil.ApplyRules(txtmobno, "Mobile", new string[] { "Empty","Mobile"});
            ValidationUtil.CheckCombo(cmbcourses,"Course");
            ValidationUtil.CheckRadioButton(new RadioButton[]{rbmale,rbfemale},"Gender");
            ValidationUtil.CheckDateBeforeCombo(dtbdate, "Birth Date", 1);
            ValidationUtil.CheckList(chkhobbies, "Hobbies");

            db.FillGrid(dg1, "select * from StudPhoto2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roll=txtroll.Text;
            string name=txtname.Text;
            string address=txtaddress.Text;
            string gender = "";
            if (rbmale.Checked)
                gender = "Male";
            if (rbfemale.Checked)
                gender = "Female";
            string bdate = dtbdate.Value.ToString("yyyy-MM-dd");
            string course = cmbcourses.Text;
            string email = txtemail.Text;
            string mobile = txtmobno.Text;
            string hobbies = "";
            foreach (var item in chkhobbies.CheckedItems)
            {
                hobbies = hobbies + item.ToString() + ",";
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@roll", roll);
            dic.Add("@name", name);
            dic.Add("@address", address);
            dic.Add("@gender", gender);
            dic.Add("@date", bdate);
            dic.Add("@course", course);
            dic.Add("@email", email);
            dic.Add("@mobile", mobile);
            dic.Add("@hobbies", hobbies);

            string btntext = btnsave.Text;
            if (btntext == "Save")
            {
                if (picphoto.Image == null)
                {
                    MessageBox.Show("Please select image", "image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            byte[] b= File.ReadAllBytes(fname);
            dic.Add("@photo",b);
            //string btntext = btnsave.Text;
            if (btntext == "Save")
            {
                db.Execute("Insert into StudPhoto2 values(@roll,@name,@address,@gender,@date,@course,@email,@mobile,@hobbies,@photo)", dic);
                MessageBox.Show("Student Record is Saved..","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);


            }
            else
            {
                db.Execute("Update StudPhoto2 set Name=@name,Address=@address,Gender=@gender,BirthDate=@date,Course=@course,EmailID=@email,MobileNo=@mobile,Hobbies=@hobbies,Photo=@photo where RollNo=@roll", dic);
                MessageBox.Show("Student Record is Saved..", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.FillGrid(dg1, "select * from StudPhoto2");

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose Student Image";
            fd.Filter="Image Files(*.jpg)|*.jpg";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fname = fd.FileName;
                picphoto.Image = Image.FromFile(fname);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txtname.Clear();
            txtaddress.Clear();
            rbmale.Checked = false;
            rbfemale.Checked = false;
            cmbcourses.SelectedIndex = -1;
            txtemail.Clear();
            txtmobno.Clear();
            for (int i = 0; i < chkhobbies.Items.Count; i++)
            {
                chkhobbies.SetItemChecked(i, false);
            }

            picphoto.Image = null;
            btnsave.Text = "Save";
            txtroll.ReadOnly = false;

            txtroll.Focus();

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if(dg1.CurrentRow !=null)    //row is selected in Gredview
            {
                string roll=dg1.CurrentRow.Cells[0].Value.ToString();
                DataTable dt = db.GetTable("select * from StudPhoto2 where RollNo="+roll);
                txtroll.Text = dt.Rows[0][0].ToString();
                txtname.Text = dt.Rows[0][1].ToString();
                txtaddress.Text = dt.Rows[0][2].ToString();
                string gender = dt.Rows[0][3].ToString();   //Male or Female
                if(gender=="Male")
                    rbmale.Checked=true;
                if(gender=="Female")
                    rbfemale.Checked=true;
                //DateTime.Parse(string)==> Converts String to DateTime Type
                dtbdate.Value =DateTime.Parse(dt.Rows[0][4].ToString());   //DateTime=DateTime.Parse(string)

                cmbcourses.Text = dt.Rows[0][5].ToString();
                txtemail.Text = dt.Rows[0][6].ToString();
                txtmobno.Text = dt.Rows[0][7].ToString();
                string hobbies = dt.Rows[0][8].ToString();  //cricket,movies

                for (int i = 0; i < chkhobbies.Items.Count; i++)
                {
                    //chkhobbies.Items[i]
                    
                    string item = chkhobbies.Items[i].ToString();
                    if (hobbies.Contains(item)) //bool contains(String s)
                    {
                        chkhobbies.SetItemChecked(i, true);
                    }
                    else
                    {
                        chkhobbies.SetItemChecked(i, false);
                    }
                }
                byte[] b = (byte[])dt.Rows[0][9];   //byte[]=(byte[])object
                //write byte array to temp file
                fname = Path.GetTempFileName();
                File.WriteAllBytes(fname, b);
                picphoto.Image = Image.FromFile(fname);
                txtroll.ReadOnly = true;
                btnsave.Text = "Update";
                txtname.Focus();

            }
            else
            {
                MessageBox.Show("Please select row","Select",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(dg1.CurrentRow!=null)
            {
                string roll = dg1.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@roll", roll);
                    db.Execute("delete from studphoto2 where RollNo=@roll", dic);
                    db.FillGrid(dg1, "select * from StudPhoto2");
                }
            }
            else
            {
                MessageBox.Show("Please select row", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CrystalReport3(), "select * from StudPhoto2","StudPhoto2");
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbcourses_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void txtroll_TextChanged(object sender, EventArgs e)
        {

        }
        
     }
}
