using System.Linq;

namespace _1._22_PLINQ_AsParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100000000);
            //var nonParallelResult = numbers.Where(i => i % 2 == 0).ToArray();
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
        }
    }
}
