using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Události
{
    class Program
    {

        //použiju generický delegate

        //class Publisher
        class Vydavatel
        {
            public event EventHandler OnDg;  //deklarace události !!!ZMĚNA!!!

            //Vyvolání události 
            public void Start()
            {
                for (int i = 0; i <= 100; i++)
                {
                    if (i % 9 == 0 && OnDg != null) OnDg(this, null); //Pokud bude i dělitelno 9 beze zbytku tak se zavolá OnDg !!!ZMĚNA!!!
                }
            }
        }

        //class Subscriber
        class Předplatitel
        {
            public void Obsluha(object source, EventArgs e) //!!!ZMĚNA!!!
            {
                Console.WriteLine("Číslo je dělitelné devíti.");
            }

            public void Registrace(Vydavatel v)
            {
                v.OnDg += Obsluha; //!!!ZMĚNA!!!
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
