using System;
using System.Threading;

namespace Threads_1._6_ThreadLocal
{
    class Program
    {
        //The ThreadLocal<T> can be declared statically, or within the method creating the threads.
        //The initilization does not occur until the new threads actually access it.

        public static ThreadLocal<int> Field =
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        static void Main(string[] args)
        {
            //ThreadLocal<int> Field =
            //new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

            new Thread(() =>
            {
                for (var i = 0; i < Field.Value; i ++)
                    Console.WriteLine("Thread A: {0}", i);
            }).Start();

            new Thread(() =>
            {
                for (var i = 0; i < Field.Value; i ++)
                    Console.WriteLine("Thread B: {0}", i);
            }).Start();

            Console.ReadLine();
        }
    }
}
