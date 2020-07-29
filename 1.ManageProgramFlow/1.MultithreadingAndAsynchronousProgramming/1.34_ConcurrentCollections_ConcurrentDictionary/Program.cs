using System;
using System.Collections.Concurrent;

namespace _1._34_ConcurrentCollections_ConcurrentDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new ConcurrentDictionary<string, int>();

            if (dictionary.TryAdd("k1", 42))
                Console.WriteLine("added");

            if (dictionary.TryUpdate("k1", 21, 42))
                Console.WriteLine("42 updated to 21");

            dictionary["k1"] = 42; //overwrite unconditionally

            int r1 = dictionary.AddOrUpdate("k1", 3, (s, i) => i * 2);
            Console.WriteLine("r1: {0}", r1);
            int r2 = dictionary.GetOrAdd("k2", 3);
            Console.WriteLine("k2: {0}", r2);

            Console.ReadLine();
        }
    }
}
