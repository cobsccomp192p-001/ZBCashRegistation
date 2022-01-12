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
    public partial class cashInhandCashier : Form
    {
        ZBcashRegEntities entities = new ZBcashRegEntities();
        public cashInhandCashier()
        {
            InitializeComponent();
        }

        private void cashInhandCashier_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^-?[0-9]*\.?[0-9]+$"); 
            Match m = r.Match(txtcashinhand.Text);
            if(txtcashinhand.Text == "" || m.Success == false)
            {
                MessageBox.Show("Required fields avalible, please give valid date to field",
              "Important Note",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
               MessageBoxDefaultButton.Button1);
            }
            else
            {
                Savecashinhand();
            }
        }

        private void Savecashinhand()
        {
            float cashAmount = (float)Convert.ToDouble(txtcashinhand.Text);

            CashInHand cashinhand = new CashInHand();
            cashinhand.CashInHand1 = cashAmount;
            cashinhand.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            entities.CashInHands.Add(cashinhand);
            entities.SaveChanges();

            MessageBox.Show("Save Completed");
            txtcashinhand.Text ="";

            sales sec = new sales();
            sec.TopMost = true;
            sec.Show();
            this.Hide();
        }
    }
}
