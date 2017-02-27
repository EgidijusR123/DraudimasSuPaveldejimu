using System;
using System.Collections.Generic;

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

        private void Parinkimas(Zmogus[] zmogusauto, Zmogus[] zmogusmoto, List<DraudimoKompanijos> draudimai, double[] koefauto, double[] koefmoto,Automoblis[] automobil,Motociklas[] motocikl)
        {
            int i = 0;
            var lengthauto = zmogusauto.Length;
                for (int j = 0;j< lengthauto; j++)
                {
                Console.WriteLine("---------------------------------------------------------------------------");
                    while (i != 4)
                    {
                        if (zmogusauto[j].ZmogausAmzius < draudimai[i].DraudziamojoMinAmzius || zmogusauto[j].ZmogausAmzius > draudimai[i].DraudziamojoMaxAmzius)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0} nedraudzia!", draudimai[i].DraudimoPavadinimas);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (zmogusauto[j].ArZmogusTuriNuolaidu == draudimai[i].ArTeikiamaNuolaida && zmogusauto[j].ArZmogusTuriNuolaidu == true)
                        {
                            Console.WriteLine("{2}. {1} draus-{3}, kurio savininkas {4} ir kaina bus {0} EUR.", Math.Round((draudimai[i].DraudimoKaina * koefauto[j]),1), draudimai[i].DraudimoPavadinimas, (i+1),automobil[j].AutomobiliotMarke,zmogusauto[j].ZmogausVardas);
                        }
                        else
                        {
                            Console.WriteLine("{2}. {1} draus-{3}, kurio savininkas {4} ir kaina bus {0} EUR.", Math.Round((draudimai[i].DraudimoKaina * koefauto[j]),1), draudimai[i].DraudimoPavadinimas, (i+1), automobil[j].AutomobiliotMarke, zmogusauto[j].ZmogausVardas);
                        }
                        i++;
                    }
                Console.WriteLine("---------------------------------------------------------------------------");
                i = 0;
                }
            
            var lengthmoto = zmogusmoto.Length;

            for (int k = 0; k < lengthmoto; k++)
                {
                Console.WriteLine("---------------------------------------------------------------------------");
                while (i != 4)
                    {
                        if (zmogusmoto[k].ZmogausAmzius < draudimai[i].DraudziamojoMinAmzius || zmogusmoto[k].ZmogausAmzius > draudimai[i].DraudziamojoMaxAmzius)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0} nedraudzia!", draudimai[i].DraudimoPavadinimas);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (zmogusmoto[k].ArZmogusTuriNuolaidu == draudimai[i].ArTeikiamaNuolaida && zmogusmoto[k].ArZmogusTuriNuolaidu == true)
                        {
                            Console.WriteLine("{2}. {1} draus-{3}, kurio savininkas {4} ir kaina bus {0} EUR.", Math.Round((draudimai[i].DraudimoKaina * koefmoto[k]),1), draudimai[i].DraudimoPavadinimas, (i+1),motocikl[k].MotocikloTipas,zmogusmoto[k].ZmogausVardas);
                        }
                        else
                        {
                            Console.WriteLine("{2}. {1} draus-{3}, kurio savininkas {4} ir kaina bus {0} EUR.", Math.Round((draudimai[i].DraudimoKaina * koefmoto[k]),1), draudimai[i].DraudimoPavadinimas, (i+1),motocikl[k].MotocikloTipas, zmogusmoto[k].ZmogausVardas);
                        }
                        i++;
                    }
                Console.WriteLine("---------------------------------------------------------------------------");
                i = 0;
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

            double[] koefBendr = new double[KiekAuto + KiekMoto];

            programele.Parinkimas(zmogusauto, zmogusmoto, Drauduuumas, koeficientasAuto, koeficientasMoto, automobilis, motociklas);

            Console.ReadKey();
        }
    }
}