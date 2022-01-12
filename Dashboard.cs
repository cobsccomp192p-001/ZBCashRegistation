using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBCashRegistation
{
    public partial class Dashboard : Form
    {
        public static int userIdset = 0;
        public static string UserNameSet = "";
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public Dashboard()
        {
            InitializeComponent();
            

            
        }

        private void GetTime(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int adminCheck = AdminLogin.SetIsAdmin;
            txtUserName.Text = AdminLogin.SetUserName;
            UserNameSet = AdminLogin.SetUserName;
            userIdset = AdminLogin.SetUserID;
            if(adminCheck == 1 || adminCheck == 2)
            {
                btncate.Enabled = true;
                btnitem.Enabled = true;
                btnemp.Enabled = true;
                btncus.Enabled = true;
                btnsalesreport.Enabled = true;
                btnfooditemreport.Enabled = true;
                btncusreport.Enabled = true;
                btnEmployeeRpt.Enabled = true;
                btncashInhand.Enabled = true;
                btnsections.Enabled = true;
                btnSalReprotrow.Enabled = true;
                btncusDet.Enabled = true;
                btnItemwiseRpt.Enabled = true;
            }
            else
            {
                btncate.Enabled = false;
                btnitem.Enabled = false;
                btnemp.Enabled = false;
                btncus.Enabled = false;
                btnsalesreport.Enabled = false;
                btnfooditemreport.Enabled = false;
                btncusreport.Enabled = false;
                btnEmployeeRpt.Enabled = false;
                btncashInhand.Enabled = false;
                btnsections.Enabled = false;
                btnSalReprotrow.Enabled = false;
                btncusDet.Enabled = false;
                btnItemwiseRpt.Enabled = false;
            }

            //pnlMasters.Height = pnlMasters.MaximumSize.Height;
            //pnlReport.Height = pnlReport.MaximumSize.Height;
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Timer timer = new Timer();
            timer.Interval = (1 * 1000); // 10 secs
            timer.Tick += new EventHandler(GetTime);
            timer.Start();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btncate_Click(object sender, EventArgs e)
        {
            FoodCategories foodca = new FoodCategories();
            foodca.TopMost = true;
            foodca.Show();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            
            pnlMasters.Height = pnlMasters.MaximumSize.Height;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            pnlReport.Height = pnlReport.MaximumSize.Height;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            FoodItemsreg fooditems = new FoodItemsreg();
            fooditems.TopMost = true;
            fooditems.Show();
            
        }

        private void btncus_Click(object sender, EventArgs e)
        {
            CustomerRegistation Customer = new CustomerRegistation();
            Customer.TopMost = true;
            Customer.Show();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            EmployeeRegistation emp = new EmployeeRegistation();
            emp.TopMost = true;
            emp.Show();
        }

        private void btnsections_Click(object sender, EventArgs e)
        {
            Section sec = new Section();
            sec.TopMost = true;
            sec.Show();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            String today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todateCon = Convert.ToDateTime(today);
            int CashInHandCount = (from row in entities.CashInHands
                                   where row.Date == todateCon
                                 select row).Count();

            if(CashInHandCount>0)
            {
                
                bool found = false;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "sales")
                    {
                        n.WindowState = FormWindowState.Maximized;
                        found = true;
                    }
                }
                if (!found)
                {
                    sales aForm = new sales();
                    aForm.Name = "sales";
                    aForm.Show();
                }

            }
            else
            {
                cashInhandCashier cash = new cashInhandCashier();
                cash.TopMost = true;
                cash.Show();
            }
            
           
        }

        private void btnsalesreport_Click(object sender, EventArgs e)
        {
            salesReportView salesview = new salesReportView();
            salesview.TopMost = true;
            salesview.Show();
        }

        private void btnfooditemreport_Click(object sender, EventArgs e)
        {
            FoodItemReportView items = new FoodItemReportView();
            items.TopMost = true;
            items.Show();
        }

        private void btncusreport_Click(object sender, EventArgs e)
        {
            CustomerReportView cus = new CustomerReportView();
            cus.TopMost = true;
            cus.Show();
        }

        private void btnEmployeeRpt_Click(object sender, EventArgs e)
        {
            EmployeeReportView emp = new EmployeeReportView();
            emp.TopMost = true;
            emp.Show();
        }

        private void btncashInhand_Click(object sender, EventArgs e)
        {
            CashInHandReportView cash = new CashInHandReportView();
            cash.TopMost = true;
            cash.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            AdminLogin admin = new AdminLogin();
            admin.Show();
            this.Hide();
            
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalesDetails sales = new SalesDetails();
            sales.TopMost = true;
            sales.Show();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesRow salesview2 = new SalesRow();
            salesview2.TopMost = true;
            salesview2.Show();
        }

        private void btncusDet_Click(object sender, EventArgs e)
        {
            CustomerDetails2 cus = new CustomerDetails2();
            cus.TopMost = true;
            cus.Show();
        }

        private void btnItemwiseRpt_Click(object sender, EventArgs e)
        {
            ItemwiseSaleReportView Item = new ItemwiseSaleReportView();
            Item.TopMost = true;
            Item.Show();
        }

        private void btnTable1_Click(object sender, EventArgs e)
        {
            String today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todateCon = Convert.ToDateTime(today);
            int CashInHandCount = (from row in entities.CashInHands
                                   where row.Date == todateCon
                                   select row).Count();

            if (CashInHandCount > 0)
            {
                //sales sec = new sales();
                //sec.TopMost = true;
                //sec.Show();

                bool found = false;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {

                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "Table1Sales")
                    {
                        n.WindowState=FormWindowState.Maximized;
                        found = true;
                    }
                }
                if (!found)
                {
                    Table1Sales aForm = new Table1Sales();
                    aForm.Name = "Table1Sales";
                    aForm.Show();
                }

            }
            else
            {
                cashInhandCashier cash = new cashInhandCashier();
                cash.TopMost = true;
                cash.Show();
            }
        }

        private void btnTable2_Click(object sender, EventArgs e)
        {

            String today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todateCon = Convert.ToDateTime(today);
            int CashInHandCount = (from row in entities.CashInHands
                                   where row.Date == todateCon
                                   select row).Count();

            if (CashInHandCount > 0)
            {
                bool found = false;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {

                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "Table2Sales")
                    {
                        n.WindowState = FormWindowState.Maximized;
                        found = true;
                    }
                }
                if (!found)
                {
                    Table2Sales aForm = new Table2Sales();
                    aForm.Name = "Table2Sales";
                    aForm.Show();
                }

            }
            else
            {
                cashInhandCashier cash = new cashInhandCashier();
                cash.TopMost = true;
                cash.Show();
            }
        }

        private void btnTable3_Click(object sender, EventArgs e)
        {
            String today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todateCon = Convert.ToDateTime(today);
            int CashInHandCount = (from row in entities.CashInHands
                                   where row.Date == todateCon
                                   select row).Count();

            if (CashInHandCount > 0)
            {
                bool found = false;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {

                    //Checks if the window is already open, and brings it to the front if it is
                    Form n = Application.OpenForms[i];
                    if (n.Name == "Table3Sales")
                    {
                        n.WindowState = FormWindowState.Maximized;
                        found = true;
                    }
                }
                if (!found)
                {
                    Table3Sales aForm = new Table3Sales();
                    aForm.Name = "Table3Sales";
                    aForm.Show();
                }

            }
            else
            {
                cashInhandCashier cash = new cashInhandCashier();
                cash.TopMost = true;
                cash.Show();
            }
        }
    }
}
