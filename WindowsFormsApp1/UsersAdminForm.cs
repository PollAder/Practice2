using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class UsersAdminForm : Form
    {
        private DatabaseConnection dbConnection;
        public UsersAdminForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("localhost", "your_database", "your_username", "your_password");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usernameToDelete = textBox1.Text.Trim(); // Получаем имя пользователя из текстового поля

            // Проверка на пустое поле
            if (string.IsNullOrWhiteSpace(usernameToDelete))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя для удаления.");
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                // SQL-запрос для удаления пользователя
                string query = "DELETE FROM Users WHERE Username=@Username";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Username", usernameToDelete);
                    int rowsAffected = cmd.ExecuteNonQuery(); // Выполняем запрос и получаем количество затронутых строк

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Пользователь успешно удален.");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден.");
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox2.Text;
            string role = comboBox1.SelectedItem.ToString();
            try
            {
                dbConnection.OpenConnection();

                // SQL-запрос для вставки данных
                string query = "INSERT INTO Users (Username, Password, Email, Role) VALUES (@Username, @Password, @Email, @Role)";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // В реальном приложении используйте хешированный пароль
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", role);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Пользователь успешно добавлен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
    }
}
