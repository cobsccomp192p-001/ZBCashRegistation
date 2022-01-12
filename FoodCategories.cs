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
    public partial class FoodCategories : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public FoodCategories()
        {
            InitializeComponent();
            loadCategory();
            txthidCid.Hide();
            btnUpdate.Hide();
            btncancel.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtcate.Text=="")
            {
                MessageBox.Show("Please Enter Category",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                
                FoodCAT foodcate = new FoodCAT();
                foodcate.CATName = txtcate.Text;
                entities.FoodCATs.Add(foodcate);
                entities.SaveChanges();

                MessageBox.Show("Save Completed");
                txtcate.Text = "";
                loadCategory();
            }
        }

        private void FoodCategories_Load(object sender, EventArgs e)
        {

        }

        private void loadCategory()
        {
           
            var FoodCategories = (from row in entities.FoodCATs
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

            if(dataGridView1.Columns.Contains(editbtn.Name = "Edit"))
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
            deletebtn.Width =60;
            
            

            

            
            dataGridView1.Rows.Clear();
            foreach (var user in FoodCategories)
            {
                if(user.CATName!= "")
                {
                    dataGridView1.Rows.Add(user.CATName, user.CATID);
                }
                
            }
            
            //dgv.DataBind();
            

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value!= null)
                {
                    txthidCid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtcate.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    btnUpdate.Show();
                    btncancel.Show();
                    button1.Hide();
                }
                
            }

            if(e.ColumnIndex == 3)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int cid = Convert.ToInt16( dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DialogResult result1 = MessageBox.Show("Are You sure , You want to delete this",
                    "Important Question",
                     MessageBoxButtons.YesNo);
                    if (result1.ToString() == "Yes")
                    {
                        DeleteCategory(cid);
                    }

                    
                }
            }
        }

        private void DeleteCategory(int cid)
        {
            
            int count = (from row in entities.FoodItems
                        where row.CATID == cid 
                        select row).Count();

            if(count>0)
            {
                MessageBox.Show("Cannot delete this category, Existing Food Items availible for this category",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                var remove = (from row in entities.FoodCATs
                              where row.CATID == cid

                              select row).FirstOrDefault();

                if (remove != null)
                {
                    entities.FoodCATs.Remove(remove);
                    entities.SaveChanges();
                    loadCategory();
                }
            }


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txthidCid.Text = "";
            txtcate.Text = "";
            btnUpdate.Hide();
            btncancel.Hide();
            button1.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtcate.Text=="")
            {
                MessageBox.Show("Please Enter Category",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                updatecategory();
            }
        }

        private void updatecategory()
        {
            int cid = Convert.ToInt16(txthidCid.Text);
            var s = (from row in entities.FoodCATs where row.CATID == cid select row).FirstOrDefault();
            s.CATName = txtcate.Text;
            entities.SaveChanges();

            MessageBox.Show("Update Completed");
            txthidCid.Text = "";
            txtcate.Text = "";
            btnUpdate.Hide();
            btncancel.Hide();
            button1.Show();

            loadCategory();

        }
    }
}
