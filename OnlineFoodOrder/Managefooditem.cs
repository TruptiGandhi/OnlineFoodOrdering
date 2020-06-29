using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineFoodOrder
{
    public partial class Managefooditem : OnlineFoodOrder.Form1
    {
        public Managefooditem()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new additem();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new deleteitem();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new updateitem();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Admin();
            fr.Show();
        }
    }
}
