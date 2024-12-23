﻿using System;
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
    public partial class Form1 : Form
    {
        private DatabaseConnection dbConnection;
        public Form1()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("localhost", "your_database", "your_username", "your_password");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox2.Text;

            try
            {
                dbConnection.OpenConnection();

                // SQL-запрос для проверки учетных данных и получения ID пользователя
                string query = "SELECT idUsers, Role FROM Users WHERE Username=@username AND Password=@password AND Email=@Email";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // В реальном приложении используйте хешированный пароль
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32("idUsers"); // Получаем ID пользователя
                            string role = reader.GetString("Role"); // Получаем роль пользователя

                            if (role == "administrator")
                            {
                                AdminForm adminForm = new AdminForm();
                                adminForm.Show();
                                this.Hide();
                            }
                            else if (role == "Заказчик")
                            {
                                ClientWindow statusOrdersForm = new ClientWindow(userId); // Передаем ID заказчика
                                statusOrdersForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверные учетные данные.");
                        }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
