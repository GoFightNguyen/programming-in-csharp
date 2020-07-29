using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._37_Synchronizing_Deadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            var lockA = new object();
            var lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                        Console.WriteLine("Locked A and B");
                }
            });

            Thread.Sleep(500); //provide a small delay in hopes the background thread can lock A before the main thread locks B
            lock(lockB)
                lock(lockA)
                    Console.WriteLine("Locked B and A");

            up.Wait();
            Console.ReadLine();
        }
    }
}
