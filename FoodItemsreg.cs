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
    public partial class FoodItemsreg : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public FoodItemsreg()
        {
            InitializeComponent();
        }

        private void FoodItemsreg_Load(object sender, EventArgs e)
        {
            loadCategoryCmb();
            LoadItems();
            btnsupdate.Hide();
            btncancel.Hide();
            txtitemhidId.Text = "";
            txtitemhidId.Hide();
        }

        private void LoadItems()
        {
            var fooditementities = from fooditem in entities.FoodItems
                                   join foodcate in entities.FoodCATs on fooditem.CATID equals foodcate.CATID
                                   select new { fooditem.ItemID, fooditem.ItemName, fooditem.Description, foodcate.CATName,foodcate.CATID,fooditem.Price };

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
            foreach (var user in fooditementities)
            {
                if (user.CATName != "")
                {
                    dataGridView1.Rows.Add(user.ItemID, user.ItemName,user.CATName,user.Price,user.Description,user.CATID);
                }

            }

            //dgv.DataBind();
        }

        private void loadCategoryCmb()
        {

            var Foodcategories = (from row in entities.FoodCATs
                                  select row);
            List<ContViewModel> ContAccesslist = new List<ContViewModel>();
            ContViewModel c3 = new ContViewModel();
            c3.id = 0;
            c3.Name = "";
            ContAccesslist.Add(c3);
            foreach (var foodItem in Foodcategories)
            {
                ContViewModel c2 = new ContViewModel();
                c2.id = foodItem.CATID;
                c2.Name = foodItem.CATName;
                ContAccesslist.Add(c2);

            }

        

            
            
            cmbcategory.DataSource = ContAccesslist;
           cmbcategory.DisplayMember = "Name";
           cmbcategory.ValueMember = "id";
           


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Regex r = new Regex(@"^-?[0-9]*\.?[0-9]+$"); 
            Match m = r.Match(txtPrice.Text);

            if (txtfoodname.Text == "" || string.IsNullOrEmpty(cmbcategory.Text) || m.Success == false)
            {
                MessageBox.Show("Required fields avalible",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                saveItem();
            }
        }

        private void saveItem()
        {
            float itemPrice = (float)Convert.ToDouble(txtPrice.Text);
            int itemCategoryId =Convert.ToInt16( cmbcategory.SelectedValue.ToString());
            FoodItem fooditem = new FoodItem();
            fooditem.ItemName = txtfoodname.Text;
            fooditem.Description = txtdescription.Text;
            fooditem.CATID = itemCategoryId;
            fooditem.Price = itemPrice;
            entities.FoodItems.Add(fooditem);
            entities.SaveChanges();

            MessageBox.Show("Save Completed");
            LoadItems();
            txtfoodname.Text = "";
            txtdescription.Text = "";
            txtPrice.Text = "";
            loadCategoryCmb();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int d = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    cmbcategory.SelectedValue = d;
                    txtitemhidId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtfoodname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtdescription.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    btnsupdate.Show();
                    btncancel.Show();
                    //button1.Hide();
                    btnUpdate.Hide();
                }

            }

            if (e.ColumnIndex == 7)
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
            
                var remove = (from row in entities.FoodItems
                              where row.ItemID == itemid

                              select row).FirstOrDefault();

                if (remove != null)
                {
                    entities.FoodItems.Remove(remove);
                    entities.SaveChanges();
                    LoadItems();
                }
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnsupdate.Hide();
            btncancel.Hide();
            btnUpdate.Show();
            txtfoodname.Text = "";
            txtdescription.Text = "";
            loadCategoryCmb();
            txtitemhidId.Text = "";
            txtPrice.Text = "";
        }

        private void btnsupdate_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^-?[0-9]*\.?[0-9]+$");
            Match m = r.Match(txtPrice.Text);
            if (txtfoodname.Text == "" || string.IsNullOrEmpty(cmbcategory.Text) || m.Success == false)
            {
                MessageBox.Show("Required fields avalible",
               "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                updateItem();
            }
        }

        private void updateItem()
        {
            float itemPrice = (float)Convert.ToDouble(txtPrice.Text);
            int itemCategoryId = Convert.ToInt16(cmbcategory.SelectedValue.ToString());
            int itemId = Convert.ToInt16(txtitemhidId.Text);
            var s = (from row in entities.FoodItems where row.ItemID == itemId select row).FirstOrDefault();
            s.ItemName = txtfoodname.Text;
            s.Description = txtdescription.Text;
            s.CATID = itemCategoryId;
            s.Price = itemPrice;
            entities.SaveChanges();

            MessageBox.Show("Update Completed");
            btnsupdate.Hide();
            btncancel.Hide();
            btnUpdate.Show();
            txtfoodname.Text = "";
            txtdescription.Text = "";
            loadCategoryCmb();
            txtitemhidId.Text = "";
            txtPrice.Text = "";
            LoadItems();


        }
    }



    

    public class ContViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        


    }
}
