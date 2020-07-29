using System;
using System.Threading.Tasks;

namespace _1._35_Synchronizing_NoSynchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            //The operation of incrementing/decrementing the variable n results in both a lookup and an add/subtract
            //The operation is not atomic, meaning another thread can interfere before the operation completes

            int n = 0;

            var up = Task.Run(() =>
            {
                for (var i = 0; i < 1000000; i++)
                    n++;
            });

            for (var i = 0; i < 1000000; i++)
                n--;

            up.Wait();
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
