using System;
using System.Collections.Concurrent;

namespace _1._32_ConcurrentCollections_ConcurrentStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new ConcurrentStack<int>();
            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped {0}", result);

            stack.PushRange(new int[] { 1, 2, 3});

            var values = new int[2];
            stack.TryPopRange(values);

            foreach (var i in values)
                Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
