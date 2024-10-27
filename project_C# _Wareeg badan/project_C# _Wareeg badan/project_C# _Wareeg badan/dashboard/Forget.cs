using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboard
{

    public partial class Forget : Form
    {
        MainClass mainClas = new MainClass();
        String query;
        public Forget()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();

            mainClas.Connect();
            SqlCommand sqlCommand = new SqlCommand("select Email from   users where Email ='" + txtEmail.Text + "'", mainClas.con);
            var sql = sqlCommand.ExecuteScalar();
            if (sql != null && sql.ToString() == txtEmail.Text)

            {
                // MessageBox.Show("success");
                txtpas.Show();
                label1.Show();
                gunaupdate.Show();
                label2.Show();




            }


            else
            {
                MessageBox.Show("invalid");


            }
            mainClas.Disconnect();

        }

        private void Forget_Load(object sender, EventArgs e)
        {
            gunaupdate.Hide();
            txtpas.Hide();
            label2.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            query = "update Users set Password =" + txtpas.Text + " where  Email ='" + txtEmail.Text + "'";

            mainClas.ProcessData(query, mainClas.updateAlert);
            btnLogin.Hide();
          

            //MessageBox.Show("close  the form...... ")
        }
    }
}
