using System;
using System.Threading;

namespace Threads_1._5_ThreadStaticAttribute
{
    class Program
    {
        [ThreadStatic]
        public static int Field;

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Field++;
                    Console.WriteLine("Thread A: {0}", Field);
                }
            }).Start();

            new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Field++;
                    Console.WriteLine("Thread B: {0}", Field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
