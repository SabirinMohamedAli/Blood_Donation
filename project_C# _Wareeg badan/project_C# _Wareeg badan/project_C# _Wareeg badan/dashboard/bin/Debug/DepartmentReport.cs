using Microsoft.Reporting.Map.WebForms.BingMaps;
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
    public partial class DepartmentReport : Form
    {
        SqlConnection con = new SqlConnection("data source =DESKTOP-1GN1DAK\\SQLEXPRESS;" +
            "initial catalog=BDSDatabase;" + "integrated security =true;");

        public DepartmentReport()
        {
            InitializeComponent();
        }

        private void DepartmentReport_Load(object sender, EventArgs e)
        {
            GetReport();

         
        }
        //Rreport method
        private void GetReport(string searchValue = "")
        {
            string query = "";
            if (searchValue == "")
            {
                query = "select ID,Department,Address,City,State,Staffname from DepartemntsView";
            }
            else
            {
                query = "select ID,Department,Address,City,State,Staffname from DepartemntsView " +
                    "   where Department like '%" + txtSearch.Text + "%'";

            }
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, "DepartemntsView");
                ReportDataSource rptsource = new ReportDataSource("DepartemntsViewDataSet1", ds.Tables[0]);
                string rptPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\DepartemntsV.rdlc";
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

