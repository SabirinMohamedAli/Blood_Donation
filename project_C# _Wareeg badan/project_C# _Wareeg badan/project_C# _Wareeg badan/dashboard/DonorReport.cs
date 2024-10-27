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
    public partial class DonorReport : Form
    {
        SqlConnection con = new SqlConnection("data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
         "initial catalog=BDSDatabase;" + "integrated security =true;");
        public DonorReport()
        {
            InitializeComponent();
        }

        private void DonorReport_Load(object sender, EventArgs e)
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
                query = "select ID, Name,phone,Email,Address,Gender,age,Hospital,Department,Doctor,Blood_Type,donatedUnit,Region,Town, Registed_Date, birthdate from DonorView";
            }
            else
            {
                query = "select ID, Name,phone,Email,Address,Gender,age,Hospital,Department,Doctor,Blood_Type,donatedUnit,Region,Town, Registed_Date, birthdate from DonorView where ID like '%" + txtSearch.Text + "%'";
            }
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, "DonorView");
                ReportDataSource rptsource = new ReportDataSource("DonorDataSet1", ds.Tables[0]);
                string rptPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\DonorReportView.rdlc";
                reportViewer1.LocalReport.ReportPath = rptPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rptsource);
                reportViewer1.RefreshReport();
            }
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
