using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_Shop
{
    public partial class Items : Form
    {
        public Items()
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

        private void Clear()
        {
            ItNameTb.Text = "";
            ItQtyTb.Text = "";
            PriceTb.Text = "";
            CatCb.SelectedIndex= -1;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ItNameTb.Text == "" || ItQtyTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into ItemTbl values('" + ItNameTb.Text + "' , " + ItQtyTb.Text + " , " + PriceTb.Text + " , '" + CatCb.SelectedItem.ToString() + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Saved Successfully");
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
        private void ItemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = ItemDGV.Rows[index];
            ItNameTb.Text = row.Cells[1].Value.ToString();
            ItQtyTb.Text = row.Cells[2].Value.ToString();
            PriceTb.Text = row.Cells[3].Value.ToString();
            CatCb.SelectedItem = row.Cells[4].Value.ToString();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ItNameTb.Text == "" || ItQtyTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select the Item To Be Updated");
            }
            else
            {
                try
                {
                    con.Open();

                    DataGridViewRow row = ItemDGV.Rows[index];
                    string query = "Update ItemTbl set itName='" + ItNameTb.Text + "', itQty='" + ItQtyTb.Text + "',itPrice='" + PriceTb.Text + "',itCat='" + CatCb.SelectedItem.ToString() + "' where itId=" + row.Cells[0].Value + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Item Updated Successfully");
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ItNameTb.Text == "" || ItQtyTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select the Item To Be Deleted");
            }
            else
            {
                try
                {
                    con.Open();
                    DataGridViewRow row = ItemDGV.Rows[index];
                    string query = "Delete from ItemTbl where itId=" + row.Cells[0].Value + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Successfully");
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
