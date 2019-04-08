using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models
{
    class Sala
    {
        public int ID { get; set; }

        public int Pojemnosc { get; set; }

        public List<int> MiejscaZajete { get; set; }
        public List<int> MiejscaWolne { get; set; }

        public Sala()
        {
              
        }

    }
}
