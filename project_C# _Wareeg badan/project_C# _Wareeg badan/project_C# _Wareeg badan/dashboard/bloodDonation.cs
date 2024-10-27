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
    public partial class bloodDonation : Form
    {
        public bloodDonation()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            panel1.Width += 3;
            if (panel1.Width >= 1483)
            {
                timer1.Stop();
                AdminDashboard dashboard = new AdminDashboard();
                dashboard.Show();
                this.Hide();
            }
        }

        private void bloodDonation_Load(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();
            dashboard.ShowDialog();
        }
    }
}
