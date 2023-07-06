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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Connexion obj = new Connexion();
            obj.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "admin")
            {
                Index ind = new Index();
                ind.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mot de passe Incorrect ??!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
        private void Admin_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
