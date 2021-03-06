﻿using System;
using System.Linq;

namespace _1._23_PLINQ_UnorderedParallelQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach(var i in parallelResult)
                Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
