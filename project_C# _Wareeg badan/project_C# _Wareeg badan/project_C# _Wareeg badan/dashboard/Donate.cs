using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dashboard
{
    public partial class Donate : Form
    {
        //Declaring connection;
        static String query, ConnecSring = "data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
            "initial catalog=BDSDatabase;" + "integrated security =true;";
        SqlConnection conn = new SqlConnection(ConnecSring);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        String InsertAlert = "Saved";
        String UpdateAlert = "Updated";
        String deleteAlert = "Deleted";
        int DonorID;
        String Gender;


        MainClass mc = new MainClass();

        public Donate()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void Connect()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        //close connection method
        private void DisConnect()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }


        private void Display()
        {
            try
            {

                if (txtsearch.Text == "")
                    query = "select *  from Donors";
                else
                    query = "select * from Donors where first_name like'%" + txtsearch.Text + "%'";
                using (adapter = new SqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "test");
                    dataGridView1.DataSource = ds.Tables["test"];
                }



            }


            catch { }
        }

       

        

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
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
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();    
            createUsers.ShowDialog();   
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
        }
        //

        private void processData(string _query, string _alert)
        {
            String Gender;
            try
            {
                // query = "insert into contact values(@id,@name,@mobile)";

                using (cmd = new SqlCommand(query, conn))
                {
                    Connect();
                    cmd.Parameters.AddWithValue("@DonorID", txtID.Text);
                    cmd.Parameters.AddWithValue("@first_name", txtFirst.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLast.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);


                    if (txtFemale.Checked)
                    {
                        Gender = "Female";
                        cmd.Parameters.AddWithValue("@Gender", Gender);

                    }
                    else
                    {
                        Gender = "Male";
                        cmd.Parameters.AddWithValue("@Gender", Gender);

                    }
                    cmd.Parameters.AddWithValue("@Blood_Type", bloodtype.Text);
                   // cmd.Parameters.AddWithValue("@Blood_ID", txtBloodID.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@Town", txtTown.Text);
                    cmd.Parameters.AddWithValue("@Registed_Date", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@birthdate", HiredDate.Text);










                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(_alert);
                    else
                        MessageBox.Show("vailed");
                    DisConnect();
                }
                //load data
                Display();
                //calling method
                //ClearControls(txtID, txtName, txtMobile, txtSalary);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            mc.Display("select * from Donors", dataGridView1);
            mc.FillCombo("CategoryTBL", "Blood_ID", "Blood_Type", this.bloodtype);

            mc.FillCombo("Staff_TBL", "StafID", "firstName", this.txtStaffID);

            mc.Clear(txtID, txtFirst, txtLast);
           
        }

       

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            mc.Display("select * from Donors where first_name like '%" + txtsearch.Text + "%'", dataGridView1);
        }

        private void label33_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bloodtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaBtnSave_Click(object sender, EventArgs e)
        {

           




        }

        private void gunaBtnUpdate_Click(object sender, EventArgs e)
        {
        
        }

        private void gunaBtnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void txtgender_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string input = txtPhone.Text;
            if (int.TryParse(input, out _))
            {
                chekInput.Text = "";



            }

            else if (input == "")
            {
                chekInput.Text = "";
            }

            else
            {

                chekInput.Text = "invlid";
            }
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
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

        private void txtLast_TextChanged(object sender, EventArgs e)
        {
            string input = txtLast.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string input = txtEmail.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            string input = txtAddress.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkInputNumbe(txtPhone.Text));
        }

        private void txtID_TextChanged_1(object sender, EventArgs e)
        {

        }
        private bool IsValidInput(string input)
        {
            // Check if the input is not a number and has a length between 4 and 10 characters
            return !int.TryParse(input, out _) && input.Length >= 4 && input.Length <= 10;
            //&& (int.TryParse(input, out _) && input.Length >= 8 && input.Length <= 12);

        }

        private void gunaBtnSave_Click_1(object sender, EventArgs e)
        {

            string input = txtFirst.Text;
            string input1 = txtLast.Text;
            string input3 = txtAddress.Text;




            if (IsValidInput(input) && IsValidInput(input1) && IsValidInput(input3))

            {
                if (txtFemale.Checked)
                {
                    Gender = "Female";
                }
                else
                {
                    Gender = "Male";
                }

                //query = "insert into Donors values(@DonorID,@first_name,@last_name,@Phone," +
                //   "@Email,@Gender,@Blood_Type,@Blood_ID,@Address,@Region," +
                //   "@Town,@Registed_Date,@birthdate)";
                query = "insert into Donors values(" + txtID.Text + " ,'" + txtFirst.Text + "','" + txtLast.Text +
                    "'," + txtPhone.Text
              + ",'" + txtEmail.Text + "','" + Gender + "','" + bloodtype.Text +
              "'," + TypeOfBlood.Text + "," + txtStaffID.SelectedValue.ToString() + ",'" + txtAddress.Text + "','" + txtRegion.Text + "','" + txtTown.Text + "','" + HiredDate.Text +
               "','" + dateTimePicker1.Text + "')";
                processData(query, InsertAlert);
                MainClass mainClas = new MainClass();
                int generateId;
                generateId = mainClas.idGenerator("select count(DonorID) from Donors;");
                txtID.Text = generateId.ToString();

            }
            else
                MessageBox.Show("invalid input");
        }
        private void gunaBtnUpdate_Click_1(object sender, EventArgs e)
        {
            query = "update  Donors set  first_name='" + txtFirst.Text + "',last_name='" + txtLast.Text + "',Phone='" + txtPhone.Text + "',Email='" + txtEmail.Text +
           "',Gender='" + txtgender.Text + "',Blood_Type='" + bloodtype.Text + "',BloodUnit='" + TypeOfBlood.Text + "',StafID='" + txtStaffID.SelectedValue.ToString()
           + "',Address='" + txtAddress.Text + "',Region='" + txtRegion.Text + "',Town='" + txtTown +
           "',Registed_Date='" + HiredDate.Text + "',birthdate='" + dateTimePicker1.Text +  "'  where DonorID=" + txtID.Text + "";
            processData(query, UpdateAlert);
        }

        private void gunaBtnDelete_Click_1(object sender, EventArgs e)
        {
            query = "delete from Donors  where DonorID=" + txtID.Text + "";

            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            mc.FillControls(dataGridView1, e, txtID, txtFirst, txtLast, txtPhone, txtEmail
               , bloodtype

               );
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label19_Click_1(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label30_Click_1(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label18_Click_1(object sender, EventArgs e)
        {
            SingUp donate = new SingUp();
            donate.ShowDialog();
        }

        private void txtFirst_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtFirst.Text));
        }

        private void txtLast_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtLast.Text));
        }

        private void txtAddress_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtAddress.Text));
        }

        private void BOT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged_1(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void Donate_Load(object sender, EventArgs e)
        {
           Display();
            Reset();
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            int generateId;
            generateId = mainClas.idGenerator("select count(DonorID) from Donors;");
            txtID.Text = generateId.ToString();


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

        private void label38_Click(object sender, EventArgs e)
        {
            REportform form = new REportform();
            form.ShowDialog();
        }

        private void ValidateEmail()
        {
            string input = txtEmail.Text;
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
    }
}
