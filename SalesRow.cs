using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBCashRegistation
{
    public partial class SalesRow : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public SalesRow()
        {
            InitializeComponent();
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            DateTime fromdate = Convert.ToDateTime(dtpfrom.Value.ToString("yyyy-MM-dd"));
            DateTime Todate = Convert.ToDateTime(dtpto.Value.ToString("yyyy-MM-dd"));

            var fooditementities = (from bill in entities.Bills
                                    
                                    where bill.Date >= fromdate && bill.Date <= Todate
                                    select new { bill.BillNo, bill.Date, bill.Time, bill.Total, bill.Discount, bill.ServiceCharge, bill.UserName, bill.NetAmount, bill.PhoneNumber }).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "salesRow.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(fooditementities);
            crystalReportViewer1.ReportSource = rprt;
        }
    }
}
