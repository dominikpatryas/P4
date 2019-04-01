using System.Collections.Generic;

namespace Kino
{
    public interface ISql
    {
        bool Login(string username, string password);
        bool Login_sprzedawca(string username, string password);
        bool Register(string username, string password);
        List<Film> sqlloadMovies();
    }
}