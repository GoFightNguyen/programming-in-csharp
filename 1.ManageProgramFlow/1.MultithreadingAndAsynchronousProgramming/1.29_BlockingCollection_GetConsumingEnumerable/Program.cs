using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace _1._29_BlockingCollection_GetConsumingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = new BlockingCollection<string>();

            //This does the same as in 1.28
            var read = Task.Run(() =>
            {
                foreach (var s in col.GetConsumingEnumerable()) //Without GetConsumingEnumerable, this will actually block until col.IsAddingCompleted is true
                    Console.WriteLine(s);
            });

            var write = Task.Run(() =>
            {
                while (true)
                {
                    var s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();
        }
    }
}
