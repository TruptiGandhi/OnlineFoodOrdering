using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineFoodOrder
{
    public partial class additem : OnlineFoodOrder.Form1
    {
        public additem()
        {
            InitializeComponent();
        }

        private void additem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {
                string query = "INSERT INTO FoodItem(itemname,itemdetail,price,available,catid) VALUES (@itemname,@itemdetail,@price,@available,@catid)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemname", textBox1.Text);
                cmd.Parameters.AddWithValue("@itemdetail", textBox2.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.Parameters.AddWithValue("@available", textBox4.Text);
                cmd.Parameters.AddWithValue("@catid", textBox5.Text);
                conn.Open();
                int j = cmd.ExecuteNonQuery();
                if (j == -1)
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MessageBox.Show("FoodItem added successfully");
                    this.Hide();
                    var fr = new Managefooditem();
                    fr.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Managefooditem();
            fr.Show();
        }
    }
}
