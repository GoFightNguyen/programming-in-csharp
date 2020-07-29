using System;
using System.Linq;

namespace _1._27_PLINQ_AggregateException
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel()
                    .Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("There were {0} exceptions", ex.InnerExceptions.Count);
            }
            Console.ReadLine();
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException(nameof(i));
            return i % 2 == 0;
        }
    }
}
