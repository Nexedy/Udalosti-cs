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
         * Naprogramujte 
         * třídu Metron, ktrá vytvoří událost: každé tři sekundy vyvolá Tick
         * třídy Listenter, která slyší Tick Metronomu 
         * a tiskne do console "Slyšel jsem to!" kdykoliv obdrží událost
         */

        //class Metronom
        class Metronom
        {
            //deklarace delegate
            public delegate void TickEventHandler(Metronom m, EventArgs e);
            public EventArgs e = null;

            //deklarace události
            public event TickEventHandler Tick;

            //Metoda, která každé 3 sekundy vyvolá událost Tick
            public void Start()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(3000);

                    Tick.Invoke(this, e);
                }
                   
            }

            //Subscriber
            class Listener
            {
                //metodu pro obsluhu událostí
                private void Poslouchám(Metronom m, EventArgs e)
                {
                    Console.WriteLine("Slyšel jsem to!");
                }

                //metoda pro přihlášení k odběru
                public void Registrace(Metronom m)
                {
                    m.Tick += Poslouchám; //nebo se dá napsat m.Tick += new Metronom.TickEventHandler(Poslouchám)
                }

            }
        }

        static void Main(string[] args)
        {
            //instance vydavatele
            Metronom m = new Metronom();

            //istance odběratele
            Listener 1 = new Listener();

            //přihlášení k odběru
            1.Registrace(m);

            //Vyvolání události
            m.Start();

        }
    }
}
