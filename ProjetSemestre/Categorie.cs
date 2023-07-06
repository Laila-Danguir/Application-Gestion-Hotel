using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetSemestre
{
    public partial class Categorie : Form
    {
        Fonctions Con;
        public Categorie()
        {
            InitializeComponent();
            Con = new Fonctions();
            ListeCategorie();
        }
        private void ListeCategorie()
        {
            string Requete = "Select * from CategorieTable";
            guna2DataGridView1.DataSource = Con.RecupererDonnees(Requete);

        }

        private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        {
            //Modifier
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
                {
                    MessageBox.Show("Veulliez Remplir Tous les champs !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nom = guna2TextBox1.Text;
                    string detail = guna2TextBox2.Text;
                    string Req = "update CategorieTable set CategoNom='{0}',CatDetails='{1}'where Categoid={2}";

                    Req = string.Format(Req, nom,detail,k);
                    Con.EnvoyerDonnees(Req);
                    ListeCategorie();
                    MessageBox.Show("Catégorie Bien Modifié !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Message);

            }

        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton2_Click_1(object sender, EventArgs e)
        {
            //Enregistrer 
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
                {
                    MessageBox.Show("Veulliez Remplir Tous les champs !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nom = guna2TextBox1.Text;
                    string detail = guna2TextBox2.Text;
                    string Req = "insert into CategorieTable values('{0}','{1}')";
                    Req = string.Format(Req, nom,detail);
                    Con.EnvoyerDonnees(Req);
                    ListeCategorie();
                    MessageBox.Show("Catégorie Bien Ajouté !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            //SUPPRIMER
            try
            {

                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer cette ligne ? !!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    string nom = guna2TextBox1.Text;
                    string detail = guna2TextBox2.Text;

                    string Req = "delete from CategorieTable where Categoid={0}";

                    Req = string.Format(Req, k);
                    Con.EnvoyerDonnees(Req);
                    ListeCategorie();
                    MessageBox.Show("Catégorie Supprimer !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();

                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Suppression Annuler !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Message);
            }
        }
        int k = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            if (guna2TextBox1.Text == "")
            {
                k = 0;
            }

            else
            {
                k = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Chambres obj =new Chambres();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Index ind = new Index();
            ind.Show();
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            this.Hide();
        }

        private void Categorie_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Reservation obj = new Reservation();
            obj.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            obj.Show();
            this.Hide();
        }
    }
}
