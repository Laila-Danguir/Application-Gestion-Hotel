using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;

namespace ProjetSemestre
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Chambres cham = new Chambres();
            cham.Show();
            this.Hide();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            User use = new User();
            use.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void guna2GradientCircleButton5_Click(object sender, EventArgs e)
        {
            Categorie cat = new Categorie();
            cat.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            motdepasse m = new motdepasse();
            m.Show();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
            Chambres cham = new Chambres();
            cham.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Categorie cat = new Categorie();
            cat.Show();
            this.Hide();
        }

        private void guna2GradientCircleButton4_Click(object sender, EventArgs e)
        {
            Reservation obj = new Reservation();
            obj.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            obj.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Reservation obj = new Reservation();
            obj.Show();
            this.Hide();
        }
    }
}
