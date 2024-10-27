using System;
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

namespace dashboard
{
    public partial class SingUp : Form
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
        int HospNo;



        MainClass mc = new MainClass();
        public SingUp()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                    query = "select *  from hosp_TBL";
                else
                    query = "select * from hosp_TBL where HospNo like'%" + txtsearch.Text + "%'";
                using (adapter = new SqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "test");
                    dataGridView1.DataSource = ds.Tables["test"];
                }



            }


            catch { }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void label19_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
               patient.ShowDialog();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();    
            createUsers.ShowDialog();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }


        private void Reset()
        {
            mc.Display("select * from hosp_TBL", dataGridView1);
            mc.Clear(txtID, txtName, txtEmail,txtAddress,txtCity,txtState);
        }

      

       

        private void SingUp_Load(object sender, EventArgs e)
        {
          //  ValidateEmail();
            Reset();

            MainClass mainClas = new MainClass();
            mainClas.Connect();
            int generateId;
            generateId = mainClas.idGenerator("select count(HospNo) from hosp_TBL;");
            txtID.Text = generateId.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
        }
        private void processData(string _query, string _alert)
        {
            try
            {
                // query = "insert into contact values(@id,@name,@mobile)";

                using (cmd = new SqlCommand(query, conn))
                {
                    Connect();
                    cmd.Parameters.AddWithValue("@HospNo", txtID.Text);
                    cmd.Parameters.AddWithValue("@HospName", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@State", txtState.Text);


                
                 

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaBtnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaBtnDelete_Click(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void gunaBtnSave_Click_1(object sender, EventArgs e)
        {
            ValidateEmail();
            query = "insert into hosp_TBL values(" + txtID.Text + ",'" + txtName.Text + "','" + txtEmail.Text + "','"
              + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "')";
            mc.ProcessData(query, mc.saveAlert);

            Reset();
            MainClass mainClas = new MainClass();


           
            int generateId;
            generateId = mainClas.idGenerator("select count(HospNo) from hosp_TBL;");
            txtID.Text = generateId.ToString();

        }


        private void ValidateEmail()
        {
            string input = txtEmail.Text;
            string pattern = @"^[a-z0-9]+@gmail\.com$";

            if (Regex.IsMatch(input, pattern))
            {
               // MessageBox.Show("please try email saxsan");
                //chekInput.Text = "Valid Email";
                chekInput.ForeColor = System.Drawing.Color.Green;
                // Additional actions for valid email
            }
            else
            {
                MessageBox.Show("please try email saxsan");
                // chekInput.Text = "Invalid Email";
                chekInput.ForeColor = System.Drawing.Color.Red;
                // Additional actions for invalid email
            }
        }

            private void gunaBtnDelete_Click_1(object sender, EventArgs e)
        {
            query = "delete from hosp_TBL  where HospNo=" + txtID.Text + "";
            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtState.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { }
        }

        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtName.Text));
        }

        private void txtCity_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtCity.Text));
        }

        private void txtEmail_TextChanged_1(object sender, EventArgs e)
        {
            //ValidateEmail();
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

        private void txtAddress_TextChanged_1(object sender, EventArgs e)
        {
            chekInput.Text = (mc.checkinputString(txtAddress.Text));
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            mc.Display("select * from hosp_TBL where HospNo like '%" + txtsearch.Text + "%'", dataGridView1);

        }

        private void txtID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label30_Click_1(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog(); ;
        }

        private void label19_Click_1(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog(); ;
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog(); ;
        }

        private void label18_Click_1(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog(); ;
        }

        private void label32_Click_1(object sender, EventArgs e)
        {
            Departments departments = new Departments();    
            departments.ShowDialog(); ;
        }

        private void label31_Click_1(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog(); ;
        }

        private void label38_Click(object sender, EventArgs e)
        {
            REportform reportform = new REportform();
            reportform.ShowDialog(); ;
        }

        private void gunaBtnUpdate_Click_1(object sender, EventArgs e)
        {
            ValidateEmail();
            query = "update  hosp_TBL set  HospName='" + txtName.Text + "',Email='" + txtEmail.Text + "',Address='" + txtAddress.Text +
                "',City='" + txtCity.Text + "',State='" + txtState.Text + "'  where HospNo=" + txtID.Text + "";
            processData(query, UpdateAlert);
        }

        

   
    }
}
