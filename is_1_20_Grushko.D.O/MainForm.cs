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
    public partial class MainForm : MetroFramework.Forms.MetroForm
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
    }
}
