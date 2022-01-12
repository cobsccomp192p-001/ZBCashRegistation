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
    public partial class CashInHandReportView : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public CashInHandReportView()
        {
            InitializeComponent();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            DateTime fromdate = Convert.ToDateTime(dtpfrom.Value.ToString("yyyy-MM-dd"));
            DateTime Todate = Convert.ToDateTime(dtpto.Value.ToString("yyyy-MM-dd"));

            var fooditementities = (from cashInhand in entities.CashInHands

                                    where cashInhand.Date >= fromdate && cashInhand.Date <= Todate
                                    select new { cashInhand.Date, cashInhand = cashInhand.CashInHand1 }).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "cashInhandReport.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(fooditementities);
            crystalReportViewer1.ReportSource = rprt;
        }
    }
}
