using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dashboard
{
    public partial class CreateUsers : Form
    {
       MainClass mc = new MainClass();
        string query;
        String Gender;
        int ID ;
        public CreateUsers()
        {
            InitializeComponent();
        }

        private void town_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtnumber_TextChanged(object sender, EventArgs e)
        {
            string input = txtFirst.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }


        private void CreateUsers_Load(object sender, EventArgs e)
        {
            Reset();
            ValidateEmail();



            MainClass mainClas = new MainClass();
            mainClas.Connect();
            //SqlCommand sqlCommand = new SqlCommand("select userID from users;", mainClas.con);
            //var sql = sqlCommand.ExecuteScalar();
         

            int generateId;
            generateId = mainClas.idGenerator("select count(userID) from users;");
            txtId.Text = generateId.ToString();




        }
        //
        private void Reset()
        {
            mc.Display("select * from Users", dataGridView1);
            cboxLevel.SelectedIndex = 0;
            mc.Clear(txtId, txtUsername, txtPassword, txtPhone, textAddress, txtUsername, textEmail,cboxLevel);
        }


       

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
           
        }

    

         
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            mc.Display("select * from Users where Username like '%" + txtSearch.Text + "%'", dataGridView1);
        }




        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog(this);   
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog(this);
        }

        private void rdboxmale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";

        }

        private void rdboxfemale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void ValidateEmail()
        {
            string input = textEmail.Text;
            string pattern = @"^[a-z0-9]+@gmail\.com$";

            if (Regex.IsMatch(input, pattern))
            {
                chekInput.Text = "Valid Email";
                chekInput.ForeColor = System.Drawing.Color.Green;
                // Additional actions for valid email
            }
            else
            {
                chekInput.Text = "Invalid Email";
                chekInput.ForeColor = System.Drawing.Color.Red;
                // Additional actions for invalid email
            }
        }



























        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            string input = textEmail.Text;
            string pattern = @"^[a-z0-9]+@gmail\.com$";

            if (Regex.IsMatch(input, pattern))
            {
                chekInput.Text = "";
            }
            else
            {
                chekInput.Text = "invalid";
            }
            //string input = textEmail.Text;
            //if (!int.TryParse(input, out _))
            //{
            //    chekInput.Text = "";

            //}
            //else
            //{
            //    chekInput.Text = "invalid";
            //}
        }



       





      

       

        private void gunaBtnSave_Click_1(object sender, EventArgs e)
        {

            string input = txtFirst.Text;
            string input1 = txtLast.Text;
            string input2 = txtUsername.Text;
            string input3 = textAddress.Text;
         




            if (txtPassword.Text == txtconfirm.Text
                && IsValidInput(input) && IsValidInput(input1) && IsValidInput(input2) && IsValidInput(input3) )

            {




                if (cboxLevel.SelectedIndex != 0)
                {
                    query = "insert into Users values(" + txtId.Text + ",'" + txtFirst.Text + "','" + txtLast.Text + "','"
                        + txtPhone.Text + "','" + textAddress.Text + "','" + txtUsername.Text + "'," + txtPassword.Text +
                        ",'" + textEmail.Text + "','" + dateTimePicker2.Text + "','" + Gender + "','" + cboxLevel.Text + "')";

                    mc.ProcessData(query, mc.saveAlert);
                    //mc.ProcessData(query, mc.checkinputString(txtFirst.Text));

                    Reset();
                    MainClass mainClas = new MainClass();
                    mainClas.Connect();
                    int generateId;
                    generateId = mainClas.idGenerator("select count(userID) from users;");
                    txtId.Text = generateId.ToString();


                   // MessageBox.Show("valid");

                }

                else
                {
                    MessageBox.Show("select user type");
                }


            }


            else
            {
                //MessageBox.Show("Password mismatch");
                MessageBox.Show("invalid input");
            }

        }

        private void gunabtnUpdate_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtconfirm.Text)
            {

                //if (rdboxfemale.Checked)
                //{
                //    Gender = "Female";
                //}
                //else
                //{
                //    Gender = "Male";
                //}

                //  if (cboxLevel.SelectedIndex != 0)
                {
                    query = "update Users set FirstName='" + txtFirst.Text + "',LastName='" + txtLast.Text + "',Phone='" + txtPhone.Text +
                        "',Address='" + textAddress.Text + "',UserName='" + txtUsername.Text + "',Password='" + txtPassword.Text +
                        "',Email='" + textEmail.Text + "' ,BirthDate='" + dateTimePicker2.Text + "',Gender='" + Gender + "',UserType='" +
                        cboxLevel.Text + "'  where UserId=" + txtId.Text + "";
                    mc.ProcessData(query, mc.updateAlert);
                    Reset();


                    if (rdboxfemale.Checked)
                    {
                      Gender = "Female";
                    }


                   else if (rdboxmale.Checked)
                    {
                        Gender = "Male";
                    }

                }
                //else
                //{
                //    MessageBox.Show("please select user type");
                //}
            }

            else
            {
                MessageBox.Show("Password mismatch");
            }

        }

        private void gunabtnDelete_Click_1(object sender, EventArgs e)
        {
            query = "delete from Users  where UserId=" + txtId.Text + "";
            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            mc.FillControls(dataGridView1, e, txtId, txtFirst, txtLast, txtPhone, textAddress, txtUsername, txtPassword, textEmail, dateTimePicker2, UserTitle);
            txtconfirm.Text = txtPassword.Text;
        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkInputNumbe(txtPhone.Text));
        }

        private void txtconfirm_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkInputNumbe(txtconfirm.Text));
            //string input = txtconfirm.Text;
            //if (int.TryParse(input, out _))
            //{
            //    chekInput.Text = "";



            //}

            //else if (input == "")
            //{
            //    chekInput.Text = "";
            //}

            //else
            //{

            //    chekInput.Text = "invlid";
            //}
        }

        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtUsername.Text));

        }

        private void txtLast_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtLast.Text));

        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(textAddress.Text));
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkInputNumbe(txtPassword.Text));
            //string input = txtPassword.Text;
            //if (int.TryParse(input, out _))
            //{
            //    chekInput.Text = "";

            //}

            //else if (input == "")
            //{
            //    chekInput.Text = "";
            //}

            //else
            //{

            //    chekInput.Text = "invlid";
            //}
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            mc.Display("select * from Users where Username like '%" + txtSearch.Text + "%'", dataGridView1);
        }

        private void label30_Click_1(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label16_Click_1(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label32_Click_1(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void label31_Click_1(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog();
        }

        private void label18_Click_1(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtFirst.Text));
        }

        private void textEmail_TextChanged_1(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private bool IsValidInput(string input)
        {
            // Check if the input is not a number and has a length between 4 and 10 characters
            return !int.TryParse(input, out _) && input.Length >= 4 && input.Length <= 10;
            //&& (int.TryParse(input, out _) && input.Length >= 8 && input.Length <= 12);

        }

        private void label38_Click(object sender, EventArgs e)
        {
            REportform rEportform = new REportform();
            rEportform.ShowDialog();

        }
    }
}
