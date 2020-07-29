using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace _1._28_ConcurrentCollections_BlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = new BlockingCollection<string>();

            //the consumer
            var read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            //the producer
            var write = Task.Run(() =>
            {
                while (true)
                {
                    var s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            //Since the threads a Task use are background threads by default (since they come from the ThreadPool), then we must Wait on them so the app does not exit
            write.Wait();
        }
    }
}
