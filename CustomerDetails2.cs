using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;


namespace ZBCashRegistation
{
    public partial class CustomerDetails2 : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public CustomerDetails2()
        {
            InitializeComponent();
        }

        private void CustomerDetails2_Load(object sender, EventArgs e)
        {
            Loadreport();
        }

        private void Loadreport()
        {
            var customerDet = (from cus in entities.Customers

                                    select new { cus.Name, cus.Mobile }).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "CustomerDetails2.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(customerDet);
            crystalCustomerDetails2.ReportSource = rprt;
        }
    }
}
