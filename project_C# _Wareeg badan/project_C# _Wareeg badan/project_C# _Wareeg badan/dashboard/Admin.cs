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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace dashboard
{
    public partial class Admin : Form
    {
        public bool LoginSuccessful=false;
        MainClass mc = new MainClass();


        public Admin()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {

           
        }





        private void Admin_Load(object sender, EventArgs e)
        {
           mc.con.Close();
           //if(UserType)
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (mc.cmd = new SqlCommand("select UserType from users where UserName='" + txtUsername.Text +
                    "' and Password='" + txtPassword.Text + "'", mc.con))
                {
                    mc.Connect();
                    SqlDataReader dr = mc.cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MainClass.UserType = dr.GetValue(0).ToString();
                        LoginSuccessful = true;

                        AdminDashboard adminDashboard = new AdminDashboard();
                      
                        adminDashboard.Show();

                    }
                    else
                    {
                        LoginSuccessful = false;
                        MessageBox.Show("Invalid username or password.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    mc.Disconnect();
                }
            }
            catch { mc.Disconnect(); }



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Forget forget = new Forget();
            forget.ShowDialog();
        }
        

    }

    //private void label5_Click(object sender, EventArgs e)
    //    {
    //        SingUp singUp = new SingUp();
    //        singUp.Show();
    //    }
    }

