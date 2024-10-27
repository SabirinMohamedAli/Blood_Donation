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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dashboard
{
    public partial class Departments : Form
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
        int DepNo;


        MainClass mc = new MainClass();

        public  Departments()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string input = txtLocation.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }
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
                    query = "select *  from Departments";
                else
                    query = "select * from Departments where DepNo like'%" + txtsearch.Text + "%'";
                using (adapter = new SqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "test");
                    dataGridView1.DataSource = ds.Tables["test"];
                }



            }


            catch { }
        }

        private void label31_Click(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate();
            donate.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reset()
        {
            mc.Display("select * from Departments", dataGridView1);
            mc.FillCombo("hosp_TBL", "HospNo", "HospName",this.comobox);
            mc.Clear(departNu, txtName, txtLocation, comobox);
        }


        private void Departments_Load(object sender, EventArgs e)
        {
            Reset();
            MainClass mainClas = new MainClass();
            mainClas.Connect();
            int generateId;
            generateId = mainClas.idGenerator("select count(DepNo) from Departments;");
            departNu.Text = generateId.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
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
               


              
                    cmd.Parameters.AddWithValue("@DepNo", comobox.Text);
                    cmd.Parameters.AddWithValue("@DepName", txtName.Text);
                    cmd.Parameters.AddWithValue("@HospNo", departNu.Text);
                    cmd.Parameters.AddWithValue("@Location", txtLocation.Text);

        
        

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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            mc.Display("select * from Departments where DepNo like '%" + txtsearch.Text + "%'", dataGridView1);
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mc.FillControls(dataGridView1, e, departNu, txtName, txtLocation,  comobox);
    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaBtnSave_Click(object sender, EventArgs e)
        {
            string input = txtName.Text;
            string input1 = txtLocation.Text;

            if (IsValidInput(input) && IsValidInput(input1))
            {




                query = "insert into Departments values(" + departNu.Text
                  + ",'" + txtName.Text + "','" + txtLocation.Text + "',"
                  + comobox.SelectedValue.ToString() + ")";
                mc.ProcessData(query, mc.saveAlert);
                Reset();
                MainClass mainClas = new MainClass();
                int generateId;
                generateId = mainClas.idGenerator("select count(DepNo) from Departments;");
                departNu.Text = generateId.ToString();

            }
            else
                MessageBox.Show("invalid input");
        }

        private void gunaBtnUpdate_Click(object sender, EventArgs e)
        {

            query = "update  Departments set DepNo ='" + departNu.Text + "',DepName='"
                + txtName.Text + "',Location='" + txtLocation.Text +
                "'  where HospNo=" + comobox.SelectedValue.ToString() + "";

            processData(query, UpdateAlert);
            Reset();

        }

        private void gunaBtnDelete_Click(object sender, EventArgs e)
        {
            query = "delete from Departments  where DepNo=" + departNu.Text + "";
            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string input = txtName.Text;
            if (!int.TryParse(input, out _))
            {
                chekInput.Text = "";

            }
            else
            {
                chekInput.Text = "invalid";
            }
        }

        private void label18_Click_1(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
        }

        private void label31_Click_1(object sender, EventArgs e)
        {
            CreateUsers createUsers = new CreateUsers();
            createUsers.ShowDialog();
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

        private void label33_Click(object sender, EventArgs e)
        {
           
        }

        private void departNu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.ShowDialog();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            REportform rEportform = new REportform();
            rEportform.ShowDialog();
        }

        private bool IsValidInput(string input)
        {
            // Check if the input is not a number and has a length between 4 and 10 characters
            return !int.TryParse(input, out _) && input.Length >= 4 && input.Length <= 10;
            //&& (int.TryParse(input, out _) && input.Length >= 8 && input.Length <= 12);

        }

    }
}
