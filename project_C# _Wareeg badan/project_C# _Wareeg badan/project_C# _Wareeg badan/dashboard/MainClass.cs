using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace dashboard
{
      public class MainClass
    {

        static string conString = "Data Source=DESKTOP-1GN1DAK\\SQLEXPRESS;Initial Catalog=BDSDatabase;Integrated Security=true";
        public string saveAlert = "Data was saved.", updateAlert = "Data was updated.", deleteAlert = "Data was deleted.";
        public static string UserType;
        public SqlConnection con = new SqlConnection(conString);
        public SqlCommand cmd;
        public SqlDataAdapter da;


        //Connect method
        public void Connect()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        //disconnect method
        public void Disconnect()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }


        //emailcgeck




        //processdata method
        public void ProcessData(string _query, string _msg)
        {
            try
            {
                using (cmd = new SqlCommand(_query, con))
                {
                    Connect();//open connection
                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(_msg, "Blood Donation Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Something went wrong please try again.", "Data is not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Disconnect();//close connection
                }
            }
            catch(Exception e) {
                MessageBox.Show(e.Message);
                Disconnect(); }
        }


        //display method
        public void Display(string _query, DataGridView dgv)
        {
            try
            {
                using (da = new SqlDataAdapter(_query, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tbl");
                    dgv.DataSource = ds.Tables["tbl"];
                }
            }
            catch { }
        }




        //clearcontrols method
        public void Clear(params Control[] ctrl)
        {
            try
            {
                for (int index = 0; index < ctrl.Length; index++)
                {
                    ctrl[index].Text = "";
                }
                ctrl[0].Focus();
            }
            catch { }
        }

        //fillcontrols
        public void FillControls(DataGridView dgv, DataGridViewCellEventArgs e, params Control[] ctrl)
        {
            try
            {
                for (int index = 0; index < ctrl.Length; index++)
                {
                    ctrl[index].Text = dgv.Rows[e.RowIndex].Cells[index].Value.ToString();
                }
            }
            catch { }
        }

        //Reading ID method 
        
        public int idGenerator(String query)
        {
            int ID;
            Connect();
            SqlCommand sqlCommand = new SqlCommand(query, con);
            var sql = sqlCommand.ExecuteScalar();
            ID = (int)sql;
            return ID = ID + 1;

        }




        public void FillCombo(string table, string valueCol, string displayCol, ComboBox comLevel)
        {
            try
            {
                string sqlSt = $"SELECT 'Select name..' AS {valueCol}, 'Select name..' AS {displayCol} union all select convert(varchar(50),{valueCol}),{displayCol} FROM {table}";
                using (da = new SqlDataAdapter(sqlSt, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tbl");
                    comLevel.DataSource = ds.Tables["tbl"];
                    comLevel.DisplayMember = displayCol;
                    comLevel.ValueMember = valueCol;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public string checkinputString(String input)
        {


            if (!int.TryParse(input, out _) && (input.Length >= 4 && input.Length <= 10))
            {

                input = "";


            }
            else
            {

                input = "Input or range character is invalid , try again !";

            }
            return input;


        }
        public string checkInputNumbe(string input)
        {
            //string input = txtPhone.Text;
            int phone;
            if ((int.TryParse(input, out _)) && ((input.Length >= 8 && input.Length <= 12)))
            {
                input = "";



            }

            else if (input == "")
            {
                input = "";
            }

            else
            {

                input = "Input or range number is invalid , try again !";
            }
            return input;
        }

    }
}
