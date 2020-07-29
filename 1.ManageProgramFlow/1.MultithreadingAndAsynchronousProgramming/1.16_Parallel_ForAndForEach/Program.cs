using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _1._16_Parallel_ForAndForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            //Each Thread.Sleep will be run concurrently, so it will not take 10 seconds
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            Console.WriteLine("Finished with For");

            //The above Parallel.For will finish before executing the following
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i => 
            {
                Thread.Sleep(1000);
            });

            Console.WriteLine("finished with ForEach");
            Console.ReadLine();
        }
    }
}
