using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._45_Cancel_Timeout
{
    class Program
    {
        static void Main(string[] args)
        {
            var longRunningTask = Task.Run(() =>
            {
                Console.WriteLine("*");
                Thread.Sleep(10000);
            }).ContinueWith((t) =>
            {
                Console.WriteLine("canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            var index = Task.WaitAny(new[] { longRunningTask }, 1000);

            if (index == -1)
                Console.WriteLine("Task timed out");

            Console.ReadLine();
        }
    }
}
