using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._10_Tasks_Continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                Thread.Sleep(5000);
                return i.Result * 42;
            });

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }
    }
}
