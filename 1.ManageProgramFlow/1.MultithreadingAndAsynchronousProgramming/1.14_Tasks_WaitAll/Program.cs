using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._14_Tasks_WaitAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Task[3];

            //All these tasks will run simultaneously. So instead of taking 7 seconds, it will only take 5
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(1);
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(2);
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine(3);
            });

            Task.WaitAll(tasks);
            Console.WriteLine("Finished");

            //Task.WhenAll(tasks).ContinueWith(t => Console.WriteLine("Finished"));

            Console.ReadLine();
        }
    }
}
