using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    using System.Windows;

    public class Sql
    {
        private readonly static string conStr =
            "Data Source=LAPTOP-HJ934Q3G;Initial Catalog=Kino;Integrated Security=True";

        public bool Login(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string q1 = $"SELECT COUNT(1) from Sprzedawcy WHERE Login = '{username}' AND Password = '{password}'";
                con.Open();
                SqlCommand queryUsername = new SqlCommand(q1,con);
                    
                    var res = Convert.ToInt32(queryUsername.ExecuteScalar());

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
    }
}
