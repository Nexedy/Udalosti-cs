using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Události
{
    class Program
    {

        /*
         * Každá událost musí obsahovat 5 věcí
         * 1. deklarace delegate 
         * 2. vyvoření události (class Publisher)
         * 3. Zavolání události 
         * 4. Obsluha události (class Subscriber)
         * 5. Registrace
         */

        //deklarace delegate
        public delegate void Dg();

        //class Publisher
        class Vydavatel
        {
            public event Dg OnDg;  //deklarace události

            //Vyvolání události
            public void Start()
            {
                for (int i = 0; i <= 100; i++)
                {
                    if (i % 9 == 0 && OnDg != null) OnDg();//Pokud bude i dělitelno 9 beze zbytku tak se zavolá OnDg
                }
            }
        }

        //class Subscriber
        class Předplatitel
        {
            public void Obsluha()
            {
                Console.WriteLine("Číslo je dělitelné devíti.");
            }

            //Registrace
            public void Registrace(Vydavatel v)
            {
                v.OnDg += new Dg(Obsluha);
            }
        }

        static void Main(string[] args)
        {
            Vydavatel v = new Vydavatel();
            Předplatitel p = new Předplatitel();

            p.Registrace(v);//Předplatitel se musí registrovat u vydavatele
            v.Start();//Vydavatel odstartuje

            Console.Read();
        }
    }
}
