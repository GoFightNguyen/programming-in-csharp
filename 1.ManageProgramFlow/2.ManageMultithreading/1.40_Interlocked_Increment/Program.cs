using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._40_Interlocked_Increment
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 0;

            var up = Task.Run(() =>
                {
                    for (var i = 0; i < 1000000; i++)
                        Interlocked.Increment(ref n);
                });

            for (var i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);

            up.Wait();
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
