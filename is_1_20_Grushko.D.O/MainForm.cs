using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace is_1_20_Grushko.D.O
{
    public partial class MainForm : Form
    {
        
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();

            Authorization Author = new Authorization();

            Author.ShowDialog();
            if (Auth.auth)
            {
                this.Show();
                label1.Text = Auth.auth_fio;
                string[] f11  = { label1.Text };
               
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/shortnam8");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm f = new MainForm();
            f.ShowDialog();     
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
