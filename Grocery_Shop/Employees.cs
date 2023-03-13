using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Grocery_Shop
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Compu\Documents\GroceryDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpPhone.Text == "" || EmpAdd.Text == "" || EmpPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into EmployeeTbl values('" + EmpName.Text + "' , '" + EmpPhone.Text + "' , '" + EmpAdd.Text + "' , '" + EmpPass.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved Successfully");

                    con.Close();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
