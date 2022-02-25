using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Události
{
    class Program
    {
        static void Main(string[] args)
        {

            //Metronom kazdou sekundu tikne
            MetronomClass m1 = new MetronomClass(1000);
            m1.SetOnTickListener(M1Tick);
            m1.Start();

            Console.ReadLine();
            m1.Stop();
            //----------------------------------

            Console.ReadLine();

            //Metronom m2 tikne kazdou vteřinu a spustí vlastní funkci
            MetronomClass m2 = new MetronomClass(1000);
            m2.SetOnTickListener(M1Tick);
            m2.Start();

            Console.ReadLine();
            m2.Stop();
            //-----------------------------------

            //m1 a m2 naraz bezi součastně
            m1.Start();
            m2.Start();
            Console.ReadLine();
            m1.Stop();
            m2.Stop();
            //---------------------------------

            //Multimetronom
            MultiMetronom mm = new MultiMetronom(333);
            mm.AddOnTickListener(M1Tick);
            mm.Start();

            Console.ReadLine();
            mm.Stop();
            //-----------------------------------
            Console.ReadLine();

        }

        private static void M1Tick()
        {
            Console.WriteLine("Metronome tick");
        }
    }
}
