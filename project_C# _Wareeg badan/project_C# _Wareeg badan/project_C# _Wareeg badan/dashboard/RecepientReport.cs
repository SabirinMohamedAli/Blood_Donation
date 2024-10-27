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
    public partial class RecepientReport : Form
    {
        SqlConnection con = new SqlConnection("data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
            "initial catalog=BDSDatabase;" + "integrated security =true;");
        public RecepientReport()
        {
            InitializeComponent();
        }

        private void RecepientReport_Load(object sender, EventArgs e)
        {

            GetReport(); this.reportViewer1.RefreshReport();
        }
        //Rreport method
        private void GetReport(string searchValue = "")
        {
            string query = "";
            if (searchValue == "")
            {
                query = "select ID,fulName,phone,Email,gender,age,Bloodtype,BloodUnit,transfusion,Donor,Hospital,Department,Doctor,Donoremail,Date from RecipientView";
            }
            else
            {
                query = "select ID,fulName,phone,Email,gender,age,Bloodtype,BloodUnit,transfusion,Donor,Hospital,Department,Doctor,Donoremail,Date from RecipientView"
                +
                                   "   where ID like '%" + txtSearch.Text + "%'";

            }
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, "RecipientView");
                ReportDataSource rptsource = new ReportDataSource("recepDataSet1", ds.Tables[0]);
                string rptPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Recepientrepoert.rdlc";
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

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
