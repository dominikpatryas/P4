using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    using System.Collections;
    using System.Windows;

    using Kino.Models;

    public class Sql 
    {

        private readonly static string conStr =
            "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True";

        public bool isSeller = false;
        public Klient Login(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                    
                var res = Convert.ToInt32(new SqlCommand($"SELECT COUNT(1) from Klient WHERE Login = '{username}' AND Password = '{password}'", con).ExecuteScalar());

                if (res == 1)
                {
                    Klient klient = new Klient(username, password);
                    var id = getClientID(username);
                    klient.ID = id;
                    return klient;
                }
                else {
                    
                    return null;
                }
            }
        }

        private int getClientID(string username)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                var res = Convert.ToInt32(
                    new SqlCommand(
                        $"SELECT ID from Klient WHERE Login = '{username}'",
                        con).ExecuteScalar());

                return res;

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
                    var NazwaFilmu = new SqlCommand($"SELECT NazwaFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();

                    var GatunekFilmu = new SqlCommand($"SELECT GatunekFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();
                    
                    var RokProdukcji = Convert.ToInt32(new SqlCommand($"SELECT RokProdukcji from Film WHERE ID = {i}", con).ExecuteScalar());
                    
                    var OpisFilmu = new SqlCommand($"SELECT OpisFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();

                    var CzasFilmu = new SqlCommand($"SELECT CzasFilmu from Film WHERE ID = {i}", con).ExecuteScalar().ToString();

                    var PhotoUrl = new SqlCommand($"SELECT PhotoUrl from Film WHERE ID = {i}", con).ExecuteScalar().ToString();


                    Film film = new Film(i ,NazwaFilmu, GatunekFilmu, RokProdukcji, OpisFilmu ,CzasFilmu, PhotoUrl);
                    
                    lista.Add(film);
                }
                
                return lista;
            }
        }

        public void AddMovie(string nazwa, string gatunek, int rok, string opis, string data)
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                string q1 = $"Insert into Film(NazwaFilmu, GatunekFilmu, RokProdukcji, OpisFilmu, CzasFilmu) Values('{nazwa}', '{gatunek}','{rok}','{opis}','{data}')";
                con.Open();
                var query = (int)new SqlCommand(q1, con).ExecuteNonQuery();

                string q2 = $"select ID From Film where NazwaFilmu='{nazwa}'";
                var id_movie = (int)new SqlCommand(q2, con).ExecuteScalar();
                // string q3 = $"Insert into Sale(ID_filmu, NazwaFilmu) Values({id_movie}, '{nazwa}')";
                // var q3_query = (int)new SqlCommand(q3, con).ExecuteNonQuery();

            }
        }

        public void ReserveMovie(Klient klient, Film film, ArrayList currentSeat)
        {
            using (SqlConnection con = new SqlConnection(
                "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                con.Open();
                
                    string q1 = $"UPDATE Klient SET IDFilmu = {film.ID} WHERE login = '{klient.Login}';"
                                + $" UPDATE Klient SET NumerMiejsca = {currentSeat} WHERE login = '{klient.Login}'";

            foreach (var i in currentSeat)
            {
                string q4 =
                        $"Insert into Sale(ID_Klienta,ID_Filmu, NazwaFilmu, NumerMiejsca) VALUES ('{klient.ID}', '{film.ID}', '{film.NazwaFilmu}','{i}')";

                    var query_Q4 = (int)new SqlCommand(q4, con).ExecuteNonQuery();
                }
                
            }
        }


        public int[] RedSeatsMovie(int IDMovie)
        {
            using (SqlConnection con = new SqlConnection(
                "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                con.Open();
                string q0 = $"SELECT COUNT(*) FROM Klient";
                var countOfRows = (int)new SqlCommand(q0, con).ExecuteScalar();
                int[] seats = new int[countOfRows];

                for (int i = 1; i <= countOfRows-1; i++)
                {

                string q1 = $"SELECT NumerMiejsca From Klient WHERE ID={i} ";
                  seats[i]  = (int)new SqlCommand(q1, con).ExecuteScalar();
                    
                }

                return seats;

            }
        }

        public ArrayList RedRealSeatsMovie(int IDMovie)
        {
            using (SqlConnection con = new SqlConnection(
                "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                con.Open();
                string q0 = $"SELECT COUNT(*) FROM Sale WHERE ID_Filmu={IDMovie}";
                var countOfRows = (int)new SqlCommand(q0, con).ExecuteScalar();
                ArrayList seats = new ArrayList(); 

               
                   SqlCommand command = new SqlCommand($"SELECT NumerMiejsca From Sale WHERE ID_Filmu ={IDMovie} ", con);
                    SqlDataReader dataReader = command.ExecuteReader();
               
                    while (dataReader.Read())
                    {
                            seats.Add(Convert.ToInt32(dataReader[0].ToString()));
                    }



                return seats;

            }
        }

        public int getCountOfRows(int IDMovie)
        {
            using (SqlConnection con = new SqlConnection(
                "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                con.Open();
                string q0 = $"SELECT COUNT(*) FROM Sale WHERE ID_Filmu='{IDMovie}'";
                var countOfRows = (int)new SqlCommand(q0, con).ExecuteScalar();

                return countOfRows;
            }
        }

        public int getCountOfUsers()
        {
            using (SqlConnection con = new SqlConnection(
                "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True"))
            {
                con.Open();
                string q0 = $"SELECT COUNT(*) FROM Klient";
                var countOfUsers = (int)new SqlCommand(q0, con).ExecuteScalar();
                

                return countOfUsers;

            }

        }
    }
}
