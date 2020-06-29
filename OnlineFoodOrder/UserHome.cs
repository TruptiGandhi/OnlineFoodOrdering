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
    public partial class UserHome : OnlineFoodOrder.Form1
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                
            this.Hide();
            var fr = new PlaceOrder();
            fr.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Login();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Profilepage();
            fr.Show();
        }
    }
}
