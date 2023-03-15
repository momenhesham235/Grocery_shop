using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_Shop
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ismai\Documents\GroceryDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            con.Open();
            string query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        int stock = 0, GrdTotal = 0,Amount;
        int n = 0;
        private void AddToBillBtn_Click(object sender, EventArgs e)
        {
            
            if(ItQtyTb.Text=="" || Convert.ToInt32(ItQtyTb.Text) > stock || ItNameTb.Text == "")
            {
                MessageBox.Show("Enter Quantity");
            }
            else
            {
                int total = Convert.ToInt32(ItQtyTb.Text) * Convert.ToInt32(ItPriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ItNameTb.Text;
                newRow.Cells[2].Value = ItPriceTb.Text;
                newRow.Cells[3].Value = ItQtyTb.Text;
                newRow.Cells[4].Value = total;
                BillDGV.Rows.Add(newRow);
                GrdTotal = GrdTotal + total;
                Amount = GrdTotal;
                TotalLbl.Text = "EGP"+GrdTotal;
                n++;
                UpdateItem();
                Reset();
            }
        }

        private void UpdateItem()
        {
                try
                {
                    int newQty = stock - Convert.ToInt32(ItQtyTb.Text);
                    con.Open();
                    DataGridViewRow row = ItemDGV.Rows[index];
                    string query = "Update ItemTbl set itQty='" + newQty + "' where itId=" + row.Cells[0].Value + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Updated Successfully");
                    con.Close();
                    populate();
                    //Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void Reset()
        {
            ItPriceTb.Text = "";
            ItQtyTb.Text = "";
            ClientNameTb.Text = "";
            ItNameTb.Text = "";
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        int EId = 1;
        string EName = "Ename";
        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (ClientNameTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into BillTbl values(" + EId + " , '" + EName + "' , '" + ClientNameTb.Text + "' , " + Amount + " )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved Successfully");
                    con.Close();
                    populate();
                    //Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EmployeeLbl_Click(object sender, EventArgs e)
        {

        }

        private void Billing_Load(object sender, EventArgs e)
        {
            EmployeeLbl.Text = Login.EmployeeName;
        }

        int index;
        private void ItemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = ItemDGV.Rows[index];
            ItNameTb.Text = row.Cells[1].Value.ToString();
            ItPriceTb.Text = row.Cells[3].Value.ToString();

            if (ItNameTb.Text == "")
            {
                stock= 0;
            }
            else
            {
                stock= Convert.ToInt32(ItemDGV.SelectedRows[0].Cells[2].Value.ToString());
            }
        }
    }
}
