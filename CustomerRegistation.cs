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

namespace ZBCashRegistation
{
    public partial class CustomerRegistation : Form
    {
        int cashierCustomerset = 0;
        string cashierCusphone = "";
        public static string SetCashcusidentifier = "";
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public CustomerRegistation()
        {
            InitializeComponent();
        }

        private void btnUSave_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$"); 
            Match m = r.Match(txtphone.Text);
            if(txtName.Text == "" || txtphone.Text =="" || m.Success == false)
            {
                if (txtName.Text == "" )
                {
                    MessageBox.Show("Required fields avalible Please check the form again",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
                if(m.Success == false)
                {
                    MessageBox.Show("Invalid Phone Number",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
               
            }
            else
            {
                saveCustomer();
            }
        }


        private void LoadCustomer()
        {
            var Customers = (from row in entities.Customers
                             orderby row.CID descending
                             select row);

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = FoodCategories;
            if(cashierCustomerset == 0)
            {
                DataGridViewButtonColumn editbtn = new DataGridViewButtonColumn();
                DataGridViewButtonColumn deletebtn = new DataGridViewButtonColumn();

                deletebtn.DefaultCellStyle.BackColor = Color.Red;
                deletebtn.DefaultCellStyle.ForeColor = Color.White;

                editbtn.DefaultCellStyle.BackColor = Color.Blue;
                editbtn.DefaultCellStyle.ForeColor = Color.White;

                //dataGridView1.Columns[0].Width = 60;
                //dataGridView1.Columns[1].Width = 100;
                //dataGridView1.Columns[2].Width =60;
                //dataGridView1.Columns[3].Width = 20;




                if (dataGridView1.Columns.Contains(deletebtn.Name = "Delete"))
                {

                }
                else
                {
                    dataGridView1.Columns.Add(deletebtn);
                }





                deletebtn.FlatStyle = FlatStyle.Flat;
                deletebtn.HeaderText = "Delete";
                deletebtn.Name = "Delete";
                deletebtn.Text = "Delete";
                deletebtn.UseColumnTextForButtonValue = true;
                deletebtn.Width = 60;
            }
            






            dataGridView1.Rows.Clear();
            foreach (var user in Customers)
            {
                if (user.CID != 0)
                {
                    dataGridView1.Rows.Add(user.CID, user.Name, user.Mobile);
                }

            }

            //dgv.DataBind();
        }

        private void saveCustomer()
        {
            int customerCount = (from row in entities.Customers
                        where row.Mobile == txtphone.Text 
                        select row).Count();

            if(customerCount>0)
            {
                MessageBox.Show("Cannot save this customer,Existing Mobile Number Avalible ",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                if(cashierCustomerset == 1)
                {
                    Random r = new Random();
                    string random = r.Next().ToString();
                    Customer customer = new Customer();
                    customer.Mobile = txtphone.Text;
                    customer.Name = txtName.Text;
                    customer.cashierIdenti = random;

                    entities.Customers.Add(customer);
                    entities.SaveChanges();

                    SetCashcusidentifier = random;
                    txtName.Text = "";
                    txtphone.Text = "";
                    LoadCustomer();
                    
                    



                }
                else
                {
                    Customer customer = new Customer();
                    customer.Mobile = txtphone.Text;
                    customer.Name = txtName.Text;

                    entities.Customers.Add(customer);
                    entities.SaveChanges();

                    MessageBox.Show("Save Completed");

                    txtName.Text = "";
                    txtphone.Text = "";
                    LoadCustomer();
                }
                
            }


           
            
        }

        private void CustomerRegistation_Load(object sender, EventArgs e)
        {
             cashierCustomerset = sales.SetCashcustomerreg;
            cashierCusphone = sales.SetCashcusNumber;
            SetCashcusidentifier = "";
            txtphone.MaxLength = 10;
            LoadCustomer();
            txthidcusId.Hide();
            btncancel.Hide();
            if(cashierCustomerset == 1)
            {
                txtphone.Text = cashierCusphone;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.ColumnIndex == 3)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int itemid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DialogResult result1 = MessageBox.Show("Are You sure , You want to delete this",
                    "Important Question",
                     MessageBoxButtons.YesNo);
                    if (result1.ToString() == "Yes")
                    {
                        Deleteitem(itemid);
                    }


                }
            }
        }

        private void Deleteitem(int itemid)
        {

            var remove = (from row in entities.Customers
                          where row.CID == itemid

                          select row).FirstOrDefault();

            if (remove != null)
            {
                entities.Customers.Remove(remove);
                entities.SaveChanges();
                LoadCustomer();
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            
            btncancel.Hide();
            btnUSave.Show();
             txtName.Text = "";
               txtphone.Text = "";
            
            txthidcusId.Text = "";
            
        }

        

       
    }
}
