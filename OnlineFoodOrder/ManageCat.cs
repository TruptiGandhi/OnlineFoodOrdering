using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineFoodOrder
{
    public partial class ManageCat : OnlineFoodOrder.Form1
    {
        public ManageCat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new addcategory();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Delcat();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Updatecat();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr = new Admin();
            fr.Show();
        }
    }
}
