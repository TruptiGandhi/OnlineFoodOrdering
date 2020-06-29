﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineFoodOrder
{
    public partial class Updatecat : OnlineFoodOrder.Form1
    {
        public Updatecat()
        {
            InitializeComponent();
        }

        
       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Category where catid=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", textBox4.Text);
                SqlDataReader rdr;
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox5.Text = rdr.GetString(1);
                    textBox6.Text = rdr.GetString(2);
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
            string connectionstring;
            SqlConnection conn;
            connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jak78\Desktop\OnlineFoodOrder\OnlineFoodOrder\Database1.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
            try
            {

                string query = "UPDATE Category SET catname=@catname ,catdetail=@catdetail where catid=@cid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cid", textBox4.Text);
                cmd.Parameters.AddWithValue("@catname", textBox5.Text);
                cmd.Parameters.AddWithValue("@catdetail", textBox6.Text);
                conn.Open();
                int j = cmd.ExecuteNonQuery();
                if (j == -1)
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MessageBox.Show("Category updated successfully");
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new ManageCat();
            fr.Show();
        }
    }
}