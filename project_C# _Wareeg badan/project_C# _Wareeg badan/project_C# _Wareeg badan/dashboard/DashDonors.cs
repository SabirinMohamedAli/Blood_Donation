using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dashboard
{
    public partial class DashDonors : Form
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
        MainClass mc = new MainClass();
        int StafID;

        String Gender;
        public DashDonors()
        {
            InitializeComponent();
        }

        private void DashDonors_Load(object sender, EventArgs e)
        {
            Reset();
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            int generateId;
            generateId = mainClas.idGenerator("select count(StafID) from Staff_TBL;");
            txtID.Text = generateId.ToString();
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

                if (txtSearch.Text == "")
                    query = "select *  from Staff_TBL";
                else
                    query = "select * from Staff_TBL where firstName like'%" + txtSearch.Text + "%'";
                using (adapter = new SqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "test");
                    dataGridView1.DataSource = ds.Tables["test"];
                }



            }


            catch { }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //

        private void Reset()
        {
            mc.Display("select * from Staff_TBL", dataGridView1);
            mc.FillCombo("Departments", "DepNo", "DepName", this.combBox);

            mc.Clear(txtID, txtfirst, txtlast);
        }

       

        private void label33_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }


       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            mc.Display("select * from Staff_TBL where firstName like '%" + txtSearch.Text + "%'", dataGridView1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtlast_TextChanged(object sender, EventArgs e)
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

        private void chekInput_Click(object sender, EventArgs e)
        {

        }

        private void txtfirst_TextChanged(object sender, EventArgs e)
        {
            string input = txtfirst.Text;
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

        }


        private void gunaBtnSave_Click_1(object sender, EventArgs e, string v)
        {

            {
                query = "insert into Staff_TBL  values(" + txtID.Text + ",'" + txtfirst.Text + ",'" + txtlast.Text + "'," + txtphone.Text +
    "'," + txtEmail.Text + "'," + Gender + "' ," + cboxTitle.Text + "'," + dateTimePicker1.Text +
    "' ," + HiredDate.Text +
    "'," + combBox.SelectedValue.ToString() + ")";
                    // query = "insert into Staff_TBL values(@StafID,@firstName,@lastName,@Phone,@Email,@Gender,@Title,@BirthDate,@hired_date,@DepNo)";
                processData(query, mc.saveAlert);

                Reset();
                StafID = StafID + 1;
                txtID.Text = StafID.ToString();
            }

        }

        private void gunaBtnUpdate_Click_1(object sender, EventArgs e)
        {
            query = "update Staff_TBL set firstName='" + txtfirst.Text + "',lastName='" + txtlast.Text + "',Phone='" + txtphone.Text +
    "',Email='" + txtEmail.Text + "',Gender='" + Gender + "' ,Title='" + cboxTitle.Text + "' ,BirthDate='" + dateTimePicker1.Text +
    "' ,hired_date='" + HiredDate.Text +
    "', DepNo=" + combBox.SelectedValue.ToString() + "  where StafID=" + txtID.Text + "";
            mc.ProcessData(query, mc.updateAlert);
            Reset();
        }

        private void gunaBtnDelete_Click_1(object sender, EventArgs e)
        {
            query = "delete from Staff_TBL  where StafID=" + txtID.Text + "";
            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            String Gender;
            try
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtfirst.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtlast.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtphone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();




                if (rdboxfemale.Checked)
                {
                    Gender = "Female";
                }
                else if (txtMale.Checked) {
                    Gender = "Male";
                 }
               

                Gender = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                HiredDate.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                combBox.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            }
            catch
            {
            }
        }

        private void txtMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtphone_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkInputNumbe(txtphone.Text));
            //string input = txtphone.Text;
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

            //    chekInput.Text = "invalid";
            //}
        }

        private void txtEmail_TextChanged_1(object sender, EventArgs e)
        {
            ValidateEmail();
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

        private void txtlast_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtlast.Text));
        }

        private void gunaBtnSave_Click_1(object sender, EventArgs e)
        {

            string input = txtlast.Text;
            string input1 = txtfirst.Text;






            if (IsValidInput(input) && IsValidInput(input1))

            {
                if (rdboxfemale.Checked)
                {
                    Gender = "Female";

                }
                else if (txtMale.Checked)
                {
                    Gender = "Male";

                }
                {
                    query = "insert into Staff_TBL  values(" + txtID.Text + ",'" + txtfirst.Text + "','" + txtlast.Text + "','" + txtphone.Text +
        "','" + txtEmail.Text + "','" + Gender + "' ,'" + cboxTitle.Text + "','" + dateTimePicker1.Text +
        "' ,'" + HiredDate.Text +
        "'," + combBox.SelectedValue.ToString() + ")";
                    // query = "insert into Staff_TBL values(@StafID,@firstName,@lastName,@Phone,@Email,@Gender,@Title,@BirthDate,@hired_date,@DepNo)";
                    processData(query, mc.saveAlert);
                    Reset();
                    MainClass mainClas = new MainClass();
                    int generateId;
                    generateId = mainClas.idGenerator("select count(StafID) from Staff_TBL;");
                    txtID.Text = generateId.ToString();

                }


            }
            else
                MessageBox.Show("invalid error");
        }

        private void txtfirst_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtfirst.Text));
        }

        private void txtID_TextChanged(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@StafID", txtID.Text);
                    cmd.Parameters.AddWithValue("@firstName", txtfirst.Text);
                    cmd.Parameters.AddWithValue("@lastName", txtlast.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);


                    if (rdboxfemale.Checked)
                    {
                        Gender = "Female";
                        cmd.Parameters.AddWithValue("@Gender", Gender);

                    }
                    else if(txtMale.Checked) 
                    {
                        Gender = "Male";
                        cmd.Parameters.AddWithValue("@Gender", Gender);

                    }
                    cmd.Parameters.AddWithValue("@Title", cboxTitle.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@hired_date", HiredDate.Text);
                    cmd.Parameters.AddWithValue("@DepNo", combBox.Text);

                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(_alert);
                    else
                        MessageBox.Show("failed");
                    DisConnect();
                }
                //load data
                Display();
                //calling method
                //ClearControls(txtID, txtName, txtMobile, txtSalary);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private bool IsValidInput(string input)
        {
            // Check if the input is not a number and has a length between 4 and 10 characters
            return !int.TryParse(input, out _) && input.Length >= 4 && input.Length <= 10;
            //&& (int.TryParse(input, out _) && input.Length >= 8 && input.Length <= 12);

        }

        private void cboxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {
            REportform rEportform = new REportform();
            rEportform.ShowDialog();
        }

        private void ValidateEmail()
        {
            string input =txtEmail.Text;
            string pattern = @"^[a-z0-9]+@gmail\.com$";

            if (Regex.IsMatch(input, pattern))
            {
                chekInput.Text = "";
               
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
   


