using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraudimasSuPaveldejimu
{
    
    class Program
    {
        private void InformacijosIvedimasAuto(Automoblis[] automobiliai, Zmogus[] zmogus, double[] koeficient, int kiekis)
        {
            for (int i = 0; i < kiekis; i++)
            {
                Automoblis automob = new Automoblis();
                Zmogus zmog = new Zmogus();
                automob.Ivedimas();
                zmog.IvedimasZmogui();
                automobiliai[i] = automob;
                zmogus[i] = zmog;
                koeficient[i]= (automob.KoeficientoSkaic())*0.7;
            }
        }

        private void InformacijosIvedimasMoto(Motociklas[] motociklai, Zmogus[] zmogus, double[] koeficientas, int kiekis)//perraso kintamaji
        {
            for (int i = 0; i < kiekis; i++)
            {
                Motociklas moto = new Motociklas();
                Zmogus zmog = new Zmogus();
                moto.Ivedimas();
                zmog.IvedimasZmogui();
                motociklai[i] = moto;
                zmogus[i] = zmog;
                koeficientas[i] = (moto.KoeficientoSkaic())*1.3;

            }
        }
    
        private double ZmogausKoeficientas(Zmogus zmogus)
        {
            double koef = 0.0;
            if (zmogus.ArZmogusTurejoAvariju == true)
            {
                koef = 1.5;
            }
            else { koef = 0.7; }
            if (zmogus.ArZmogusTuriNuolaidu == true)
            {
                koef = koef * 0.8;
            }
            else { koef = koef * 1.2; }
            if (zmogus.ZmogausAmzius > 65)
            {
                koef = koef * 2;
            }
            else if (zmogus.ZmogausAmzius >= 18 && zmogus.ZmogausAmzius < 65)
            {
                koef = 40 / (double)zmogus.ZmogausAmzius * koef;
            }
            else { koef = 0.0; }
            return koef;
        }

        private double Skaiciuokle(double kof1, double kof2)
        {
            if (kof1 == 0 || kof2 == 0)
            {
                return 0.0;
            }
            return Math.Round((kof1 + kof2), 1);
        }
        private void IsvedimoBandymas(Automoblis[]automob,Motociklas[]motocikl,Zmogus[]zmogisauto,Zmogus[]zmogimoto, List <DraudimoKompanijos>darudimai, double[] autokoef,double[] motokoef)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int i = 0;
            foreach (var auto in automob)
            {
                Console.WriteLine(auto.AutomobiliotMarke+" "+auto.AutomobilioModelis+" "+autokoef[i]+" "+zmogisauto[i].ZmogausVardas+" "+zmogisauto[i].ZmogausAmzius);
                i++;
            }
            i= 0;
            foreach (var moto in motocikl)
            {
                Console.WriteLine(moto.MotocikloTipas+" "+moto.MaxGreitis+" "+motokoef[i]+" "+zmogimoto[i].ZmogausVardas+" "+zmogimoto[i].ZmogausAmzius);
                i++;
            }
         
        }
        private void Parinkimas(Zmogus zmogus, List<DraudimoKompanijos> draudimai, double koeficeintas)
        {
            int i = 1;
            foreach (var draudimas in draudimai)
            {
                if (zmogus.ZmogausAmzius < draudimas.DraudziamojoMinAmzius || zmogus.ZmogausAmzius > draudimas.DraudziamojoMaxAmzius)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} nedraudzia!", draudimas.DraudimoPavadinimas);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (zmogus.ArZmogusTuriNuolaidu == draudimas.ArTeikiamaNuolaida && zmogus.ArZmogusTuriNuolaidu == true)
                {
                    Console.WriteLine("{2}. {1} draus ir kaina bus {0} EUR.", (draudimas.DraudimoKaina * koeficeintas), draudimas.DraudimoPavadinimas, i);
                }
                else
                {
                    Console.WriteLine("{2}. {1} draus ir kaina bus {0} EUR.", (draudimas.DraudimoKaina * koeficeintas), draudimas.DraudimoPavadinimas, i);
                }
                i++;
            }
        }

        static void Main(string[] args)
        {
            Program programele = new Program();

            List<DraudimoKompanijos> Drauduuumas = new List<DraudimoKompanijos>();

            Drauduuumas.Add(new DraudimoKompanijos("Ergo", 18, 65, true, 200));
            Drauduuumas.Add(new DraudimoKompanijos("PZU", 25, 50, false, 150));
            Drauduuumas.Add(new DraudimoKompanijos("Kompensa", 21, 50, false, 170));
            Drauduuumas.Add(new DraudimoKompanijos("Lietuvos draudimas", 18, 70, true, 190));

            Console.WriteLine("Iveskite kiek bus automobiiu");
            var KiekAuto = Convert.ToInt32(Console.ReadLine());
            Automoblis[] automobilis = new Automoblis[KiekAuto];
            double[] koeficientasAuto = new double[KiekAuto];
            Zmogus[] zmogusauto = new Zmogus[KiekAuto];
            programele.InformacijosIvedimasAuto(automobilis,zmogusauto,koeficientasAuto,KiekAuto);


            Console.WriteLine("Iveskite kiek bus motociklu");
            var KiekMoto = Convert.ToInt32(Console.ReadLine());
            Motociklas[] motociklas = new Motociklas[KiekMoto];
            double[] koeficientasMoto = new double[KiekMoto];
            Zmogus[] zmogusmoto = new Zmogus[KiekMoto];
            programele.InformacijosIvedimasMoto(motociklas, zmogusmoto,koeficientasMoto, KiekMoto);

            programele.IsvedimoBandymas(automobilis, motociklas,zmogusauto, zmogusmoto, Drauduuumas, koeficientasAuto, koeficientasMoto);

            Console.ReadKey();
        }
    }
}