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
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ismai\Documents\GroceryDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeesDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into EmployeeTbl values('" + EmpNameTb.Text + "' , '" + EmpPhoneTb.Text + "' , '" + EmpAddTb.Text + "' , '" + EmpPassTb.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved Successfully");
                    con.Close();
                    populate();
                    Clear();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Clear()
        {
            EmpNameTb.Text = "";
            EmpPhoneTb.Text = ""; 
            EmpAddTb.Text = ""; 
            EmpPassTb.Text = ""; 
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Select the Employee To Be Deleted");
            }
            else
            {
                try
                {
                    con.Open();
                    DataGridViewRow row = EmployeesDGV.Rows[index];
                    string query = "Delete from EmployeeTbl where Empld=" + row.Cells[0].Value  + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    con.Close();
                    populate();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int index;
        private void EmployeesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = EmployeesDGV.Rows[index];
            EmpNameTb.Text = row.Cells[1].Value.ToString();
            EmpPhoneTb.Text = row.Cells[2].Value.ToString();
            EmpAddTb.Text = row.Cells[3].Value.ToString();
            EmpPassTb.Text = row.Cells[4].Value.ToString();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Select the Employee To Be Updated");
            }
            else
            {
                try
                {
                    con.Open();
                    DataGridViewRow row = EmployeesDGV.Rows[index];
                    string query ="Update EmployeeTbl set EmpName='"+EmpNameTb.Text+"', EmpPhone='"+EmpPhoneTb.Text+"',EmpAdd='"+EmpAddTb.Text+"',EmpPass='"+EmpPassTb.Text+ "' where Empld=" + row.Cells[0].Value + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    con.Close();
                    populate();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
