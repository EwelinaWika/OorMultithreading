using System;
using System.Threading;

namespace Lab7
{//ManualResetEventSlim
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Thread(() => TravelThroughGates("Watek 1", 5));
            var t2 = new Thread(() => TravelThroughGates("Watek 2", 6));
            var t3 = new Thread(() => TravelThroughGates("Watek 3", 12));
            t1.Start();
            t2.Start();
            t3.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            Console.WriteLine("Otwarte");
            _mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _mainEvent.Reset();
            Console.WriteLine("Zamkniete");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("Otwarte po raz drugi");
            _mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Zamkniete");
            _mainEvent.Reset();
        }

        static void TravelThroughGates(string threadName, int seconds)
        {
            Console.WriteLine("{0} uspiony", threadName);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} czeka na otwarcie", threadName);
            _mainEvent.Wait();
            Console.WriteLine("{0} wchodzi", threadName);
        }

        static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);
    }
}
