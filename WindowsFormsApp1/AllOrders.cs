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

namespace WindowsFormsApp1
{
    public partial class AllOrders : Form
    {
        private DatabaseConnection dbConnection;
        public AllOrders()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("localhost", "your_database", "your_username", "your_password");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAllOrders();
        }

        private void LoadAllOrders()
        {
            try
            {
                dbConnection.OpenConnection();

                // SQL-запрос для получения всех заказов
                string query = "SELECT OrderName, Description, DateBegin, DateEnd, Status FROM Orders";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
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

    }
}

