using System;
using System.Linq;

namespace _1._25_PLINQ_AsSequential
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();

            foreach (var i in parallelResult.Take(5))
                Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
