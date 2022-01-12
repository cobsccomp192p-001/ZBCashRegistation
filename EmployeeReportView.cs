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
    public partial class EmployeeReportView : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public EmployeeReportView()
        {
            InitializeComponent();
        }

        private void EmployeeReportView_Load(object sender, EventArgs e)
        {
            Loadreport();
        }

        private void Loadreport()
        {
            var fooditementities = (from emp in entities.Employees
                                   
                                    select new { emp.Name,emp.Mobile1,emp.Mobile2,emp.Designation,emp.Address }).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "EmployeeReport.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(fooditementities);
            crystalReportViewer1.ReportSource = rprt;
        }
    }
}
