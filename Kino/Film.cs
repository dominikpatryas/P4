using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    using System.Windows.Controls;

   public class Film
    {
        public int ID { get; set; }

        public string NazwaFilmu { get; set; }

        public string GatunekFilmu { get; set; }

        public int RokProdukcji { get; set; }

        public string OpisFilmu { get; set; }

        public string CzasFilmu { get; set; }


        public Film(int iD, string nazwaFilmu, string gatunekFilmu, int rokProdukcji, string opisFilmu, string czasFilmu)
        {
            ID = iD;
            NazwaFilmu = nazwaFilmu;
            GatunekFilmu = gatunekFilmu;
            RokProdukcji = rokProdukcji;
            OpisFilmu = opisFilmu;
            CzasFilmu = czasFilmu;
        }
    }
}
