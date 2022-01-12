using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBCashRegistation
{
    public partial class Section : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public Section()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtsection.Text == "")
            {
                MessageBox.Show("Required fields avalible",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                saveSection();

            }
        }

        private void saveSection()
        {
            SalesType salesType = new SalesType();
            salesType.Section = txtsection.Text;

            entities.SalesTypes.Add(salesType);
            entities.SaveChanges();

            MessageBox.Show("Save Completed");
            txtsection.Text = "";
            loadSection();
            
        }

        private void loadSection()
        {
            var salesType = (from row in entities.SalesTypes
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
            foreach (var user in salesType)
            {
                if (user.id != 0)
                {
                    dataGridView1.Rows.Add(user.id, user.Section);
                }

            }
        }

        private void Section_Load(object sender, EventArgs e)
        {
            loadSection();
            btncancel.Hide();
            btnupdate.Hide();
            txthidsec.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txthidsec.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtsection.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    btnupdate.Show();
                    btncancel.Show();
                    btnsave.Hide();
                     
                }

            }

            if (e.ColumnIndex == 3)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int secid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DialogResult result1 = MessageBox.Show("Are You sure , You want to delete this",
                    "Important Question",
                     MessageBoxButtons.YesNo);
                    if (result1.ToString() == "Yes")
                    {
                        DeleteSection(secid);
                    }


                }
            }
        }

        private void DeleteSection(int secid)
        {

            
                var remove = (from row in entities.SalesTypes
                              where row.id == secid

                              select row).FirstOrDefault();

                if (remove != null)
                {
                    entities.SalesTypes.Remove(remove);
                    entities.SaveChanges();
                    loadSection();
                }
           


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txthidsec.Text = "";
            txtsection.Text = "";
            btnupdate.Hide();
            btncancel.Hide();
            btnsave.Show();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtsection.Text == "")
            {
                MessageBox.Show("Please Enter Section",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                updateSection();
            }
        }

        private void updateSection()
        {
            int SecID = Convert.ToInt16(txthidsec.Text);
            var s = (from row in entities.SalesTypes where row.id == SecID select row).FirstOrDefault();
            s.Section = txtsection.Text;
            entities.SaveChanges();

            MessageBox.Show("Update Completed");
            txthidsec.Text = "";
            txtsection.Text = "";
            btnupdate.Hide();
            btncancel.Hide();
            btnsave.Show();

            loadSection();

        }
    }
}
