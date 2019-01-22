using System;
using System.Threading;

namespace Lab8
{//CountdownEvent
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rozpoczynanie dwóch operacji");
            var t1 = new Thread(() => PerformOperation("Pierwsza wykonana", 4));
            var t2 = new Thread(() => PerformOperation("Druga wykonana", 8));
            t1.Start();
            t2.Start();
            _countdown.Wait();
            Console.WriteLine("Obie wykonane.");
            _countdown.Dispose();
            Console.ReadKey();
        }

        static CountdownEvent _countdown = new CountdownEvent(2);

        static void PerformOperation(string message, int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine(message);
            _countdown.Signal();
        }
    }
}
