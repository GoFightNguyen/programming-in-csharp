using System;
using System.Threading;

namespace Threads_1._2_UsingABackgroundThread
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start();

            //When the thread is set to a background thread, the application exits immediately after t.Start() because there are no more foreground threads.
            //If the thread is set to foreground, then the application will only exist after printing to the console 10 times
        }

        private static void ThreadMethod()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Proc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
