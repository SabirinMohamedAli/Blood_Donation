using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboard
{
    public partial class REportform : Form
    {
        public REportform()
        {
            InitializeComponent();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            report report = new report();
            report.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DonorReport report = new DonorReport();
            report.ShowDialog();
            
                  }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            RecepientReport report = new RecepientReport();
            report.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DepartmentReport report = new DepartmentReport();
            report.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UserReport report = new UserReport();
            report.ShowDialog();
        }
    }
}
