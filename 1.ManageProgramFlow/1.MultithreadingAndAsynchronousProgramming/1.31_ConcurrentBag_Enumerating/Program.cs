using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace _1._31_ConcurrentBag_Enumerating
{
    class Program
    {
        static void Main(string[] args)
        {
            var bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                //Since iterating over ConcurrentBag, ConcurrentQueue, ConcurrentStack, and ConcurrentDictionary provides you a snapshot of the data,
                //then it is possible that the snapshot is empty, only has 42, or has 42 and 21
                foreach (var i in bag)
                    Console.WriteLine(i);
            }).Wait();

            Console.ReadLine();
        }
    }
}
