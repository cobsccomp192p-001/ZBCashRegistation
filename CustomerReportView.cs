using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace ZBCashRegistation
{
    public partial class CustomerReportView : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public CustomerReportView()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //Regex r = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$");
            //Match m = r.Match(txtPhone.Text);
            if (txtPhone.Text == "" || txtPhone.Text == "" /*|| m.Success == false*/)
            {
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Required fields avalible Please check the form again",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
                //if (m.Success == false)
                //{
                //    MessageBox.Show("Invalid Phone Number",
                //  "Important Note",
                //   MessageBoxButtons.OK,
                //   MessageBoxIcon.Exclamation,
                //    MessageBoxDefaultButton.Button1);
                //}

            }
            else
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            var CustomerCount = (from bill in entities.Bills

                                    where bill.PhoneNumber == txtPhone.Text
                                    select new { bill.id }).Count();
            if(CustomerCount>0)
            {
                var fooditementities = (from cus in entities.Customers
                                        join bill in entities.Bills on cus.Mobile equals bill.PhoneNumber
                                        join billmst in entities.BillMsts on bill.BillNo equals billmst.BillNo
                                        join section in entities.SalesTypes on bill.SecID equals section.id
                                        where cus.Mobile == txtPhone.Text
                                        select new { bill.BillNo, bill.Date, bill.Time, bill.Total, bill.Discount, bill.UserName, bill.NetAmount, billmst.ItemName, billmst.Price, billmst.Qty, billmst.TotalAmount, billmst.Isfree, section.Section, cus.Name, cus.CID, cus.Mobile }).ToList();

                string reportPath = ConfigurationManager.AppSettings["ReportPath"];
                string ConnectReport = reportPath + "CustomerDetails.rpt";
                ReportDocument rprt = new ReportDocument();
                rprt.Load(@ConnectReport);
                rprt.SetDataSource(fooditementities);
                crystalReportViewer1.ReportSource = rprt;
            }

            else
            {
                MessageBox.Show("No Data Found!!",
                 "Important Note",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1);
            }

            
        }

        private void CustomerReportView_Load(object sender, EventArgs e)
        {
            txtPhone.MaxLength = 10;
        }
    }
}
