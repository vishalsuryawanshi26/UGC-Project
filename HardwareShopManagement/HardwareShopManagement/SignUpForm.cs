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


namespace HardwareShopManagement
{
    public partial class SignUpForm : Form
    {
        DBClass db = new DBClass();
        public SignUpForm()
        {
            InitializeComponent();
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (rbmale.Checked)
                gender = "Male";
            if (rbfemale.Checked)
                gender = "Female";

            if (txtuser.Text == "" || txtpass.Text == "" ||txtfirst.Text=="" || txtlast.Text=="" ||txtpass1.Text=="" || txtemail.Text=="" ||txtcontact.Text==""||txtaddress.Text==""||dtpbirth.Text==""||cmbsec.Text==""||txtanswer.Text=="")
            {
                MessageBox.Show(" Please Fill Form Properly...", "Fill The Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuser.Focus();
            }

            else if (txtpass.Text != txtpass1.Text)
            {
                MessageBox.Show("Password Mismatch...", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();
            }

            else
            {

                db.Execute("Insert into SignUp (FirstName,LastName,EmailID,Contact,Address,DOB,Gender,SecQ,Answer,UserName,Password)values('" + txtfirst.Text + "','" + txtlast.Text + "','" + txtemail.Text + "','" + txtcontact.Text + "','" + txtaddress.Text + "','" + dtpbirth.Value.ToString("MM/dd/yyyy") + "','" + gender + "','" + cmbsec.Text + "','" + txtanswer.Text + "','" + txtuser.Text + "','" + txtpass.Text + "')");
                db.Execute("Insert into Login(UserName,Password) Values('" + txtuser.Text + "','" + txtpass.Text + "')");
                MessageBox.Show("Sign Up successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfirst.Clear();
                txtlast.Clear();
                txtemail.Clear();
                txtcontact.Clear();
                txtaddress.Clear();
                txtanswer.Clear();
                dtpbirth.Value = DateTime.Now;
                rbmale.Checked = false;
                rbfemale.Checked = false;
                cmbsec.SelectedIndex = -1;
                txtuser.Clear();
                txtpass.Clear();
                txtpass1.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                txtpass.UseSystemPasswordChar = false;
                txtpass1.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
                txtpass1.UseSystemPasswordChar = true;
            }

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtfirst.Clear();
            txtlast.Clear();
            txtemail.Clear();
            txtcontact.Clear();
            txtaddress.Clear();
            dtpbirth.Value = DateTime.Now;
            rbmale.Checked = false;
            rbfemale.Checked = false;
            cmbsec.SelectedIndex = -1;
            txtanswer.Clear();
            txtuser.Clear();
            txtpass.Clear();
            txtpass1.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
            LoginForm f = new LoginForm();
            f.Show();
        }

        private void dtpbirth_Validating(object sender, CancelEventArgs e)
        {
            if (dtpbirth.Value > DateTime.Now.AddYears(-1))
            {
                errorProvider1.SetError(dtpbirth, "BirthDate should be less than one year from current date");
                e.Cancel = true; //Validation failed
            }
            else
            {
                errorProvider1.SetError(dtpbirth, ""); //No Error Message
                e.Cancel = false; //Validation OK
            }
        }

        private void txtemail_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                errorProvider1.SetError(txtemail, "Email cannot be empty");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtemail.Text, "^\\w+@\\w+\\.\\w{2,3}(\\.\\w{2,3})?$"))
            {
                errorProvider1.SetError(txtemail, "Invalid Email ID");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtemail, "");
                e.Cancel = false;
            }
        }

        private void txtcontact_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtcontact.Text))
            {
                errorProvider1.SetError(txtcontact, "Mobile No cannot be empty");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtcontact.Text, "^(\\+\\d{1,3})?\\d{10}$"))
            {
                errorProvider1.SetError(txtcontact, "Contact No allows only 10 digits");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtcontact, "");
                e.Cancel = false;
            }

        }


        private void rbmale_Validating(object sender, CancelEventArgs e)
        {
            if (rbmale.Checked == false && rbfemale.Checked == false)
            {
                errorProvider1.SetError(rbfemale, "Gender cannot be empty");
                e.Cancel = true; 
            }
            else
            {
                errorProvider1.SetError(rbfemale, "");
                e.Cancel = false; 
            }
            
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            ValidationUtil.errorProvider1 = errorProvider1;
            ValidationUtil.ApplyRules(txtfirst, "FirstName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtlast, "LastName", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtaddress, "Address", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtanswer, "Answer", new string[] { "Empty" });
            ValidationUtil.ApplyRules(txtpass, "Password", new string[] { "Empty" });
        }
    }
}
