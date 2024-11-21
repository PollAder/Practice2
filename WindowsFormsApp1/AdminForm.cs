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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersAdminForm usersAdminForm = new UsersAdminForm();
            usersAdminForm.Show();
            usersAdminForm.FormClosed += (s, args) => this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateOrder OrderForm = new CreateOrder();
            OrderForm.Show();
            OrderForm.FormClosed += (s, args) => this.Show();
        }
    }
}
