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
    public partial class Form8 : Form
    {
        DBClass db = new DBClass();
        string fname;
        public Form8()
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

        private void txtroll_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtroll.Text)) 
            {
                errorProvider1.SetError(txtroll, "Roll No cannot be empty");
                e.Cancel = true;    //validation failed
            }
            else if (!Regex.IsMatch(txtroll.Text,"^\\d+$"))       //bool Ismatch(input,pattern)
            {
                errorProvider1.SetError(txtroll, "Roll No must be integer");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(txtroll, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void txtname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtname.Text))
            {
                errorProvider1.SetError(txtname, "Name cannot be empty");
                e.Cancel = true;    //validation failed
            }
            else if (!Regex.IsMatch(txtname.Text, "^[A-Za-z ]+$"))       
            {
                errorProvider1.SetError(txtname, "Name allows only chars and spaces");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(txtname, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void txtaddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtaddress.Text))
            {
                errorProvider1.SetError(txtaddress, "Name cannot be empty");
                e.Cancel = true;    //validation failed
            }

            else
            {
                errorProvider1.SetError(txtaddress, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void dtbdate_Validating(object sender, CancelEventArgs e)
        {
            if (dtbdate.Value>DateTime.Now.AddYears(-1))
            {
                errorProvider1.SetError(dtbdate, "BirthDate should be less than current date");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(dtbdate, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void cmbcourses_Validating(object sender, CancelEventArgs e)
        {
             if (string.IsNullOrEmpty(cmbcourses.Text))
            {
                errorProvider1.SetError(cmbcourses, "Course cannot be empty");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(cmbcourses, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void txtemail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                errorProvider1.SetError(txtemail, "Email should not be empty");
                e.Cancel = true;    //validation failed
            }
            else if (!Regex.IsMatch(txtemail.Text, "^\\w+@\\w+\\.\\w{2,3}(\\.\\w{2,3})?$"))
            {
                errorProvider1.SetError(txtemail, " Email is invalid");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(txtemail, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void txtmobno_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtmobno.Text))
            {
                errorProvider1.SetError(txtmobno, "Mobile No allow only 10 digits");
                e.Cancel = true;    //validation failed
            }
            else if (!Regex.IsMatch(txtmobno.Text, "^(\\+\\d{1,3})?\\d{10}$"))
            {
                errorProvider1.SetError(txtmobno, "invalid mobno");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(txtmobno, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void chkhobbies_Validating(object sender, CancelEventArgs e)
        {
            if (chkhobbies.CheckedItems.Count==0)
            {
                errorProvider1.SetError(chkhobbies, "Hobbies cannot be empty");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError(chkhobbies, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void rbfemale_Validating(object sender, CancelEventArgs e)
        {
            
             
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CrystalReport3(), "select * from StudPhoto2","StudPhoto2");
        }

        private void rbmale_Validating(object sender, CancelEventArgs e)
        {
            if (rbmale.Checked == false && rbfemale.Checked == false)
            {
                errorProvider1.SetError(rbfemale, "Gender cannot be empty");
                e.Cancel = true; ;    //validation failed
            }
            else
            {
                errorProvider1.SetError(rbfemale, "");
                e.Cancel = false;   //validation ok
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db.FillGrid(dg1, "select * from studphoto2 where " + cmbsearch.Text + " like '%" + txtsearch.Text + "%'");
        }
        
     }
}
