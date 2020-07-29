using System;
using System.Collections.Concurrent;

namespace _1._33_ConcurrentCollections_ConcurrentQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
