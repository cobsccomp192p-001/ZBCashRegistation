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
    public partial class EmployeeRegistation : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public EmployeeRegistation()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$");
            Match m1 = r.Match(txtempphone1.Text);
            Match m2 = r.Match(txtempphone2.Text);
            if (txtempname.Text == "" || txtaddress.Text == "" || txtdesignation.Text == "" || m1.Success == false || m2.Success == false)
            {
                if (txtempname.Text == "" || txtaddress.Text == "" || txtdesignation.Text == "")
                {
                    MessageBox.Show("Required fields avalible Please check the form again",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
                if (m1.Success == false || m2.Success == false)
                {
                    MessageBox.Show("Invalid Phone Numbers",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }

            }
            else
            {
                saveEmployee();
            }
        }

        private void saveEmployee()
        {




                Employee emp = new Employee();
                emp.Name = txtempname.Text;
                emp.Mobile1 = txtempphone1.Text;
                emp.Mobile2 = txtempphone2.Text;
                emp.Address = txtaddress.Text;
                emp.Designation = txtdesignation.Text;

                entities.Employees.Add(emp);
                entities.SaveChanges();

                MessageBox.Show("Save Completed");

                txtempname.Text = "";
                txtempphone1.Text = "";
                txtempphone2.Text = "";
                txtaddress.Text = "";
                txtdesignation.Text = "";
                loadEmp();
                
            




        }

        private void EmployeeRegistation_Load(object sender, EventArgs e)
        {
            txtempphone1.MaxLength = 10;
            txtempphone2.MaxLength = 10;
            txthidempno.Hide();
            btnupdate.Hide();
            btncancel.Hide();
            loadEmp();

        }

        private void loadEmp()
        {
            var EMP = (from row in entities.Employees
                             orderby row.EmpID descending
                             select row);

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = FoodCategories;
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

            if (dataGridView1.Columns.Contains(editbtn.Name = "Edit"))
            {

            }
            else
            {
                dataGridView1.Columns.Add(editbtn);
            }


            if (dataGridView1.Columns.Contains(deletebtn.Name = "Delete"))
            {

            }
            else
            {
                dataGridView1.Columns.Add(deletebtn);
            }


            editbtn.FlatStyle = FlatStyle.Flat;
            editbtn.HeaderText = "Edit";
            editbtn.Name = "Edit";
            editbtn.Text = "Edit";
            editbtn.UseColumnTextForButtonValue = true;
            editbtn.Width = 30;


            deletebtn.FlatStyle = FlatStyle.Flat;
            deletebtn.HeaderText = "Delete";
            deletebtn.Name = "Delete";
            deletebtn.Text = "Delete";
            deletebtn.UseColumnTextForButtonValue = true;
            deletebtn.Width = 60;






            dataGridView1.Rows.Clear();
            foreach (var user in EMP)
            {
                if (user.EmpID != 0)
                {
                    dataGridView1.Rows.Add(user.EmpID, user.Name, user.Mobile1,user.Mobile2,user.Address,user.Designation);
                }

            }

            //dgv.DataBind();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txthidempno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtempname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtempphone1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtempphone2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtdesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    btnupdate.Show();
                    btncancel.Show();
                    btnsave.Hide();
                }

            }

            if (e.ColumnIndex == 7)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int eid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DialogResult result1 = MessageBox.Show("Are You sure , You want to delete this",
                    "Important Question",
                     MessageBoxButtons.YesNo);
                    if (result1.ToString() == "Yes")
                    {
                        DeleteEMP(eid);
                    }


                }
            }
        }

        private void DeleteEMP(int eid)
        {

            var remove = (from row in entities.Employees
                          where row.EmpID == eid

                          select row).FirstOrDefault();

            if (remove != null)
            {
                entities.Employees.Remove(remove);
                entities.SaveChanges();
                loadEmp();
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txthidempno.Text = "";
            txtempname.Text = "";
            txtempphone1.Text = "";
            txtempphone2.Text = "";
            txtaddress.Text = "";
            txtdesignation.Text = "";

            btncancel.Hide();
            btnupdate.Hide();
            btnsave.Show();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$");
            Match m1 = r.Match(txtempphone1.Text);
            Match m2 = r.Match(txtempphone2.Text);
            if (txtempname.Text == "" || txtaddress.Text == "" || txtdesignation.Text == "" || m1.Success == false || m2.Success == false)
            {
                if (txtempname.Text == "" || txtaddress.Text == "" || txtdesignation.Text == "")
                {
                    MessageBox.Show("Required fields avalible Please check the form again",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
                if (m1.Success == false || m2.Success == false)
                {
                    MessageBox.Show("Invalid Phone Numbers",
                  "Important Note",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }

            }
            else
            {
                UpdateEmployee();
            }
        }

        private void UpdateEmployee()
        {
            int empId = Convert.ToInt32(txthidempno.Text);
            var emp = (from row in entities.Employees where row.EmpID == empId select row).FirstOrDefault();
            emp.Name = txtempname.Text;
            emp.Mobile1 = txtempphone1.Text;
            emp.Mobile2 = txtempphone2.Text;
            emp.Address = txtaddress.Text;
            emp.Designation = txtdesignation.Text;
            entities.SaveChanges();

            MessageBox.Show("Update Completed");
            btnupdate.Hide();
            btncancel.Hide();
            btnsave.Show();
            txthidempno.Text = "";
            txtempname.Text = "";
           
            txtempphone1.Text = "";
            txtempphone2.Text = "";
            txtaddress.Text = "";
            txtdesignation.Text = "";
            loadEmp();
        }
    }
}
