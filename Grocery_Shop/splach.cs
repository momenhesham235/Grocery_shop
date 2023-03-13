using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_Shop
{
    public partial class splach : Form
    {
        public splach()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        int startPos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            precentage.Text = startPos + "%";
            startPos += 1;
            Myprogress.Value = startPos;
            if (Myprogress.Value  == 100 ) 
            {
                Myprogress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void splach_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }
}
