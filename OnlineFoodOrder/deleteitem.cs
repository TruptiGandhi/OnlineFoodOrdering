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
    public partial class deleteitem : OnlineFoodOrder.Form1
    {
        public deleteitem()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {
                SqlCommand cmd = new SqlCommand("select * from FoodItem where itemId=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", textBox6.Text);
                SqlDataReader rdr;
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox1.Text = rdr.GetString(1);
                    textBox2.Text = rdr.GetString(2);
                    textBox3.Text = rdr.GetString(3);

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

                string query = "DELETE FROM FoodItem where itemId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", textBox6.Text);
                conn.Open();
                int j = cmd.ExecuteNonQuery();
                if (j == -1)
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MessageBox.Show("FoodItem deleted successfully");
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
