using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraudimasSuPaveldejimu
{
    class DraudimoKompanijos
    {
        public string DraudimoPavadinimas { get; private set; }
        public int DraudziamojoMinAmzius { get; private set; }
        public int DraudziamojoMaxAmzius { get; private set; }
        public bool ArTeikiamaNuolaida { get; private set; }
        public double DraudimoKaina { get; private set; }

        public DraudimoKompanijos(string pavadinimas, int MinAmz, int MaxAmz, bool ArNuolaid, double kaina)
        {
            DraudimoPavadinimas = pavadinimas;
            DraudziamojoMinAmzius = MinAmz;
            DraudziamojoMaxAmzius = MaxAmz;
            ArTeikiamaNuolaida = ArNuolaid;
            DraudimoKaina = kaina;
        }
    }
}
