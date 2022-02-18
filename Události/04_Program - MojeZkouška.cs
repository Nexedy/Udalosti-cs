using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Události
{
    class Program
    {

        //class Publisher
        class Vydavatel
        {
            public delegate void ShitEventHandler(Vydavatel v, EventArgs e);
            public EventArgs e = null;

            //deklarace události 
            public event ShitEventHandler Oh;

            //Metoda, která vyvolá shit každé 3 sekundy
            public void Start()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(3000);
                    Oh.Invoke(this, e);
                }
            }

            //class Subscriber
            class Oběratel
            {
                //metoda pro obsluhu události
                private void Padá(object source, EventArgs e)
                {
                    Console.WriteLine("Pozor padá exkrement!!!!!");
                }

                //metoda na registraci
                public void Registrace(Vydavatel v)
                {
                    v.Oh += Padá;
                }
            }
        }

        static void Main(string[] args)
        {
            //instance vydavatele
            Vydavatel v = new Vydavatel();

            //instance odběratele
            Odběratel o = new Odběratel();

            //vyvlání události
            v.Oh();+

        }
    }
}
