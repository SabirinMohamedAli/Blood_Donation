using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace dashboard
{
    public partial class Patient : Form
    {
        static String query, ConnecSring = "data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
            "initial catalog=BDSDatabase;" + "integrated security =true;";
        SqlConnection conn = new SqlConnection(ConnecSring);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        String InsertAlert = "Data was Saved";
        String UpdateAlert = "Updated";
        String deleteAlert = "Deleted";
        string gender;
        int RecpNo;
        MainClass mc = new MainClass();
        public Patient()
        {
            InitializeComponent();
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

                if (txtNo.Text == "")
                    query = "select *  from Recipients";
                else
                    query = "select * from Recipients where first_name like'%" + txtNo.Text + "%'";
                using (adapter = new SqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "test");
                    dataGridView1.DataSource = ds.Tables["test"];
                }



            }


            catch { }
        }
        private void Reset()
            
        {
            mc.Display("select * from Recipients", dataGridView1);
            mc.FillCombo("Staff_TBL", "StafID", "firstName",  this.txtStafId);
            mc.FillCombo("Donors", "DonorID", "first_name", this.txtDonorId);
            mc.Clear(txtStafId, txtfirst, txtlast);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
         Donate donate = new Donate();
            donate.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
          

            //query = "insert into tblUsers values (" + txtNo.Text + ",'" + txtfirst.Text + "','" +
              //  txtfirst.Text + "','"+ txtphone.Text + ",'" +.Text + "','" + "')";
           // mc.ProcessData(query, mc.saveAlert);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void processData(string _query, string _alert)
        {
            String Gender;
            try
            {
                // query = "insert into contact values(@id,@name,@mobile)";

                using (cmd = new SqlCommand(query, conn))
                {
                    Connect();
                    cmd.Parameters.AddWithValue("@RecpNo", txtNo.Text);
                    cmd.Parameters.AddWithValue("@first_name", txtfirst.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtlast.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);


                    if (txtfemale.Checked)
                    {
                        Gender = "Female";
                        cmd.Parameters.AddWithValue("@Gender", Gender);

                    }
                    else
                    {
                        Gender = "Male";
                        cmd.Parameters.AddWithValue("@Gender", Gender);

                    }
                    cmd.Parameters.AddWithValue("@Type", Bloodtype.Text);
                    cmd.Parameters.AddWithValue("@StafID", txtStafId.Text);
                    cmd.Parameters.AddWithValue("@DonorID", txtDonorId.Text);
                    cmd.Parameters.AddWithValue("@BloodUnits", txtunitblood.Text);
                    cmd.Parameters.AddWithValue("@BirdDate", BOT.Text);











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

        private void Patient_Load(object sender, EventArgs e)
        {
            Display();
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            SqlCommand sqlCommand = new SqlCommand("select count(*) from Recipients;", mainClas.con);
            var sql = sqlCommand.ExecuteScalar();
            RecpNo = (int)sql;
            RecpNo = RecpNo + 1;
            txtNo.Text = RecpNo.ToString();
            Reset();
        }

       

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }


        
       
        private void txtStafId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaBtnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtfirst.Text;
            string email = txtemail.Text;


            //query = "insert into Recipients values(@RecpNo,@first_name,@last_name,@Phone,@Gender,@Email,"
            //     +s
            //     "@BloodUnits,@BirdDate,@StafID,@DonorID,@Type)"+ txtStafId.SelectedValue.ToString();
            if (txtfemale.Checked)
            {
                gender = "Female";
            }
            else if(txtmale.Checked)
            {
                gender = "Male";
            }



            query = "insert into Recipients values(" + txtNo.Text
            + ",'" + txtfirst.Text + "','" + txtlast.Text
            + "','" + txtphone.Text + "','" + gender + "','" + txtemail.Text +
             "'," + txtunitblood.Text +  ",'"+BOT.Text + "','" + txtStafId.SelectedValue.ToString()
              +  "'," + txtDonorId.SelectedValue.ToString() + ",'" + Bloodtype.Text + "')";
            processData(query, InsertAlert);
            Reset();
            RecpNo = RecpNo + 1;
            txtNo.Text = RecpNo.ToString();

            //query = "insert into Recipients values (" + txtNo.Text + ",'" + txtfirst.Text + "','" +
            //  txtphone.Text + "','" + gender + ",'" +txtemail.Text + "','" + ",'" + txtunitblood.Text + ",'" + BOT.Text + "')";
            // mc.ProcessData(query, mc.saveAlert);

        }

      

    

        private void label33_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }

        private void gunaBtnUpdate_Click(object sender, EventArgs e)
        {
            {
                query = "update  Recipients set  first_name='" + txtfirst.Text + "',last_name='" +
                 txtlast.Text + "',Phone='" + txtphone.Text +
                "',Email='" + txtemail.Text + "',BloodUnits='" + txtunitblood.Text + "',BirdDate='" +
                BOT.Text + "',  StafID='" + txtStafId.SelectedValue.ToString()+ "', DonorID='" +
                txtDonorId.SelectedValue.ToString() + "' ,Type='" + Bloodtype.Text+ "'  where RecpNo=" + txtNo.Text + "";
                processData(query, UpdateAlert);
                Reset();

            }
        }

      

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtfirst_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtlast_TextChanged(object sender, EventArgs e)
        {
            string input = txtlast.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaBtnSave_Click_1(object sender, EventArgs e)
        {
            

           
        }

        private void gunaBtnUpdate_Click_1(object sender, EventArgs e)
        {
        }

        private void gunaBtnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label13_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.Show();

        }

        private void label22_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label34_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog(this);
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog(this);
        }
        private bool IsValidInput(string input)
        {
            // Check if the input is not a number and has a length between 4 and 10 characters
            return !int.TryParse(input, out _) && input.Length >= 4 && input.Length <= 10;
            //&& (int.TryParse(input, out _) && input.Length >= 8 && input.Length <= 12);

        }

        private void gunaBtnSave_Click_2(object sender, EventArgs e)
        {
            //string firstName = txtfirst.Text;
            //string email = txtemail.Text;


            string input = txtfirst.Text;
            string input3 = txtlast.Text;
            //string input4 = txtNo.Text;
          
       

            //string input8 = txtphone.Text;




            if (IsValidInput(input)  && IsValidInput(input3)  )

            {



                MainClass mainClas = new MainClass();
                mainClas.Connect();
                SqlCommand sqlCommand = new SqlCommand("select BloodUnit from Donors where DonorID =" + txtDonorId.SelectedValue.ToString() + "", mainClas.con);
                var sql = sqlCommand.ExecuteScalar();
                int bloodUnit = (int)sql;
                int bloodUniTxt = int.Parse(txtunitblood.Text);
                if (bloodUniTxt > bloodUnit)
                {
                    MessageBox.Show("You do not have enough blood unit !");
                }


                else
                {
                    query = "update  Donors set  BloodUnit=" + (bloodUnit - bloodUniTxt) + "where DonorID=" + txtDonorId.SelectedValue.ToString() + "";

                    processData(query, UpdateAlert);

                    if (txtfemale.Checked)
                    {
                        gender = "Female";
                    }
                    else if (txtmale.Checked)
                    {
                        gender = "Male";
                    }



                    query = "insert into Recipients values(" + txtNo.Text
                    + ",'" + txtfirst.Text + "','" + txtlast.Text
                    + "'," + txtphone.Text + ",'" + gender + "','" + txtemail.Text +
                     "'," + txtunitblood.Text + ",'" + BOT.Text + "','" + txtStafId.SelectedValue.ToString()
                      + "'," + txtDonorId.SelectedValue.ToString() + ",'" + Bloodtype.Text + "')";
                    processData(query, InsertAlert);
                    Reset();
                    RecpNo = RecpNo + 1;
                    txtNo.Text = RecpNo.ToString();
                }
               
            }
            else
            {
                MessageBox.Show("invalid error");
            }
        }

        private void gunaBtnDelete_Click(object sender, EventArgs e)
        {
            query = "delete from Recipients  where RecpNo=" + txtNo.Text + "";

            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void gunaBtnUpdate_Click_2(object sender, EventArgs e)
        {
            {
                query = "update  Recipients set  first_name='" + txtfirst.Text + "',last_name='" +
                 txtlast.Text + "',Phone='" + txtphone.Text +
                "',Email='" + txtemail.Text + "',BloodUnits='" + txtunitblood.Text + "',BirdDate='" +
                BOT.Text + "',  StafID='" + txtStafId.SelectedValue.ToString() + "', DonorID='" +
                txtDonorId.SelectedValue.ToString() + "' ,Type='" + Bloodtype.Text + "'  where RecpNo=" + txtNo.Text + "";
                processData(query, UpdateAlert);
                Reset();

            }
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            mc.Display("select * from Recipients where First_name like '%" + txtsearch.Text + "%'", dataGridView1);

        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {

            mc.FillControls(dataGridView1, e, txtNo, txtfirst, txtlast, txtphone, txtfemale, txtemail, txtunitblood
                          , txtStafId, txtDonorId, BOT, Bloodtype);
        }

        private void txtphone_TextChanged_1(object sender, EventArgs e)
        {
            string input = txtphone.Text;
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

                chekInput.Text = "invalid";
            }
        }

        private void txtemail_TextChanged_1(object sender, EventArgs e)
        {
            ValidateEmail();
            string input = txtemail.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }
        }

        private void txtlast_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtlast.Text));
        }

        private void txtfirst_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtfirst.Text));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();

        }

        private void label6_Click(object sender, EventArgs e)
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
            string input = txtemail.Text;
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
