using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;
namespace dashboard
{
    public partial class report : Form
    {

        SqlConnection con = new SqlConnection("data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
            "initial catalog=BDSDatabase;" + "integrated security =true;");

        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {

            GetReport();
        }

        //Rreport method
        private void GetReport(string searchValue = "")
        {
            string query = "";
            if (searchValue == "")
            {
                query = "select ID,fullName,phone,Email,Gender,age,Title,Hospital,Department,hired_date,BirthDate from Staffs";
            }
            else
            {
                query = "select ID,fullName,phone,Email,Gender,age,Title,Hospital,Department,hired_date,BirthDate from Staffs" +
                    " where ID like '%" + txtSearch.Text+"%'";
            }
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, "Staffs");
                ReportDataSource rptsource = new ReportDataSource("StaffDataSet1", ds.Tables[0]);
                string rptPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Report1.rdlc";
                reportViewer1.LocalReport.ReportPath = rptPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rptsource);
                reportViewer1.RefreshReport();
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            GetReport(txtSearch.Text);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
        }

        private void gunabtnsearch_Click(object sender, EventArgs e)
        {
            GetReport(txtSearch.Text);

        }
    }
}
