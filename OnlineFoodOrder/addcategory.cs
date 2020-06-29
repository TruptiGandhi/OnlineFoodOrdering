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
    public partial class addcategory : OnlineFoodOrder.Form1
    {
        public addcategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {
                string query = "INSERT INTO Category(catname,catdetail) VALUES (@catname,@catdetail)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@catname", textBox1.Text);
                cmd.Parameters.AddWithValue("@catdetail", textBox2.Text);
                conn.Open();
                int j = cmd.ExecuteNonQuery();
                if (j == -1)
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MessageBox.Show("Category added successfully");
                    this.Hide();
                    var fr = new ManageCat();
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
            var fr = new ManageCat();
            fr.Show();
        }
    }
}
