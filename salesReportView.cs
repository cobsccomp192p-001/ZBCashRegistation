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
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace ZBCashRegistation
{
    public partial class salesReportView : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public salesReportView()
        {
            InitializeComponent();
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            DateTime fromdate = Convert.ToDateTime(dtpfrom.Value.ToString("yyyy-MM-dd"));
            DateTime Todate = Convert.ToDateTime(dtpto.Value.ToString("yyyy-MM-dd"));

            var fooditementities = (from bill in entities.Bills
                                    join billmst in entities.BillMsts on bill.BillNo equals billmst.BillNo
                                    join section in entities.SalesTypes on bill.SecID equals section.id
                                    where bill.Date >= fromdate && bill.Date <= Todate
                                    select new { bill.BillNo, bill.Date, bill.Time, bill.Total, bill.Discount,bill.ServiceCharge, bill.UserName, bill.NetAmount, billmst.ItemName, billmst.Price, billmst.Qty, billmst.TotalAmount, billmst.Isfree,section.Section,bill.PhoneNumber }).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "SalesReport.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(fooditementities);
            crystalReportViewer1.ReportSource = rprt;
        }

        private void salesReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
