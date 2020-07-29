using System;

namespace _4._51_AnonymousMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //anonymous method
            Func<int, int> myDelegate = delegate (int x)
            {
                return x * 2;
            };
            Console.WriteLine("Anonymous Method: {0}", myDelegate(21));

            //anonymous method, but using lambda expression
            Func<int, int> myDelegate2 = x => x * 2;
            Console.WriteLine("Anonymous Method using Lambda Expression: {0}", myDelegate2(21));

            Console.ReadLine();
        }
    }
}
