using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraudimasSuPaveldejimu
{
    abstract class TransportoPriemone
    {
        public string TransportoPriem { get; protected set; }

        public double Svoris { get; protected set; }
        public int MaxGreitis { get; protected set; }
        public int Galia { get; protected set; }
        public int Rida { get; protected set; }
        public int Metai { get; protected set; }

        public TransportoPriemone()
        {
            Console.WriteLine("Iveskite transporto priemone");
            TransportoPriem = Console.ReadLine();
            Console.WriteLine("Iveskite transporto priemones svori");
            Svoris = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Iveskite transporto priemones max greiti");
            MaxGreitis = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite transporto priemones galia");
            Galia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite transporto priemones rida");
            Rida = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite pagaminimo metus");
            Metai = Convert.ToInt32(Console.ReadLine());
        }

        public double KoeficientoSkaic()
        {
            double koef = 0.0;
            const int dabartis = 2017;
            var senumas = 0;
            var RidaPerMetus = 0;
            senumas = dabartis - Metai;
            if (senumas <= 0)
            { RidaPerMetus = 1000; }
            else { RidaPerMetus = Rida / senumas; }
            koef = ((double)senumas) / 4.5;
            koef = ((double)Galia / 50) * koef;
            koef = ((double)RidaPerMetus / 4000) * koef;
            return koef;
        }

        public abstract void Ivedimas();
    }
    class Automoblis : TransportoPriemone
    {
        public string AutomobiliotMarke { get; private set; }
        public string AutomobilioModelis { get; private set; }
        public Automoblis()
        {
        }

        public override void Ivedimas()
        {
            Console.WriteLine("Iveskite automobiloi marke");
            AutomobiliotMarke = Console.ReadLine();
            Console.WriteLine("Iveskite automobiio modeli");
            AutomobilioModelis = Console.ReadLine();
        }

        public void Isvedimas()
        {
            Console.WriteLine("Transpoto priemone {0} {1} {2}", TransportoPriem, AutomobiliotMarke, AutomobilioModelis);
        }
    }
    class Motociklas : TransportoPriemone
    {
        public string MotocikloTipas { get; private set; }
        public string PrivalSaugPriem { get; private set; }

        public Motociklas()
        {
        }

        public override void Ivedimas()
        {
            Console.WriteLine("Iveskite motociklo tipa");
            MotocikloTipas = Console.ReadLine();
            Console.WriteLine("Iveskite motociklo privalomas saugumo priemones");
            PrivalSaugPriem = Console.ReadLine();
        }

        public void Isvedimas()
        {
            Console.WriteLine("Transpoto priemone {0}, tipas- {1}, saugumo priemones: {2}", TransportoPriem, MotocikloTipas, PrivalSaugPriem);
        }

    }
}
