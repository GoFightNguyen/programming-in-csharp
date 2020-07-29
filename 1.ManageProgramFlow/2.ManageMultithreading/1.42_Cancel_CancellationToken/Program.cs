using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._42_Cancel_CancellationToken
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
            }, token);

            Console.WriteLine("Press enter to stop");
            Console.ReadLine();
            source.Cancel();

            Console.WriteLine("Press enter to close the app");
            Console.ReadLine();
        }
    }
}
