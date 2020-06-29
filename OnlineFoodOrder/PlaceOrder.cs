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
    public partial class PlaceOrder : OnlineFoodOrder.Form1
    {
        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            Console.WriteLine(Login.us);
            try
            {
                //string query = "INSERT INTO Category(catname,catdetails) VALUES (@cname,@cdetail)";
                string query = "INSERT INTO Orders(userid, OrderDate, Amount, Status, itemId, Quantity) VALUES (@uid, @ordate, @amt ,@stat, @itemid, @qty)";
                SqlCommand cmd2 = new SqlCommand(query, conn);
                cmd2.Parameters.AddWithValue("@uid", Login.us.ToString());
                cmd2.Parameters.AddWithValue("@ordate",DateTime.Today.ToString());
                cmd2.Parameters.AddWithValue("@amt", "400");
                cmd2.Parameters.AddWithValue("@stat", "placed");
                cmd2.Parameters.AddWithValue("@itemid", "4");
                cmd2.Parameters.AddWithValue("@qty", "1");
                
                conn.Open();
                int j = cmd2.ExecuteNonQuery();
                conn.Close();
                if (j == -1)
                {
                    MessageBox.Show("Something went wrong!...Please fill the details again");
                }

                else
                {
                    MessageBox.Show("Order placed successfully");

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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new UserHome();
            fr.Show();
        }

        private void PlaceOrder_Load(object sender, EventArgs e)
        {


        }
    }
}
