using System;
using System.Threading;

namespace Lab9
{//barrier
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Thread(() => PlayMusic("gitarzysta", "grać", 5));
            var t2 = new Thread(() => PlayMusic("wokalista", "śpiewać", 2));

            t1.Start();
            t2.Start();
        }

        static Barrier _barrier = new Barrier(2,
    b => Console.WriteLine("Koniec fazy {0}", b.CurrentPhaseNumber + 1));

        static void PlayMusic(string name, string message, int seconds)
        {
            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine("***");
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
                Console.WriteLine("{0} zaczyna {1}", name, message);
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
                Console.WriteLine("{0} konczy {1}", name, message);
                _barrier.SignalAndWait();
            }
        }
    }
}
