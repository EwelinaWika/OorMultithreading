using System;
using System.Threading;


namespace Lab4
{//synchronizacja watkow: Mutex
    class Program
    {
        static void Main(string[] args)
        {
            const string MutexName = "SomeMutex";//definiowanie mutexu o danej nazwie

            using (var m = new Mutex(false, MutexName))//ustawianie flagi na false
            {
                if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Console.WriteLine("Druga instancja dziala");
                }
                else
                {
                    Console.WriteLine("Dziala");
                    Console.ReadLine();
                    m.ReleaseMutex();
                }
            }
        }
    }
}
