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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dashboard
{
    public partial class Store : Form
    {
        MainClass mc = new MainClass();
        static String query, ConnecSring = "data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
           "initial catalog=BDSDatabase;" + "integrated security =true;";
        SqlConnection conn = new SqlConnection(ConnecSring);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        String InsertAlert = "Data was Saved";
        String UpdateAlert = "Updated";
        String deleteAlert = "Deleted";
        public Store()
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

                if (txtsearch.Text == "")
                    query = "select *  from ";
                else
                    query = "select * from store where DonorId like'%" + txtsearch.Text + "%'";
                using (adapter = new SqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "test");
                    dataGridView1.DataSource = ds.Tables["test"];
                }



            }


            catch { }
        }
        private void processData(string _query, string _alert)
        {
            try
            {
                // query = "insert into store values(@id,@name,@mobile)";

                using (cmd = new SqlCommand(query, conn))
                {
                    Connect();
                    cmd.Parameters.AddWithValue("@DonorID", TypeOfBlood.Text);
                    cmd.Parameters.AddWithValue("@RecpNo", RecpNo.Text);
                    cmd.Parameters.AddWithValue("@TypeOfBlood", txtID.Text);





                }

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show(_alert);
                else
                    MessageBox.Show("vailed");
                DisConnect();

                //load data
                Display();
                //calling method
                //ClearControls(txtID, txtName, txtMobile, txtSalary);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void label33_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.ShowDialog();
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

        private void label3_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            DashDonors dashDonors = new DashDonors();
            dashDonors.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Reset()
        {
            mc.Display("select * from store", dataGridView1);

            mc.FillCombo("Donors", "DonorID", "First_name", this.txtID);
            mc.FillCombo("Recipients", "RecpNo", "First_name", this.RecpNo);
            mc.Clear(TypeOfBlood, RecpNo, txtID);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Store_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            mc.Display("select * from store where DonorId like '%" + txtsearch.Text + "%'", dataGridView1);
        }

        private void TypeOfBlood_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaBtnSave_Click(object sender, EventArgs e)
        {

            //query = "insert into store values(@DonorID,@RecpNo,@TypeOfBlood)";
            query = "insert into store values(" + txtID.SelectedValue.ToString() + ","
                + RecpNo.SelectedValue.ToString()
                + "," + TypeOfBlood.Text + ")";


            processData(query, InsertAlert);
            Reset();
        }

        private void gunaBtnUpdate_Click(object sender, EventArgs e)
        {

            query = "update  store set  DonorID=" + TypeOfBlood.Text + RecpNo.SelectedValue.ToString() + txtID.SelectedValue.ToString();
            processData(query, UpdateAlert);
            Reset();
        }

        private void gunaBtnDelete_Click(object sender, EventArgs e)
        {
            query = "delete from store  where DonorID=" + txtID.Text + "";
            mc.ProcessData(query, mc.deleteAlert);
            Reset();
        }

        private void RecpNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TypeOfBlood_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SELECT CELLS;

            mc.FillControls(dataGridView1, e, txtID, RecpNo, TypeOfBlood);

    }


    } }


