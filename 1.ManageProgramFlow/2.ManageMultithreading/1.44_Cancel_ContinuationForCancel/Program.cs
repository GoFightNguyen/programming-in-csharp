using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._44_Cancel_ContinuationForCancel
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

                //throw new OperationCanceledException();
                token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t) =>
            {
                //t.Exception.Handle((e) => true);
                //Console.WriteLine(t.Exception.InnerExceptions[0].Message);
                Console.WriteLine("canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.ReadLine();
            source.Cancel();

            Console.ReadLine();
        }
    }
}
