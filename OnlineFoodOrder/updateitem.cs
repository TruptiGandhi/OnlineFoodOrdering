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
    public partial class updateitem : OnlineFoodOrder.Form1
    {
        public updateitem()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {
                SqlCommand cmd = new SqlCommand("select * from FoodItem where itemId=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                SqlDataReader rdr;
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox2.Text = rdr.GetString(1);
                    textBox3.Text = rdr.GetString(2);
                    textBox4.Text = rdr.GetString(3);
                   // textBox5.Text = rdr.GetString(2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {

                string query = "UPDATE FoodItem SET itemname=@itemname,itemdetail=@itemdetail,price=@price,available=@available,catid=@catid where itemId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@itemname", textBox2.Text);
                cmd.Parameters.AddWithValue("@itemdetail", textBox3.Text);
                cmd.Parameters.AddWithValue("@price", textBox4.Text);
                cmd.Parameters.AddWithValue("@available", textBox5.Text);
                cmd.Parameters.AddWithValue("@catid", textBox6.Text);
                conn.Open();
                int j = cmd.ExecuteNonQuery();
                if (j == -1)
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MessageBox.Show("FoodItem updated successfully");
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
