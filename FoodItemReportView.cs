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
    public partial class FoodItemReportView : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public FoodItemReportView()
        {
            InitializeComponent();
        }

        private void FoodItemReportView_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void LoadReport()
        {

            var fooditementities = (from item in entities.FoodItems
                                    join category in entities.FoodCATs on item.CATID equals category.CATID
                                    
                                    select new { item.ItemName,item.Price,item.Description,category.CATID,category.CATName}).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "foodItemReport.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(fooditementities);
            crystalReportViewer1.ReportSource = rprt;
        }
    }
}
