using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_Shop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees Emp = new Employees();
            Emp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Billing Bill = new Billing();
            Bill.Show();
            this.Hide();
        }
    }
}
