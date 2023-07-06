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
    public partial class motdepasse : Form
    {
        public motdepasse()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if(textBox1.Text=="1234")
            {
                User use = new User();
                use.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect","Attention",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void motdepasse_Load(object sender, EventArgs e)
        {

        }
    }
}
