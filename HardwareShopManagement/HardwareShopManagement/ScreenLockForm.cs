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
    public partial class ScreenLockForm : Form
    {
         
         public ScreenLockForm()
        {
            InitializeComponent();
        }
        
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pass = txtpass.Text;
                if (ProjectEnv.Password == pass)
                {
                    Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
