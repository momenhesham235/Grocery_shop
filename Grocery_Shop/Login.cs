using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public static string EmployeeName = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees Emp = new Employees();
            Emp.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ismai\Documents\GroceryDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from employeeTbl  where EmpName='" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                EmployeeName = UnameTb.Text;
                Billing Obj= new Billing();
                Obj.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("Wrong UserName Or Passowrd");
            }
            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
