using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBCashRegistation
{
    public partial class sales : Form
    {
        public static int SetCashcustomerreg = 0;
        public static string SetCashcusNumber = "";
        public static string billnumber = "";
        ZBcashRegEntities entities = new ZBcashRegEntities();
        
        public sales()
        {
            InitializeComponent();
        }
       
        private void sales_Load(object sender, EventArgs e)
        {
            txtcashier.Text = Dashboard.UserNameSet;
            txtcashierIdhid.Text =  Dashboard.userIdset.ToString();
            txtcusIDhid.Hide();
            txtchashierIdentifier.Hide();
            txtcashierIdhid.Hide();
            pnlcusdetails.Hide();
            txtnumber.MaxLength = 10;
            pnlnumsales.Hide();
            txtServiceCharge.Text = "0";
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            pnlcategory.AutoScroll = true;
            Timer timer = new Timer();
            timer.Interval = (1 * 1000); // 10 secs
            timer.Tick += new EventHandler(GetTime);
            timer.Start();

            

            getcategories();
            getSalesType();

            

        }

        private void getSalesType()
        {
            var salesType = (from row in entities.SalesTypes
                                  select row);
            List<ContViewModel2> ContAccesslist = new List<ContViewModel2>();
            ContViewModel2 c4 = new ContViewModel2();
            c4.id2 = 0;
            c4.Name2 = "";
            ContAccesslist.Add(c4);
            foreach (var type in salesType)
            {
                ContViewModel2 c2 = new ContViewModel2();
                c2.id2 = type.id;
                c2.Name2 = type.Section;
                ContAccesslist.Add(c2);

            }





            cmbsaleType.DataSource = ContAccesslist;
            cmbsaleType.DisplayMember = "Name2";
            cmbsaleType.ValueMember = "id2";
        }

        private void GetTime(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void GetcashIdentiti(object sender, EventArgs e)
        {
            txtchashierIdentifier.Text = CustomerRegistation.SetCashcusidentifier;
            if(txtchashierIdentifier.Text != "")
            {
                var cusdetails = (from row in entities.Customers
                              where row.cashierIdenti == txtchashierIdentifier.Text

                              select row).FirstOrDefault();

                lblcusname.Text = cusdetails.Name;
                lblcusphone.Text = cusdetails.Mobile;
                txtcusIDhid.Text = cusdetails.CID.ToString();
                pnlnumsales.Show();
                pnlcusdetails.Show();

                int billcount = (from row in entities.Bills
                                  where row.PhoneNumber == txtnumber.Text

                                  select row).Count();

                lblsalles.Text = billcount.ToString();

            }
            else
            {
                pnlcusdetails.Hide();
            }
        }

        private void getcategories()
        {
            int y = 1;
            var FoodCategories = (from row in entities.FoodCATs
                                  select row).ToList();


            foreach (var user in FoodCategories)
            {
                if (user.CATName != "")
                {
                    Button categorybtn = new Button();
                    categorybtn.BackColor = Color.OrangeRed;
                    categorybtn.ForeColor = Color.White;
                    categorybtn.Size = new System.Drawing.Size(146, 32);
                    categorybtn.Text = user.CATName;
                    categorybtn.Name = user.CATID.ToString();
                    categorybtn.Location = new Point(13,70* y);
                    categorybtn.Click += new EventHandler(cateEvent);
                    pnlcategory.Controls.Add(categorybtn);
                }

                y++;

            }
        }

        private void cateEvent(object sender, EventArgs e)
        {

            if (txtcusIDhid.Text == "")
            {
                MessageBox.Show("Please Select Customer first",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                int YY = 1;
                panel7.Controls.Clear();
                Button button = sender as Button;
                int categoryId = Convert.ToInt32(button.Name);

                var item = (from row in entities.FoodItems
                            where row.CATID == categoryId
                            select row);

                int count = 0;
                int yset = 1;
                foreach (var ite in item)
                {
                   

                    Button Item = new Button();
                    Item.BackColor = Color.OrangeRed;
                    Item.ForeColor = Color.White;
                    Item.Size = new System.Drawing.Size(90, 32);
                    Item.Text = ite.ItemName;
                    Item.Name = ite.ItemID.ToString();
                    if(count % 8 == 0 && count != 0)
                    {
                        
                        yset++;
                        YY = 1;
                    }
                    else
                    {
                        
                    }
                    Item.Location = new Point(100 * YY, 35 * yset);
                    Item.Click += new EventHandler(ItemSerEvent);
                    panel7.Controls.Add(Item);
                    count++;
                    YY++;
                }

            }

        }

        private void ItemSerEvent(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int ItemID = Convert.ToInt32(button.Name);
            NonFreeItem(ItemID);

            //DialogResult dr = MessageBox.Show("Free Item ?", "Title", MessageBoxButtons.YesNo,
            //MessageBoxIcon.Information);

            //if (dr == DialogResult.Yes)
            //{
            //    FreeItem(ItemID);
            //}
            //else
            //{
            //    NonFreeItem(ItemID);
            //}


        }


            private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }


        private void FreeItem(int ItemId)
        {
            var item = (from row in entities.FoodItems
                        where row.ItemID == ItemId
                        select row).FirstOrDefault();


         
           
                string message = "Are you sure, Do you want to add free item?";
                string title = "Are You Sure";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    
                        int itemid = ItemId;
                        string itemName = item.ItemName;
                        float price = (float)Convert.ToDouble(item.Price);
                        int checkrow2 = 0;
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {

                                int griditemid = Convert.ToInt32(row.Cells[0].Value.ToString());
                                if (griditemid == itemid && row.Cells[6].Value.Equals(1))
                                {
                                    int newqty = Convert.ToInt32(row.Cells[3].Value.ToString()) + 1;
                                    row.Cells[3].Value = newqty;
                                    row.Cells[4].Value = (float)Convert.ToDouble(newqty * price);
                                    row.Cells[5].Value = 0;
                                    row.Cells[6].Value = 1;
                                    checkrow2 = 1;
                                    getTotal();
                                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                                    row.DefaultCellStyle.ForeColor = Color.White;
                                    break;
                                }
                                else
                                {
                                    //float totamount = (float)Convert.ToDouble(price) * 1;
                                    //dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount);
                                    //break;
                                }
                            }
                            else
                            {
                                float totamount2 = (float)Convert.ToDouble(price) * 1;
                                dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount2, 0, 1);
                                row.DefaultCellStyle.BackColor = Color.OrangeRed;
                                row.DefaultCellStyle.ForeColor = Color.White;
                                checkrow2 = 1;
                                getTotal();
                                break;
                            }

                        }

                        if (checkrow2 == 0)
                        {
                            float totamount = (float)Convert.ToDouble(price) * 1;
                            dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount, 0, 1);
                            int index = dataGridView2.Rows.Count - 1;
                            dataGridView2.Rows[index].DefaultCellStyle.BackColor = Color.Pink;
                            getTotal();
                        }
                    

                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    btnDelete.DefaultCellStyle.BackColor = Color.Red;
                    btnDelete.DefaultCellStyle.ForeColor = Color.White;

                    if (dataGridView2.Columns.Contains(btnDelete.Name = "Delete"))
                    {

                    }
                    else
                    {
                        dataGridView2.Columns.Add(btnDelete);
                    }

                    btnDelete.FlatStyle = FlatStyle.Flat;
                    btnDelete.HeaderText = "Delete";
                    btnDelete.Name = "Delete";
                    btnDelete.Text = "Delete";
                    btnDelete.UseColumnTextForButtonValue = true;
                    btnDelete.Width = 60;
                }
                else
                {

                }

            


        }

        private void NonFreeItem(int ItemId)
        {
            var item = (from row in entities.FoodItems
                        where row.ItemID == ItemId
                        select row).FirstOrDefault();


                    int itemid = ItemId;
                    string itemName = item.ItemName;
                    float price = (float)Convert.ToDouble(item.Price);
                    int checkrow = 0;
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {

                            int griditemid = Convert.ToInt32(row.Cells[0].Value.ToString());
                            if (griditemid == itemid && row.Cells[6].Value.Equals(0))
                            {
                                int newqty = Convert.ToInt32(row.Cells[3].Value.ToString()) + 1;
                                row.Cells[3].Value = newqty;
                                row.Cells[4].Value = (float)Convert.ToDouble(newqty * price);
                                row.Cells[5].Value = (float)Convert.ToDouble(newqty * price);
                                row.Cells[6].Value = 0;
                                checkrow = 1;
                                getTotal();
                                break;
                            }
                            else
                            {
                                //float totamount = (float)Convert.ToDouble(price) * 1;
                                //dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount);
                                //break;
                            }
                        }
                        else
                        {
                            float totamount2 = (float)Convert.ToDouble(price) * 1;
                            dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount2, totamount2, 0);
                            checkrow = 1;
                            getTotal();
                            break;
                        }

                    }

                    if (checkrow == 0)
                    {
                        float totamount = (float)Convert.ToDouble(price) * 1;
                        dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount, totamount, 0);
                        getTotal();
                    }
                


                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.DefaultCellStyle.BackColor = Color.Red;
                btnDelete.DefaultCellStyle.ForeColor = Color.White;

                DataGridViewButtonColumn btnFree = new DataGridViewButtonColumn();
                btnFree.DefaultCellStyle.BackColor = Color.Green;
                btnFree.DefaultCellStyle.ForeColor = Color.White; 

                if (dataGridView2.Columns.Contains(btnDelete.Name = "Delete"))
                {

                }
                else
                {
                    dataGridView2.Columns.Add(btnDelete);
                }

                if (dataGridView2.Columns.Contains(btnFree.Name = "Free"))
                {

                }
                else
                {
                    dataGridView2.Columns.Add(btnFree);
                }

                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.HeaderText = "Delete";
                btnDelete.Name = "Delete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.Width = 60;

                btnFree.FlatStyle = FlatStyle.Flat;
                btnFree.HeaderText = "Free";
                btnFree.Name = "Free";
                btnFree.Text = "Free";
                btnFree.UseColumnTextForButtonValue = true;
                btnFree.Width = 60;




            //if (e.ColumnIndex == 5)
            //{
            //    string message = "Are you sure, Do you want to add free item?";
            //    string title = "Are You Sure";
            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult result = MessageBox.Show(message, title, buttons);
            //    if (result == DialogResult.Yes)
            //    {
            //        if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            //        {
            //            int itemid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //            string itemName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //            float price = (float)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            //            int checkrow2 = 0;
            //            foreach (DataGridViewRow row in dataGridView2.Rows)
            //            {
            //                if (row.Cells[0].Value != null)
            //                {

            //                    int griditemid = Convert.ToInt32(row.Cells[0].Value.ToString());
            //                    if (griditemid == itemid && row.Cells[6].Value.Equals(1))
            //                    {
            //                        int newqty = Convert.ToInt32(row.Cells[3].Value.ToString()) + 1;
            //                        row.Cells[3].Value = newqty;
            //                        row.Cells[4].Value = (float)Convert.ToDouble(newqty * price);
            //                        row.Cells[5].Value = 0;
            //                        row.Cells[6].Value = 1;
            //                        checkrow2 = 1;
            //                        getTotal();
            //                        row.DefaultCellStyle.BackColor = Color.OrangeRed;
            //                        row.DefaultCellStyle.ForeColor = Color.White;
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        //float totamount = (float)Convert.ToDouble(price) * 1;
            //                        //dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount);
            //                        //break;
            //                    }
            //                }
            //                else
            //                {
            //                    float totamount2 = (float)Convert.ToDouble(price) * 1;
            //                    dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount2, 0, 1);
            //                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
            //                    row.DefaultCellStyle.ForeColor = Color.White;
            //                    checkrow2 = 1;
            //                    getTotal();
            //                    break;
            //                }

            //            }

            //            if (checkrow2 == 0)
            //            {
            //                float totamount = (float)Convert.ToDouble(price) * 1;
            //                dataGridView2.Rows.Add(itemid, itemName, price, 1, totamount, 0, 1);
            //                int index = dataGridView2.Rows.Count - 1;
            //                dataGridView2.Rows[index].DefaultCellStyle.BackColor = Color.Pink;
            //                getTotal();
            //            }
            //        }

            //        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            //        btnDelete.DefaultCellStyle.BackColor = Color.Red;
            //        btnDelete.DefaultCellStyle.ForeColor = Color.White;

            //        if (dataGridView2.Columns.Contains(btnDelete.Name = "Delete"))
            //        {

            //        }
            //        else
            //        {
            //            dataGridView2.Columns.Add(btnDelete);
            //        }

            //        btnDelete.FlatStyle = FlatStyle.Flat;
            //        btnDelete.HeaderText = "Delete";
            //        btnDelete.Name = "Delete";
            //        btnDelete.Text = "Delete";
            //        btnDelete.UseColumnTextForButtonValue = true;
            //        btnDelete.Width = 60;
            //    }
            //    else
            //    {

            //    }

            //}


        }

        private void getTotal()
        {
            float totalAMount = 0;
            float net = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    totalAMount = totalAMount + (float)Convert.ToDouble(row.Cells[5].Value.ToString());
                }
            }

            if(txtdiscount.Text != "")
            {
                net = (totalAMount + (totalAMount * ((float)Convert.ToDouble(txtServiceCharge.Text)) / 100) - (totalAMount *((float)Convert.ToDouble(txtdiscount.Text)) / 100));
            }
            
            else
            {
                net = totalAMount;
            }

            


            lbltot.Text = totalAMount.ToString();
            txtnet.Text = net.ToString();

        }
        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                dataGridView2.Rows.Remove(dataGridView2.Rows[e.RowIndex]);
                getTotal();
            }

            if(e.ColumnIndex==8)
            {
                int griditemid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                FreeItem(griditemid);
                dataGridView2.Rows.Remove(dataGridView2.Rows[e.RowIndex]);
                getTotal();

            }
        }

        

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            if(lbltot.Text =="")
            {
                MessageBox.Show("Please Add items before discount",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                txtdiscount.Text = "";
            }
            else
            {
                getTotal();
            }
        }

        private void txtnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtchashierIdentifier.Text = "";
                pnlcusdetails.Hide();
                
                customerCheck();
            }
        }
        Timer timer1 = new Timer();
        private void customerCheck()
        {
            //Regex r = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$");
            //Match m = r.Match(txtnumber.Text);

            //if(m.Success == false)
            //{
            //    MessageBox.Show("Invalid Phone Number",
            //   "Important Note",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Exclamation,
            //    MessageBoxDefaultButton.Button1);
                
            //}
            //else
            //{
                string phoneNumber = txtnumber.Text;
                txtnumber.Text = "";
                int customerCount = (from row in entities.Customers
                                     where row.Mobile == phoneNumber
                                     select row).Count();

                if(customerCount>0)
                {
                    var cusdetails = (from row in entities.Customers
                                      where row.Mobile == phoneNumber

                                      select row).FirstOrDefault();

                    lblcusname.Text = cusdetails.Name;
                    lblcusphone.Text = cusdetails.Mobile;
                    txtcusIDhid.Text = cusdetails.CID.ToString();
                    timer2.Stop();
                    pnlnumsales.Show();
                    pnlcusdetails.Show();

                    int billcount = (from row in entities.Bills
                                     where row.PhoneNumber == phoneNumber

                                     select row).Count();
                    if(phoneNumber=="0")
                    {
                        lblsalles.Text = "Regular";
                    }
                    else
                    {
                        lblsalles.Text = billcount.ToString();
                    }
                    

                    
                }
                else
                {
                    txtchashierIdentifier.Text = "";
                    SetCashcustomerreg = 1;
                    SetCashcusNumber = phoneNumber;
                    CustomerRegistation customerform = new CustomerRegistation();
                    customerform.TopMost = true;
                    customerform.Show();

                   
                    timer2.Interval = (1 * 1000); // 10 secs
                    timer2.Tick += new EventHandler(GetcashIdentiti);
                    timer2.Start();

                }
            //}

            
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            int gridcount = dataGridView2.Rows.Count;
            if(txtcusIDhid.Text == "" || string.IsNullOrEmpty(cmbsaleType.Text) ||gridcount == 0)
            {
                if(txtcusIDhid.Text == "")
                {
                    MessageBox.Show("Please Select customer",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                }

                if (gridcount == 0)
                {
                    MessageBox.Show("Please Add Items",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                }

                if (string.IsNullOrEmpty(cmbsaleType.Text))
                {
                    MessageBox.Show("Please Select Sales Type",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                }
            }

            else
            {
                billsave();
            }
        }

        private void billsave()
        {


            float discount = 0;
            float serviceCharge = 0;
            float net = 0;

            String today22 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todateCon22 = Convert.ToDateTime(today22);
            var CashInHandCount = (from row in entities.CashInHands
                                   where row.Date == todateCon22
                                  select new { row.CashInHand1}).FirstOrDefault();
            float cashinhand = (float)Convert.ToDouble(CashInHandCount.CashInHand1);

            if(txtdiscount.Text =="" || txtServiceCharge.Text=="")
            {
                discount = 0;
                serviceCharge = 0;
                net = (float)Convert.ToDouble(lbltot.Text);
            }
            else
            {
                discount = (float)Convert.ToDouble(txtdiscount.Text);
                serviceCharge = (float)Convert.ToDouble(txtServiceCharge.Text);
                net = (float)Convert.ToDouble(lbltot.Text) + (((float)Convert.ToDouble(lbltot.Text) * (float)Convert.ToDouble(txtServiceCharge.Text)) / 100) - (((float)Convert.ToDouble(lbltot.Text) * (float)Convert.ToDouble(txtdiscount.Text))/100);
            }

            int sectionType = Convert.ToInt16(cmbsaleType.SelectedValue.ToString());
            string paymentType = cmbPayType.Text;

            int BillCount = entities.Bills.DefaultIfEmpty().Max(r => r == null ? 1 : r.id);
            int billCountIncrement = BillCount;
            string billNoset = "BN" + billCountIncrement.ToString().PadLeft(3, '0');

            //Random rand = new Random();
            string currentTime = DateTime.Now.ToString("HH:mm:ss tt");
            //DateTime time = Convert.ToDateTime(currentTime);
            string BillNumber = billNoset;
            billnumber = BillNumber;
            DateTime today = DateTime.Today;
            Bill bill = new Bill();
            bill.BillNo = BillNumber;
            bill.CustomerId =Convert.ToInt32(txtcusIDhid.Text);
            bill.UserId = Convert.ToInt32(txtcashierIdhid.Text);
            bill.UserName = txtcashier.Text;
            bill.Date = today;
            bill.Time = currentTime;
            bill.Total = (float)Convert.ToDouble(lbltot.Text);
            bill.Discount = discount;
            bill.NetAmount = net;
            bill.SecID = sectionType;
            bill.PhoneNumber = lblcusphone.Text;
            bill.ServiceCharge = serviceCharge;
            bill.PaymentType = paymentType;
            entities.Bills.Add(bill);
            entities.SaveChanges();

            float totalcashInhand = net + cashinhand;

            var cashHand2 = (from row in entities.CashInHands where row.Date == todateCon22 select row).FirstOrDefault();
            cashHand2.CashInHand1 = totalcashInhand;
           
            entities.SaveChanges();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    BillMst billmst = new BillMst();
                    billmst.BillNo = BillNumber;
                    billmst.ItemId = Convert.ToInt32(row.Cells[0].Value);
                    billmst.ItemName = row.Cells[1].Value.ToString();
                    billmst.Price = (float)Convert.ToDouble(row.Cells[2].Value.ToString());
                    billmst.Qty = Convert.ToInt32(row.Cells[3].Value);
                    billmst.TotalAmount = (float)Convert.ToDouble(row.Cells[4].Value.ToString());
                    billmst.Isfree = Convert.ToBoolean(row.Cells[6].Value);
                    entities.BillMsts.Add(billmst);
                    entities.SaveChanges();
                }
            }

            MessageBox.Show("Save Completed");
            timer2.Stop();
           
            dataGridView2.Rows.Clear();
            txtcusIDhid.Text = "";
            txtchashierIdentifier.Text = "";
            txtdiscount.Text = "";
            txtnet.Text = "";
            lbltot.Text = "";
            txtnumber.Text = "";
            pnlcusdetails.Hide();
            pnlnumsales.Hide();
            panel7.Controls.Clear();
            getSalesType();



            var billPrint = (from billprint in entities.Bills
                             join billmstprint in entities.BillMsts on billprint.BillNo equals billmstprint.BillNo
                             where billprint.BillNo == BillNumber
                             select new { billprint.BillNo, billprint.Date, billprint.Time, billprint.Total, billprint.Discount,billprint.ServiceCharge, billprint.UserName, billprint.NetAmount, billmstprint.ItemName, billmstprint.Price, billmstprint.Qty, billmstprint.TotalAmount, billmstprint.Isfree }).ToList();

            string reportPath = ConfigurationManager.AppSettings["ReportPath"];
            string ConnectReport = reportPath + "Bill.rpt";
            ReportDocument rprt = new ReportDocument();
            rprt.Load(@ConnectReport);
            rprt.SetDataSource(billPrint);
            rprt.PrintOptions.PrinterName = "RP80 Printer";
            rprt.PrintToPrinter(1, true, 1, 1);

           
            //Billviewer bill2 = new Billviewer();
            //bill2.TopMost = true;
            //bill2.Show();

            


        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtServiceCharge_TextChanged(object sender, EventArgs e)
        {
            if(txtServiceCharge.Text=="")
            {
                txtServiceCharge.Text = "0";
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }



    public class ContViewModel2
    {
        public int id2 { get; set; }
        public string Name2 { get; set; }



    }
}
