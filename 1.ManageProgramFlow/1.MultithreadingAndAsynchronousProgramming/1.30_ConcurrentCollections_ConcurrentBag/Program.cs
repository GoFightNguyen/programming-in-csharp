using System;
using System.Collections.Concurrent;

namespace _1._30_ConcurrentCollections_ConcurrentBag
{
    class Program
    {
        static void Main(string[] args)
        {
            var bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);

            Console.ReadLine();
        }
    }
}
