using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    using System.Windows;

    public class Sql : ISql
    {

        private readonly static string conStr =
            "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True";

        public bool Login(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                    
                var res = Convert.ToInt32(new SqlCommand($"SELECT COUNT(1) from Klient WHERE Login = '{username}' AND Password = '{password}'", con).ExecuteScalar());

                if (res == 1) return true;
                else return false;

            }
        }

        public bool Login_sprzedawca(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                var res = Convert.ToInt32(new SqlCommand($"SELECT COUNT(1) from Sprzedawcy WHERE Login = '{username}' AND Password = '{password}'", con).ExecuteScalar());

                if (res == 1) return true;
                else return false;

            }
        }

        public bool Register(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string q1 = $"INSERT INTO Klient(Login,Password) VALUES ('{username}','{password}')";
                string q2 = $"SELECT COUNT(1) from Klient WHERE Login = '{username}'";

                SqlCommand queryCheckExists = new SqlCommand(q2, con);

                var res2 = Convert.ToInt32(queryCheckExists.ExecuteScalar());
                MessageBox.Show(q2);
                if (res2 == 1)
                {
                    return false;
                }

                else if (res2 == 0)
                {
                    SqlCommand queryInsert = new SqlCommand(q1, con);
                    var res1 =(int)queryInsert.ExecuteNonQuery();

                    if (res1 == 1)
                        return true;

                    else return false;
                }

                return true;

            }
        }

        public List<Film> sqlloadMovies()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                con.Open();

                var size = Convert.ToInt32(new SqlCommand($"SELECT COUNT(*) from Film", con).ExecuteScalar());

                var lista = new List<Film>();
                
                for (int i = 1; i <= size; i++)
                {
                    var a = new SqlCommand($"SELECT NazwaFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();

                    var b = new SqlCommand($"SELECT GatunekFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();
                    
                    var c = Convert.ToInt32(new SqlCommand($"SELECT RokProdukcji from Film WHERE ID = {i}", con).ExecuteScalar());
                    
                    var d = new SqlCommand($"SELECT OpisFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();

                    var e = new SqlCommand($"SELECT CzasFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();


                    Film film = new Film(i ,a, b, c, d, e);
                    
                    lista.Add(film);
                }
                
                return lista;
            }
        }

        public void AddMovie(string nazwa, string gatunek, int rok, string opis, DateTime data)
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                string q1 = $"Insert into Film(NazwaFilmu, GatunekFilmu, RokProdukcji, OpisFilmu, CzasFilmu) Values('{nazwa}', '{gatunek}','{rok}','{opis}','{data}')";

                con.Open();
                var query = (int)new SqlCommand(q1, con).ExecuteNonQuery();

                if (query == 1)
                {
                    MessageBox.Show("ok");
                }
                else MessageBox.Show("error");
            }
        }
    }
}
