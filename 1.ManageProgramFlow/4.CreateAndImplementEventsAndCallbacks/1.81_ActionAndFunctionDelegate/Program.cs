using System;

namespace _1._81_ActionAndFunctionDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Action delegate");

            Action<int, int> calc = (x, y) => Console.WriteLine(x + y);
            calc += (x, y) => Console.WriteLine("Can multicast since Action is just a delegate type");
            calc(3, 4);

            Console.WriteLine("Func delegate");

            Func<int, int, int> calc2 = (x, y) =>
            {
                Console.WriteLine("Func 1");
                return x + y;
            };

            calc2 += (x, y) =>
            {
                Console.WriteLine("Func 2 - can multicast since Func is just a delegate type");
                return x * y;
            };

            calc2(3, 4);

            Console.WriteLine("When setting a variable to a delegate with more than one method in its invocation list, then the variable will be set to the last method's return value");
            var z = calc2(3, 4);
            Console.WriteLine("z = " + z);

            Console.ReadLine();
        }
    }
}
