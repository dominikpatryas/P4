using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    class Sala
    {
        public int ID { get; set; }

        public int []Miejsce { get; set; }

        public int Zarezerowana { get; set; }

        public Sala(int id, int []miejsce, int zarezerwowana)
        {
            ID = id;
            Miejsce = miejsce;
            Zarezerowana = zarezerwowana;

        }
    }
}
