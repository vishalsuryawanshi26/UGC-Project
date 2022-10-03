using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using HardwareShopManagement.Reports;

namespace HardwareShopManagement
{
    public partial class MainForm : Form
    {
        public LoginForm loginForm;
        DBClass db = new DBClass();
        public MainForm()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            loginForm.Show();
            loginForm.txtuser.Clear();
            loginForm.txtpass.Clear();
            loginForm.txtuser.Focus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "Main Form [Logged User:" + ProjectEnv.UserName + "]";
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void mSPaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint.exe");
        }

        private void mSOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("winword.exe");
        }

        private void mSExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("excel.exe");
        }

        private void mSPowerpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("powerpnt.exe");
        }

        private void browserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void googleChromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe");
        }

        private void firefoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("firefox.exe");
        }

        private void microsoftEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("msedge.exe");
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPasswordForm f = new CPasswordForm();
            f.Show();
        }

        private void screenLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenLockForm f = new ScreenLockForm();
            f.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementForm f = new UserManagementForm();
            f.Show();
        }

        private void shopInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopForm s = new ShopForm();
            s.Show();
            
        }

        private void productCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm f = new CategoryForm();
            f.Show();

        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyForm f = new CompanyForm();
            f.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm f = new CustomerForm();
            f.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierForm f = new SupplierForm();
            f.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm f=new ProductForm();
            f.Show();
        }

        private void supplierPaymetnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierPaymentForm f = new SupplierPaymentForm();
            f.Show();
        }

        private void customerPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerReceiptForm f = new CustomerReceiptForm();
            f.Show();
        }

        private void customerListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CustomerReport(), "Select * from Customer", "Customer");
        }

        private void supplierListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.ShowReport(new SupplierReport(), "Select * from Supplier", "Supplier");
        }

        private void cutomerReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.ShowReport(new CustomerRecReport(), "Select * from CustomerReceipt", "CustomerReceipt");
        }

        private void supplierPaymentListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.ShowReport(new SupplierPaymentReport(), "Select * from SupplierPayment", "SupplierPayment");
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POListForm f = new POListForm();
            f.Show();
        }

        private void quotationSalesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QListForm f = new QListForm();
            f.Show();
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRListForm f = new PRListForm();
            f.Show();
        }

        private void salesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillListForm f = new BillListForm();
            f.Show();
        }

        private void salesReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SRListForm f = new SRListForm();
            f.Show();
        }

        private void materialReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MRListForm f = new MRListForm();
            f.Show();
        }

        private void filterSalesRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterForm f = new FilterForm();
            f.Show();
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 f = new AboutBox1();
            f.Show();
        }

        private void availableProductStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.ShowReport(new ProductReport(), "Select * from Product", "Product");
        }
    }
}
