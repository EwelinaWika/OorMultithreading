using System;
using System.Threading;

namespace Lab6
{//AutoResetEvent
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(() => Process(10));
            t.Start();

            Console.WriteLine("Oczekiwanie na zakonczenie pracy kolejnego watku");
            _workerEvent.WaitOne();
            Console.WriteLine("Ukonczona pierwsza operacja.");
            Console.WriteLine("Wykonywanie operacji na watku glownym");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _mainEvent.Set();
            Console.WriteLine("Teraz dziala druga operacja na drugim watku");
            _workerEvent.WaitOne();
            Console.WriteLine("Druga operacja zakonczona.");
            Console.ReadKey();
        }

        private static AutoResetEvent _workerEvent = new AutoResetEvent(false);
        private static AutoResetEvent _mainEvent = new AutoResetEvent(false);

        static void Process(int seconds)
        {
            Console.WriteLine("Rozpoczecie dlugotrwalej pracy...");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Praca zakonczona.");
            _workerEvent.Set();
            Console.WriteLine("Oczekiwanie na zakonczenie pracy glownego watku");
            _mainEvent.WaitOne();
            Console.WriteLine("Zaczynanie drugiej operacji...");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Operacja ukonczona");
            _workerEvent.Set();
        }
    }
}

