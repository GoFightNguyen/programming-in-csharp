using System;
using System.Threading;

namespace Threads_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (var i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t.Join();   //tells the main thread to wait until thread t finishes

            Console.ReadLine();
        }

        public static void ThreadMethod()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
