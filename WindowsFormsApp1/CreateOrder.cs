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
    public partial class CreateOrder : Form
    {
        private DatabaseConnection dbConnection;
        public CreateOrder()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("localhost", "your_database", "your_username", "your_password");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ordername = textBox1.Text.Trim();
            string client = textBox2.Text.Trim(); // ID Заказчика
            string curator = textBox3.Text.Trim(); // ID Куратора
            string description = textBox4.Text.Trim();
            string dateBegin = textBox5.Text.Trim(); // Дата начала
            string dateEnd = textBox6.Text.Trim(); // Дата окончания
            string status = textBox7.Text.Trim();

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(ordername) ||
                string.IsNullOrWhiteSpace(client) ||
                string.IsNullOrWhiteSpace(curator) ||
                string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(dateBegin) ||
                string.IsNullOrWhiteSpace(dateEnd) ||
                string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                // SQL-запрос для вставки данных в таблицу Orders
                string query = "INSERT INTO Orders (OrderName, IDClient, IDCurator, Description, DateBegin, DateEnd, Status) " +
                               "VALUES (@OrderName, @IDClient, @IDCurator, @Description, @DateBegin, @DateEnd, @Status)";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@OrderName", ordername);
                    cmd.Parameters.AddWithValue("@IDClient", client);
                    cmd.Parameters.AddWithValue("@IDCurator", curator);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@DateBegin", DateTime.Parse(dateBegin)); // Преобразование строки в DateTime
                    cmd.Parameters.AddWithValue("@DateEnd", DateTime.Parse(dateEnd)); // Преобразование строки в DateTime
                    cmd.Parameters.AddWithValue("@Status", status);

                    int rowsAffected = cmd.ExecuteNonQuery(); // Выполняем запрос

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заказ успешно добавлен.");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить заказ.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            AllOrders statusOrdersForm = new AllOrders(); // Передаем ID заказчика
            statusOrdersForm.Show();
            this.Hide();
        }
    }
}
