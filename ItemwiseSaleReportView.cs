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
    public partial class ItemwiseSaleReportView : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public ItemwiseSaleReportView()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            DateTime fromdate = Convert.ToDateTime(dtpfrom.Value.ToString("yyyy-MM-dd"));
            DateTime Todate = Convert.ToDateTime(dtpto.Value.ToString("yyyy-MM-dd"));



            var itemWiseSales = (from bill in entities.Bills
                                 join billmst in entities.BillMsts on bill.BillNo equals billmst.BillNo
                                 where bill.Date >= fromdate && bill.Date <= Todate
                                 group billmst by billmst.ItemName.ToUpper() into g
                                 orderby g.Sum(x => x.Price) descending
                                 select new { ItemName = g.Key, total = g.Sum(x => x.Price), NoOfSales= g.Count(),fromdate,Todate } 
                                 ).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "ItemwiseSales.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(itemWiseSales);
            crystalReportViewer1.ReportSource = rprt;
        }
    }
}
