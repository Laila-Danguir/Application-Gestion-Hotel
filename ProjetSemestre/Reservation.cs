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
    public partial class Reservation : Form
    {   
        Fonctions Con;
        public Reservation()
        {
            InitializeComponent();
            Con = new Fonctions();
            ListeChambre();
            ListeReser();
            RemplirClient();

            //ListeOcc();
        }
        private void ListeChambre()
        {
            string st = "Libre";
            string Requete = "select Chambid as Code,ChambNom as Nom,CategoNom as Categorie,ChambPrix as Prix ,ChambStatut as Statut , Localisation from ChambreTab inner join CategorieTable on ChambreTab.ChambCat= CategorieTable.Categoid where ChambStatut='{0}'";
            Requete = string.Format(Requete, st);
            guna2DataGridView1.DataSource = Con.RecupererDonnees(Requete);

        }
        private void RemplirClient()
        {
            string q = "select * from ClientTable";
            comboBox1.DisplayMember = Con.RecupererDonnees(q).Columns["ClientNom"].ToString();
            comboBox1.ValueMember = Con.RecupererDonnees(q).Columns["Clientid"].ToString();
            comboBox1.DataSource = Con.RecupererDonnees(q);
        }


        private void ListeReser()
        {
            string Requete = "select Resid as Code,ResDate as Date,ResChambre as Num_Ch,ClientNom as Client, DateEntree as Date_Entrée , DateSortie as Date_Sortie, Montant as Montant from ReserTable inner join ClientTable on ReserTable.ResClient=ClientTable.Clientid";
            guna2DataGridView2.DataSource = Con.RecupererDonnees(Requete);
        }

        private void ChangerEtat()
        {
            //Enregistrer 
            try
            {
                    string st = "Occuper";
                    string Req = "update ChambreTab set ChambStatut ='{0}'where Chambid='{1}'";
                    Req = string.Format(Req,st,k);
                    Con.EnvoyerDonnees(Req);
                    ListeChambre();
                    MessageBox.Show("Chambre Réserver !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);


            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Prix = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString());


            if (guna2TextBox1.Text == "")
            {
                k = 0;
            }
            else
            {
                k = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }


        int user = Connexion.user;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
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
                    string client = comboBox1.SelectedValue.ToString();



                    string Req = "insert into ReserTable values('{0}',{1},'{2}','{3}','{4}',{5})";
                    Req = string.Format(Req, System.DateTime.Today,k ,client,guna2DateTimePicker1.Value.Date, guna2DateTimePicker2.Value.Date, PrixTotal);
                    Con.EnvoyerDonnees(Req);

                    ListeReser();

                    MessageBox.Show("Réservation Bien Effectuer !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangerEtat();
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);


            }
        
    }
        int k = 0,Prix,PrixTotal;
    
       


        private void guna2GradientButton2_Click(object sender, EventArgs e) 
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer cette Réservation ? !!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {

                    int indice = guna2DataGridView2.CurrentRow.Index;
                    guna2DataGridView2.Rows.RemoveAt(indice);

                   /* string Req = "delete from ReserTable where Resid={0}";

                    Req = string.Format(Req, k);
                    Con.EnvoyerDonnees(Req);
                    ListeReser();*/
                    MessageBox.Show("Réservation Supprimer !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Message);
            }
        }
        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e) { }
 


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Index obj = new Index();
            obj.Show();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Chambres obj = new Chambres();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            User obj = new User();
            obj.Show();
            this.Hide();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Reservation_Load(object sender, EventArgs e){ }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            // Calculer le montant
            TimeSpan ts = guna2DateTimePicker2.Value.Date - guna2DateTimePicker1.Value.Date;
            int jours = ts.Days;
            PrixTotal = Prix* jours;
            guna2TextBox2.Text = PrixTotal+ " Dh";
        }

       
    }
}
