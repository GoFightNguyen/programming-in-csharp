using System;
using System.Threading;

namespace Threads_1._3_UsingParameterizedThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
        }

        private static void ThreadMethod(object obj)
        {
            for (var i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
