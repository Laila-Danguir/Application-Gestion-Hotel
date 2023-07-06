using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetSemestre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int debut = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            debut = debut + 2;
            guna2CircleProgressBar1.Value= debut;
            label4.Text = debut + " %";
            
            if(guna2CircleProgressBar1.Value==100)
            {
                guna2CircleProgressBar1.Value = 0;
                timer1.Stop();
                Connexion Con=new Connexion();
                Con.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
