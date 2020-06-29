using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineFoodOrder
{
    public partial class Admin : OnlineFoodOrder.Form1
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Managefooditem();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new ManageCat();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Login();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
