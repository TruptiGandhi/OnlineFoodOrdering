using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace OnlineFoodOrder
{
    public partial class Login : OnlineFoodOrder.Form1
    {
        public static int us;
        public Login()
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
                SqlCommand cmd = new SqlCommand("select * from Users where Username=@Username and Password =@Password", conn);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                DataRow dr = ds.Tables[0].Rows[0];
                if(count==1)
                {
                    var x = dr["userid"];
                    us = Convert.ToInt32(x);
                    MessageBox.Show("Login Successful!");
                    if (textBox1.Text.Equals("admin"))
                    {
                        this.Hide();
                        var frm = new Admin();
                        frm.Show();
                    }
                    else
                    {
                        this.Hide();
                        var frm = new UserHome();
                        frm.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var fm = new Register();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
