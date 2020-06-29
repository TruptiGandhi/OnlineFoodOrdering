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
    public partial class Register : OnlineFoodOrder.Form1
    {
        public Register()
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
                string query1 = "INSERT INTO Users(Username,Password,EmailId,ContactNo,Address) VALUES(@Username,@Password,@EmailId, @ContactNo, @Address)";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd1.Parameters.AddWithValue("@EmailId", textBox3.Text);
                cmd1.Parameters.AddWithValue("@ContactNo", textBox4.Text);
                cmd1.Parameters.AddWithValue("@Address", textBox5.Text);
                conn.Open();
                int i = cmd1.ExecuteNonQuery();
                if (i == -1)
                {
                    MessageBox.Show("Something went wrong....\nPlease fill the details again");
                }
                else
                {
                    MessageBox.Show("Registered successfully");
                    this.Hide();
                    var frm = new Login();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
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
            var fr = new Login();
            fr.Show();
        }
    }
}
