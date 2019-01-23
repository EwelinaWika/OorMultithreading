using System;
using System.Threading;

namespace Lab5
{//SemaphoreSlim
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 6; i++)
            {
                string threadName = "Watek " + i;
                int secondsToWait = 2 + 2 * i;
                var t = new Thread(() => AccessDatabase(threadName, secondsToWait));
                t.Start();
            }
            Console.ReadKey();
        }

        static SemaphoreSlim _semaphore = new SemaphoreSlim(4);

        static void AccessDatabase(string name, int seconds)
        {
            Console.WriteLine("{0} czeka na dostep do bazy danych", name);
            _semaphore.Wait();
            Console.WriteLine("{0} uzyskal dostep do bazy danych", name);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} jest wykonany", name);
            _semaphore.Release();

        }
    }
}
