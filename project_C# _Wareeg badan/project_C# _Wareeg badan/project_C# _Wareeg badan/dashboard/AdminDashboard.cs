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

namespace dashboard
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            SetUserRoles();

            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand = new SqlCommand("select sum(BloodUnit) from BloodA", mainClas.con);
            var sql = sqlCommand.ExecuteScalar();
            LabA.Text = sql.ToString();
            SqlCommand sqlCommand1 = new SqlCommand("select sum(BloodUnit) from BloodB", mainClas.con);
            var sql1 = sqlCommand1.ExecuteScalar();
            LabB.Text = sql1.ToString();
            //SqlCommand sqlCommand2= new SqlCommand("select sum(d) from Blood0", mainClas.con);
            SqlCommand sqlCommand2= new SqlCommand("select sum(BloodUnit) from BloodO", mainClas.con);
            var sql2 = sqlCommand2.ExecuteScalar();
            LabO.Text = sql2.ToString();

            SqlCommand sqlCommand3 = new SqlCommand("select sum(BloodUnit) from BloodAB", mainClas.con);
            var sql3 = sqlCommand3.ExecuteScalar();
            LabAB.Text = sql3.ToString();

            SqlCommand sqlCommand4 = new SqlCommand("select sum(BloodUnit) from BloodNegA", mainClas.con);
            var sql4 = sqlCommand4.ExecuteScalar();
            LabNegA.Text = sql4.ToString();

            SqlCommand sqlCommand5 = new SqlCommand("select sum(BloodUnit) from bloodNegB", mainClas.con);
            var sql5 = sqlCommand5.ExecuteScalar();
            LabNegB.Text = sql5.ToString();

            SqlCommand sqlCommand6 = new SqlCommand("select sum(BloodUnit) from BloodNegO", mainClas.con);
            var sql6 = sqlCommand6.ExecuteScalar();
            LabNegO.Text = sql6.ToString();

            SqlCommand sqlCommand7 = new SqlCommand("select sum(BloodUnit) from BloodNegAB", mainClas.con);
            var sql7= sqlCommand7.ExecuteScalar();
            LabNegAB.Text = sql7.ToString();


            SqlCommand sqlCommand8 = new SqlCommand("select count(*) from  Donors", mainClas.con);
            var sql8 = sqlCommand8.ExecuteScalar();
            lblTotalDonor.Text = sql8.ToString();

            SqlCommand sqlCommand9 = new SqlCommand("select count(*) from  Recipients", mainClas.con);
            var sql9 = sqlCommand9.ExecuteScalar();
            lblTotalRec.Text = sql9.ToString();

            SqlCommand sqlCommand10 = new SqlCommand("select count(*) from  Recipients", mainClas.con);
            var sql10 = sqlCommand10.ExecuteScalar();
            lblTotalAproved.Text = sql10.ToString();

            SqlCommand sqlCommand11 = new SqlCommand("select sum(BloodUnit) from Donors ", mainClas.con);
            var sql11 = sqlCommand11.ExecuteScalar();
            lblTotalUnit.Text = sql11.ToString();


            mainClas.Disconnect();

        }

        private void label1_Click(object sender, EventArgs e)
        {
           Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label31_Click(object sender, EventArgs e)
        {
      Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click_1(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }
        private void SetUserRoles()
        {
            if (MainClass.UserType == "Admin")
            {
              
            }
            else
            {
                // DashDonors.Enabled = false;
                Departments users = new Departments();
                label32.Enabled = false;
             
                label31.Enabled = false;
                
                label30.Enabled = false;
                label3.Enabled=false;
                label38.Enabled=false;
               
            }
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {
            /// report
         
          REportform form = new REportform();
            form.ShowDialog();
        }

       

        private void LabA_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand = new SqlCommand("select sum(BloodUnit) from BloodA", mainClas.con);
            var sql = sqlCommand.ExecuteScalar();
            LabA.Text = sql.ToString();
            mainClas.Disconnect();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LabB_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand1 = new SqlCommand("select sum(BloodUnit) from BloodB", mainClas.con);
            var sql1 = sqlCommand1.ExecuteScalar();
            LabB.Text = sql1.ToString();
            mainClas.Disconnect();
        }

        private void LabO_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand2 = new SqlCommand("select sum(BloodUnit) from BloodO", mainClas.con);
            var sql2 = sqlCommand2.ExecuteScalar();
            LabO.Text = sql2.ToString();
            mainClas.Disconnect();
        }

        private void LabAB_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand3 = new SqlCommand("select sum(BloodUnit) from BloodAB", mainClas.con);
            var sql3 = sqlCommand3.ExecuteScalar();
            LabAB.Text = sql3.ToString();
            mainClas.Disconnect();
        }

        private void LabNegA_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand4 = new SqlCommand("select sum(BloodUnit) from BloodNegA", mainClas.con);
            var sql4 = sqlCommand4.ExecuteScalar();
            LabNegA.Text = sql4.ToString();
            mainClas.Disconnect();
        }

        private void LabNegB_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand5 = new SqlCommand("select sum(BloodUnit) from bloodNegB", mainClas.con);
            var sql5 = sqlCommand5.ExecuteScalar();
            LabNegB.Text = sql5.ToString();
            mainClas.Disconnect();
        }

        private void LabNegO_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand6 = new SqlCommand("select sum(BloodUnit) from BloodNegO", mainClas.con);
            var sql6 = sqlCommand6.ExecuteScalar();
            LabNegO.Text = sql6.ToString();
            mainClas.Disconnect();
        }

        private void LabNegAB_Click(object sender, EventArgs e)
        {
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand7 = new SqlCommand("select sum(BloodUnit) from BloodNegAB", mainClas.con);
            var sql7 = sqlCommand7.ExecuteScalar();
            LabNegAB.Text = sql7.ToString();
            mainClas.Disconnect();
        }
    }
}
