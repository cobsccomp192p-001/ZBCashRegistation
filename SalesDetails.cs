using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace ZBCashRegistation
{
    public partial class SalesDetails : Form
    {
        public static int userIdset = 0;
        public static string UserNameSet = "";
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public static string billnumber = "";
        public SalesDetails()
        {
            InitializeComponent();
        }

        private void SalesDetails_Load(object sender, EventArgs e)
        {
            LoadDefaltSales();
        }

        private void LoadDefaltSales()
        {
            DateTime fromdate = Convert.ToDateTime(dtpfrom.Value.ToString("yyyy-MM-dd"));
            DateTime Todate = Convert.ToDateTime(dtpto.Value.ToString("yyyy-MM-dd"));

            var Bills = (from bill in entities.Bills
                                    
                                    join section in entities.SalesTypes on bill.SecID equals section.id
                                    where bill.Date >= fromdate && bill.Date <= Todate
                                   orderby bill.id descending
                                    select new {bill.id, bill.BillNo, bill.Date, bill.Time, bill.Total, bill.Discount, bill.UserName, bill.NetAmount, section.Section, bill.PhoneNumber }).ToList();

          
                DataGridViewButtonColumn Bill = new DataGridViewButtonColumn();
                DataGridViewButtonColumn Resetbtn = new DataGridViewButtonColumn();
                DataGridViewButtonColumn Print = new DataGridViewButtonColumn();

                Resetbtn.DefaultCellStyle.BackColor = Color.Red;
                Resetbtn.DefaultCellStyle.ForeColor = Color.White;

                Bill.DefaultCellStyle.BackColor = Color.Blue;
                Bill.DefaultCellStyle.ForeColor = Color.White;

                Print.DefaultCellStyle.BackColor = Color.Green;
                Print.DefaultCellStyle.ForeColor = Color.White;

            //dataGridView1.Columns[0].Width = 60;
            //dataGridView1.Columns[1].Width = 100;
            //dataGridView1.Columns[2].Width =60;
            //dataGridView1.Columns[3].Width = 20;


            if (dataGridView1.Columns.Contains(Resetbtn.Name = "Bill"))
                {

                }
                else
                {
                    dataGridView1.Columns.Add(Bill);
                }

                if (dataGridView1.Columns.Contains(Resetbtn.Name = "Print"))
                {

                }
                else
                {
                    dataGridView1.Columns.Add(Print);
                }

            if (dataGridView1.Columns.Contains(Resetbtn.Name = "Reset"))
                {

                }
                else
                {
                    dataGridView1.Columns.Add(Resetbtn);
                }



                Print.FlatStyle = FlatStyle.Flat;
                Print.HeaderText = "Print";
                Print.Name = "Print";
                Print.Text = "Print";
                Print.UseColumnTextForButtonValue = true;
                Print.Width = 60;

                Bill.FlatStyle = FlatStyle.Flat;
                Bill.HeaderText = "Bill";
                Bill.Name = "Bill";
                Bill.Text = "Bill";
                Bill.UseColumnTextForButtonValue = true;
                Bill.Width = 60;

                Resetbtn.FlatStyle = FlatStyle.Flat;
                Resetbtn.HeaderText = "Reset";
                Resetbtn.Name = "Reset";
                Resetbtn.Text = "Reset";
                Resetbtn.UseColumnTextForButtonValue = true;
                Resetbtn.Width = 60;


            int adminCheck = AdminLogin.SetIsAdmin;
            txtUsername.Text = AdminLogin.SetUserName;
            UserNameSet = AdminLogin.SetUserName;
            userIdset = AdminLogin.SetUserID;
            if (adminCheck == 2)
            {
                Resetbtn.Visible = true;

            }
            else
            {
                Resetbtn.Visible = false;
                
            }





            dataGridView1.Rows.Clear();
            foreach (var b in Bills)
            {
                if (b.id != 0)
                {
                    dataGridView1.Rows.Add(b.id,b.BillNo,b.UserName,b.Date,b.Time,b.Total,b.Discount,b.NetAmount,b.Section);
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    billnumber = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Billviewer bill = new Billviewer();
                    bill.TopMost = true;
                    bill.Show();
                }

            }

            if(e.ColumnIndex==10)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    billnumber = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    var billPrint = (from billprint in entities.Bills
                                     join billmstprint in entities.BillMsts on billprint.BillNo equals billmstprint.BillNo
                                     where billprint.BillNo == billnumber
                                     select new { billprint.BillNo, billprint.Date, billprint.Time, billprint.Total, billprint.Discount, billprint.ServiceCharge, billprint.UserName, billprint.NetAmount, billmstprint.ItemName, billmstprint.Price, billmstprint.Qty, billmstprint.TotalAmount, billmstprint.Isfree }).ToList();

                    string reportPath = ConfigurationManager.AppSettings["ReportPath"];
                    string ConnectReport = reportPath + "Bill.rpt";
                    ReportDocument rprt = new ReportDocument();
                    rprt.Load(@ConnectReport);
                    rprt.SetDataSource(billPrint);
                    rprt.PrintOptions.PrinterName = "RP80 Printer";
                    rprt.PrintToPrinter(1, true, 1, 1);
                }
            }

            if (e.ColumnIndex == 11)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DialogResult result1 = MessageBox.Show("Are You sure , You want to delete this",
                    "Important Question",
                     MessageBoxButtons.YesNo);
                    if (result1.ToString() == "Yes")
                    {
                        DateTime BillDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        string billS = BillDate.ToString("yyyy-MM-dd");
                        DateTime currentDate = DateTime.Now;
                        string currentS = currentDate.ToString("yyyy-MM-dd");

                        if(billS == currentS)
                        {
                            string billNo  = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            int billId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            float netTotal = (float)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                            ResetBill(billNo, billId, netTotal);
                        }
                        else
                        {

                        }
                    }
                    
                }

            }
        }

        private void ResetBill(string billNo, int billId , float netTotal)
        {
            String today22 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todateCon22 = Convert.ToDateTime(today22);
            var CashInHandCount = (from row in entities.CashInHands
                                   where row.Date == todateCon22
                                   select new { row.CashInHand1 }).FirstOrDefault();
            float newcashinhand = 0;
            if (CashInHandCount.CashInHand1 >= netTotal)
            {
                newcashinhand = (float)Convert.ToDouble(CashInHandCount.CashInHand1 - netTotal);
            }
            else
            {
                newcashinhand = (float)Convert.ToDouble(CashInHandCount.CashInHand1);
            }

            var cashHand2 = (from row in entities.CashInHands where row.Date == todateCon22 select row).FirstOrDefault();
            cashHand2.CashInHand1 = newcashinhand;

            entities.SaveChanges();

            var removebill = (from row in entities.Bills
                              where row.id == billId

                          select row).FirstOrDefault();

            if (removebill != null)
            {
                entities.Bills.Remove(removebill);
                entities.SaveChanges();
                
            }


            var DeleteBillMst = from billmst in entities.BillMsts
                                where billmst.BillNo == billNo
                                select billmst;

            foreach (var delete in DeleteBillMst)
            {

                entities.BillMsts.Remove(delete);
                
            }
            entities.SaveChanges();

            MessageBox.Show("Reset Completed");

            LoadDefaltSales();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDefaltSales();
        }
    }
}
