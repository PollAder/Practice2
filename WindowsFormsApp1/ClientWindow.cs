using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ClientWindow : Form
    {
        private int clientId; // Поле для хранения идентификатора клиента

        public ClientWindow(int id)
        {
            InitializeComponent();
            clientId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ClientWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatusOrders orderForm = new StatusOrders(clientId);
            orderForm.Show();
            this.Hide(); // Скрываем текущее окно
            orderForm.FormClosed += (s, args) => this.Show();
        }
    }
}
