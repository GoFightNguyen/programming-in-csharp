using System;
using System.Linq;

namespace _1._26_PLINQ_ForAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0);

            //Parallel
            parallelResult.ForAll(e => Console.WriteLine(e));
            Console.WriteLine();

            //not parallel because the iterator has to have all results before executing
            foreach (var i in parallelResult)
                Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
