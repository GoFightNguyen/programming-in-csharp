using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._43_Cancel_OperationCanceledException
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            var task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
            }, token);

            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();

                source.Cancel();
                task.Wait();
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions[0].Message);
            }

            Console.WriteLine("Press enter to stop the app");
            Console.ReadLine();
        }
    }
}
