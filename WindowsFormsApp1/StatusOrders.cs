﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace WindowsFormsApp1
{
    public partial class StatusOrders : Form
    {
        private DatabaseConnection dbConnection;
        private int currentClientId; 

        public StatusOrders(int clientId)
        {
            InitializeComponent();
            currentClientId = clientId; // Сохраняем идентификатор
            dbConnection = new DatabaseConnection("localhost", "your_database", "your_username", "your_password");
        }

        private void LoadOrders()
        {
            try
            {
                dbConnection.OpenConnection();

                // SQL-запрос для получения заказов текущего заказчика
                string query = "SELECT OrderName, Description, DateBegin, DateEnd, Status FROM Orders WHERE IDClient=@IDClient";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@IDClient", currentClientId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Заполняем DataTable данными из базы данных

                    // Привязываем DataTable к DataGridView
                    dataGridView1.DataSource = dataTable;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
