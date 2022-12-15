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
        MySqlConnection conn;
        
        private BindingSource bind = new BindingSource();

        private MySqlDataAdapter data = new MySqlDataAdapter();

        DataTable table = new DataTable();

        public MainForm()
        {
            InitializeComponent();
        }
        public void con()
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_9;database=is_1_20_st9_KURS;password=19134029;";
            conn = new MySqlConnection(connStr);
            if (conn == null)
            {
                string connStr1 = "server=10.90.12.110;port=33333;user=st_1_20_9;database=is_1_20_st9_KURS;password=19134029;";
                conn = new MySqlConnection(connStr1);
            }

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
            Application.Exit();
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
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con();
           
            conn.Open();

            table.Clear();
            table.Columns.Clear();
            string com = "SELECT * FROM Employ";

            data.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bind;
            bind.DataSource = table;
            data.Fill(table);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
