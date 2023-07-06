using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetSemestre
{
    public partial class Client : Form
    {
        Fonctions Con;

        public Client()
        {
            InitializeComponent();
            Con = new Fonctions();
            ListeClients();
        }

        private void ListeClients()
        {
            string Requete = "Select Clientid as ID,ClientNom as Nom,ClientPrenom as Prenom,ClientAdd as Adresse ,ClientTel as Telephone,ClientVille as Ville from ClientTable";
            guna2DataGridView1.DataSource = Con.RecupererDonnees(Requete);

        }


        int k = 0;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            guna2TextBox5.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            if (guna2TextBox1.Text == "")
            {
                k = 0;
            }

            else
            {
                k = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }



        private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        {
            //Modifier
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox4.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Veulliez Séléctionner la ligne que vous voulez modifier !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nom = guna2TextBox1.Text;
                    string prenom = guna2TextBox2.Text;
                    string add = guna2TextBox3.Text;
                    string ville = guna2TextBox4.Text;
                    string tel = guna2TextBox5.Text;
                    string Req = "update ClientTable set ClientNom='{0}',ClientPrenom='{1}',ClientAdd='{2}',ClientTel='{3}',ClientVille='{4}' where Clientid={5}";

                    Req = string.Format(Req, nom, prenom, add, ville, tel, k);
                    Con.EnvoyerDonnees(Req);
                    ListeClients();
                    MessageBox.Show("Données de Client est Bien Modifiée !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();

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
            //Enregistrer 
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Veulliez Remplir Tous les champs !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    string nom = guna2TextBox1.Text;
                    string prenom = guna2TextBox2.Text;
                    string add = guna2TextBox3.Text;
                    string ville = guna2TextBox4.Text;
                    string tel = guna2TextBox5.Text;

                    string Req = "insert into ClientTable values('{0}','{1}','{2}','{3}','{4}')";
                    Req = string.Format(Req, nom, prenom, add, ville, tel);
                    Con.EnvoyerDonnees(Req);
                    ListeClients();
                    MessageBox.Show("Client Bien Ajouté !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();

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
                    string Req = "delete from ClientTable where Clientid={0}";

                    Req = string.Format(Req, k);
                    Con.EnvoyerDonnees(Req);
                    ListeClients();
                    MessageBox.Show("Client Supprimer !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();

                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Suppression Annuler !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Index obj = new Index();
            obj.Show();
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Chambres obj = new Chambres();
            obj.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Reservation obj = new Reservation();
            obj.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Categorie obj = new Categorie();
            obj.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            User obj = new User();
            obj.Show();
            this.Hide();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
    

