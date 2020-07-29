using System;
using System.Threading.Tasks;

namespace _1._36_Synchronizing_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 0;
            var _lock = new object();

            var up = Task.Run(() =>
            {
                for(var i = 0; i < 1000000; i++)
                    lock (_lock)
                        n++;
            });

            for(var i = 0; i < 1000000; i++)
                lock(_lock)
                    n--;

            up.Wait();
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
