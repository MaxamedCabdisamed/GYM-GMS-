using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYME_Management_System
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

       



        public void splashstarter()
        {

            Application.Run(new Form1());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                LoginForm lf = new LoginForm();
                lf.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
