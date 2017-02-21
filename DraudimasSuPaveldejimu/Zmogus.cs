using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraudimasSuPaveldejimu
{
    class Zmogus
    {
        public string ZmogausVardas { get; private set; }
        public int ZmogausAmzius { get; private set; }
        public bool ArZmogusTurejoAvariju { get; private set; }
        public bool ArZmogusTuriNuolaidu { get; private set; }

        public Zmogus()
        {
        }

        public void IvedimasZmogui()
        {
            Console.WriteLine("Iveskite zmogaus varda");
            ZmogausVardas = Console.ReadLine();
            Console.WriteLine("Iveskite zmoguas amziu");
            ZmogausAmzius = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite ar zmogus turejo avariju: Taip/Ne");
            var Avarijos = Console.ReadLine();
            if (Avarijos.ToLower() == "taip")
            {
                ArZmogusTurejoAvariju = true;
            }
            else
            {
                ArZmogusTurejoAvariju = false;
            }
            Console.WriteLine("Iveskite ar zmogus turi nuolaidu: Taip/Ne");
            var Nuolaidos = Console.ReadLine();
            if (Nuolaidos.ToLower() == "taip")
            {
                ArZmogusTuriNuolaidu = true;
            }
            else
            {
                ArZmogusTuriNuolaidu = false;
            }
        }
    }
}
