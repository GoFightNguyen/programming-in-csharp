using System;
using System.Threading;

namespace Threads_1._4_StoppingAThread
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopped = false;

            var t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }
    }
}
