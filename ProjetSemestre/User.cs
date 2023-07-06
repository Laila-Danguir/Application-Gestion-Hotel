using Guna.UI2.WinForms;
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
    public partial class User : Form
    {
        Fonctions Con;
        public User()
        {
            InitializeComponent();
            Con = new Fonctions();
            ListeUser();
        }
        private void ListeUser()
        {
            string Requete = "Select Userid as ID,UserNom as Nom,UserTel as Telephone,UserGenre as Genre,UserAdd as Adresse, UserMdp as Mot_de_passe from UserTable";
            guna2DataGridView1.DataSource = Con.RecupererDonnees(Requete);

        }

        private void User_Load(object sender, EventArgs e) {}
        private void button1_Click(object sender, EventArgs e){}
        private void button5_Click(object sender, EventArgs e){}
        private void button2_Click(object sender, EventArgs e){ }

        int k = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            guna2TextBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
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

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e){}

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Index ind =new Index();
            ind.Show();
            this.Close();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {

            //Enregistrer 
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Veulliez Remplir Tous les champs !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nom = guna2TextBox1.Text;
                    string tel = guna2TextBox2.Text;
                    string genre = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                    string add = guna2TextBox4.Text;
                    string mdp = guna2TextBox5.Text;
                    string Req = "insert into UserTable values('{0}','{1}','{2}','{3}','{4}')";
                    Req = string.Format(Req, nom, tel, genre, add, mdp);
                    Con.EnvoyerDonnees(Req);
                    ListeUser();
                    MessageBox.Show("Utilisateur Bien Ajouté !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();
                    comboBox1.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        {
            //Modifier
            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Veulliez Remplir Tous les champs !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nom = guna2TextBox1.Text;
                    string tel = guna2TextBox2.Text;
                    string genre = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                    string add = guna2TextBox4.Text;
                    string mdp = guna2TextBox5.Text;
                    string Req = "update UserTable set UserNom='{0}',UserTel='{1}',UserGenre='{2}',UserAdd='{3}',UserMdp='{4}' where Userid={5}";

                    Req = string.Format(Req, nom, tel, genre, add, mdp, k);
                    Con.EnvoyerDonnees(Req);
                    ListeUser();
                    MessageBox.Show("Utilisateur Bien Modifié !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();
                    comboBox1.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Message);

            }
        }

        private void guna2GradientCircleButton1_Click_1(object sender, EventArgs e)
        {
            //SUPPRIMER
            try
            {
                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer cette ligne ? !!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {  
                    string nom = guna2TextBox1.Text;
                    string tel = guna2TextBox2.Text;
                    string genre = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                    string add = guna2TextBox4.Text;
                    string mdp = guna2TextBox5.Text;
                    string Req = "delete from UserTable where Userid={0}";

                    Req = string.Format(Req, k);
                    Con.EnvoyerDonnees(Req);
                    ListeUser();
                    MessageBox.Show("Utilisateur Supprimer !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox4.Clear();
                    guna2TextBox5.Clear();
                    comboBox1.ResetText();

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
               

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            
            Index obj = new Index();
            obj.Show();
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Chambres cham = new Chambres();
            cham.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Categorie cat = new Categorie();
            cat.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Categorie obj = new Categorie();
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
