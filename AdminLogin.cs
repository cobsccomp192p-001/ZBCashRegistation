using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using ZBCashRegistation;



namespace ZBCashRegistation
{
    public partial class AdminLogin : Form
    {
        public static int SetIsAdmin = 0;
        public static string SetUserName = "";
        public static int SetUserID = 0;
        
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string username = txtUser.Text;
            string password = txtPass.Text;
            
            
            SetIsAdmin = 0;
            SetUserName = "";
            SetUserID = 0;

            if(username == "" || password == "")
            {
                if(username == "")
                {
                    MessageBox.Show("Please enter User name");
                }
                else if(password == "")
                {
                    MessageBox.Show("Please enter Password");
                }
            }
            else
            {
                ZBcashRegEntities entities = new ZBcashRegEntities();
                var User = (from row in entities.Users
                             where row.Username == username && row.Password == password 
                             select row);

                foreach (var user in User)
                {
                    SetIsAdmin = Convert.ToInt16( user.IsAdmin);
                    SetUserName = user.Username;
                    SetUserID = Convert.ToInt16(user.UID);
                }
  

                if(SetUserID!=0)
                {

                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Incorrect UserName and Password");
                }

                //if(count> 0 )
                //{
                   // MessageBox.Show("done");
                //}
                //else
                //{
                   // MessageBox.Show("Incorrect UserName and Password");
                //}
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();            System.Environment.Exit(1);
            Application.Restart();
        }
    }
}
