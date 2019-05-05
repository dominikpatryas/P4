using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models
{
   public class Klient
    {
        public int ID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int NumerMiejsca { get; set; }

        public Film Film { get; set; }


        public Klient(int iD, string login, string password, string firstName, string secondName, Film film, int numerMiejsca)
        {
            NumerMiejsca = numerMiejsca;
            ID = iD;
            Login = login;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
            Film = film;
        }

        public Klient( string login, string password, string firstName, string secondName)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
        }

        public Klient(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
