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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sawirnormal_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            member.Show();
        }

        private void donorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login   login = new Login();
            login.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
            //Application.Exit();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SingUp singUp = new SingUp();
            singUp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Close();

        }
    }
}
