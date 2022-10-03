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
    public partial class SplashForm : Form
    {
        int i=0;
        public SplashForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                pb1.Value = i;
                label1.Text = i + "%";
            }
            catch
            { 
            }
            
            if (i >= 100)
            {
                timer1.Stop();
                timer1.Enabled = false;
                Hide();
                LoginForm f = new LoginForm();
                f.Show();
            }
            i++;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
