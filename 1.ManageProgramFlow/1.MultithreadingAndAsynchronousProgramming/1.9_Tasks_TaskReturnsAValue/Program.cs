using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1._9_Tasks_TaskReturnsAValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return 42;
            });

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }
    }
}
