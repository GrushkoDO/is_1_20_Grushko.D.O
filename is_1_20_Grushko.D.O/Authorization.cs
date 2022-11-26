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
    public partial class Authorization : Form
    {
         public void con()
         {
            string connStr = "server=chuc.caseum;port=33333;user=st_1_20_9;database=is_1_20_st9_KURS;password=19134029;";
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch
            {
                string connStrr = "server=10.90.12.110;port=33333;user=st_1_20_9;database=is_1_20_st9_KURS;password=19134029;";
                conn = new MySqlConnection(connStrr);
            }

         }
        
        
        MySqlConnection conn;
        
        
        static string sha256 (string randomString)
        {
            var crypt  = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash .ToString();
            
        }
      
        public void GetUserInfo(string login_employ)
        {
            //Объявлем переменную для запроса в БД
            string selected_id_stud = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM Employ WHERE login_employ='{login_employ}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.auth_id = reader[0].ToString();
                Auth.auth_fio = reader[1].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            con();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
                string sql = " SELECT * FROM Employ WHERE login_employ = @un and password_employ = @up";
                //Открытие соединения
                conn.Open();
                //Объявляем таблицу
                DataTable table = new DataTable();
                //Объявляем адаптерщш
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                //Объявляем команду
                MySqlCommand command = new MySqlCommand(sql, conn);
                //Определяем параметры
                command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
                //Присваиваем параметрам значение
                command.Parameters["@un"].Value = textBox1.Text;
                command.Parameters["@up"].Value = sha256(textBox2.Text);
                //Заносим команду в адаптер
                adapter.SelectCommand = command;
                //Заполняем таблицу
                adapter.Fill(table);
                //Закрываем соединение
                conn.Close();
                //Если вернулась больше 0 строк, значит такой пользователь существует
                if (table.Rows.Count > 0)
                {
                    //Присваеваем глобальный признак авторизации
                    Auth.auth = true;
                    //Достаем данные пользователя в случае успеха
                    GetUserInfo(textBox1.Text);
                    //Закрываем форму
                    this.Close();
                }
                else
                {
                    //Отобразить сообщение о том, что авторизаия неуспешна
                    MessageBox.Show("Неверные данные авторизации!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch { }
            finally
            {
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
