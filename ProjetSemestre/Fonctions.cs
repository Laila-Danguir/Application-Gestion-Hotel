using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjetSemestre
{
    public class Fonctions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string constring;
        public Fonctions()
        {
            constring = "Data Source=LAPTOP-ANIPGGB0\\SQLEXPRESS;Initial Catalog=GestionHotel;Integrated Security=True;Pooling=False";
            con = new SqlConnection(constring);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable RecupererDonnees(string Req)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Req,constring);
            sda.Fill(dt);
            return dt;
        }
        public int EnvoyerDonnees(string Req)
        {
            int i= 0;
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Req;
            i=cmd.ExecuteNonQuery();
            return i;
        }

    }
}
