using System;
using System.Threading.Tasks;

namespace _1._8_Tasks_StartingANewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                    Console.Write("*");
            });

            t.Wait();
        }
    }
}
