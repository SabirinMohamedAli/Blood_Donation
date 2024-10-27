using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboard
{
    public partial class UserReport : Form
    {
        SqlConnection con = new SqlConnection("data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
        "initial catalog=BDSDatabase;" + "integrated security =true;");
        public UserReport()
        {
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            GetReport(txtSearch.Text);


            this.reportViewer1.RefreshReport();
        }


        //Rreport method
        private void GetReport(string searchValue = "")
        {
            string query = "";
            if (searchValue == "")
            {
                query = "select ID, fullName,phone,Address,UserName,Email,age,Gender ,userType from usersReport";
            }
            else
            {
                query = "select ID, fullName,phone,Address,UserName,Email,age,Gender ,userType from usersReport";

            }
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, "usersReport");
                ReportDataSource rptsource = new ReportDataSource("UsersDataSet", ds.Tables[0]);
                string rptPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\User.rdlc";
                reportViewer1.LocalReport.ReportPath = rptPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rptsource);
                reportViewer1.RefreshReport();
            }
        }

        private void gunabtnsearch_Click(object sender, EventArgs e)
        {
            GetReport(txtSearch.Text);

        }
    }
}
