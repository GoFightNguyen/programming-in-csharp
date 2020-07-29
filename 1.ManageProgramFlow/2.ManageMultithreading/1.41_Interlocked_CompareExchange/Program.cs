using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._41_Interlocked_CompareExchange
{
    class Program
    {
        static int value = 1;

        static void Main(string[] args)
        {
            var t1 = Task.Run(() =>
            {
                //if (value == 1)
                //{
                //    Thread.Sleep(1000);
                //    value = 2;
                //}

                //Unlike the above, this will atomically compare value to 1, and if true, set it to 2
                Interlocked.CompareExchange(ref value, 2, 1);
            });

            var t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
