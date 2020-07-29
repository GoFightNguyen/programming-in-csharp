using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace _1._7_ThreadPools_QueuingWorkToThreadPool
{
    class Program
    {

        static List<int> threadIds = new List<int>();
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem((s) =>
            //{
            //    for (int i = 0; i < 10; i++)
            //        Console.WriteLine("Thread 1: {0}", i);
            //});

            //ThreadPool.QueueUserWorkItem((s) =>
            //{
            //    for (int i = 0; i < 10; i++)
            //        Console.WriteLine("Thread 2: {0}", i);
            //});

            for (int threadNum = 0; threadNum < 500; threadNum++)
                ThreadPool.QueueUserWorkItem(Work(threadNum));

            Console.ReadLine();
        }

        private static WaitCallback Work(int threadNum)
        {
            return (s) =>
            {
                threadIds.Add(Thread.CurrentThread.ManagedThreadId);    //This was so I could inspect and get the number of threads actually used
                for (int i = 0; i < 10; i++)
                    Console.WriteLine("Thread {0} {1}: {2}", threadNum, Thread.CurrentThread.ManagedThreadId, i);
            };
        }
    }
}
