using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetSemestre
{
    public partial class Chambres : Form
    {
        Fonctions Con;
        public Chambres()
        {
            InitializeComponent();
            Con = new Fonctions();
            ListeChambre();
            RemplirCatego();
        }
        private void ListeChambre()
        {
            string Requete = "Select ChambreTab.Chambid, ChambreTab.ChambNom, CategorieTable.CategoNom, ChambreTab.ChambPrix, ChambreTab.ChambStatut, ChambreTab.Localisation from ChambreTab inner join CategorieTable on ChambreTab.ChambCat = CategorieTable.Categoid";
            guna2DataGridView1.DataSource = Con.RecupererDonnees(Requete);

        }
        private void RemplirCatego()
        {
            string q = "select * from CategorieTable";
            comboBox1.DisplayMember = Con.RecupererDonnees(q).Columns["CategoNom"].ToString();
            comboBox1.ValueMember = Con.RecupererDonnees(q).Columns["Categoid"].ToString();
            comboBox1.DataSource = Con.RecupererDonnees(q);
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
            this.Close();
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


        private void Chambres_Load(object sender, EventArgs e)
        {

        }
        int k = 0;
        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2TextBox4.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox3.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();


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
                if (guna2TextBox1.Text == "" || guna2TextBox4.Text == "")
                {
                    MessageBox.Show("Veulliez Séléctionner la ligne que vous voulez modifier !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nom = guna2TextBox1.Text;
                    string cat = comboBox1.SelectedValue.ToString();
                    //string cat = this.comboBox1.GetItemText(this.comboBox1.SelectedItem).ToString();
                    int prix = Convert.ToInt32(guna2TextBox4.Text);
                    string statu = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                    string loc = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);

                    string Req = "update ChambreTab set ChambNom='{0}',ChambCat='{1}',ChambPrix='{2}',ChambStatut='{3}',Localisation='{4}' where Chambid={5}";

                    Req = string.Format(Req,nom,cat,prix,statu,loc,k);
                    Con.EnvoyerDonnees(Req);
                    ListeChambre();
                    MessageBox.Show("Données de chambre Bien Modifié !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox4.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();

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
                if (guna2TextBox1.Text == "" || guna2TextBox4.Text == "")
                {
                    MessageBox.Show("Veulliez Remplir Tous les champs !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                    string nom = guna2TextBox1.Text;
                    string cat = comboBox1.SelectedValue.ToString();
                    int prix = Convert.ToInt32(guna2TextBox4.Text);
                    string statu = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                    string loc = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);


                    string Req = "insert into ChambreTab values('{0}','{1}','{2}','{3}','{4}')";
                    Req = string.Format(Req, nom,cat,prix,statu,loc);
                    Con.EnvoyerDonnees(Req);
                    ListeChambre();
                    MessageBox.Show("Chambre Ajouter !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox4.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);


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
                    string cat = this.comboBox1.GetItemText(this.comboBox1.SelectedItem).ToString();
                    int prix = Convert.ToInt32(guna2TextBox4.Text);
                    string statu = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                    string loc = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);

                    string Req = "delete from ChambreTab where Chambid={0}";

                    Req = string.Format(Req, k);
                    Con.EnvoyerDonnees(Req);
                    ListeChambre();
                    MessageBox.Show("Chambre Supprimer !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox4.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();



                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Suppression Annuler !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    guna2TextBox1.Clear();
                    guna2TextBox4.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    comboBox3.ResetText();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            obj.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            User obj = new User();
            obj.Show();
            this.Hide();
        }
    }
}
