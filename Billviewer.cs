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
    public partial class Billviewer : Form
    {
        string billno = "";
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public Billviewer()
        {
            InitializeComponent();
        }

        private void Billviewer_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            billno = SalesDetails.billnumber;
            loadReport(billno);
        }

        private void loadReport(string billno)
        {
            var fooditementities = (from bill in entities.Bills
                                    join billmst in entities.BillMsts on bill.BillNo equals billmst.BillNo
                                    where bill.BillNo == billno
                                    select new { bill.BillNo, bill.Date, bill.Time, bill.Total, bill.Discount,bill.ServiceCharge,bill.UserName, bill.NetAmount, billmst.ItemName, billmst.Price,billmst.Qty,billmst.TotalAmount,billmst.Isfree}).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "Bill.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(fooditementities);
            crystalReportViewer1.ReportSource = rprt;
        }
    }
}
