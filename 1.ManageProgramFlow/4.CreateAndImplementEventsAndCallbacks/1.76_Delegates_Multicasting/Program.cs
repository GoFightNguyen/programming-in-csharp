using System;

namespace _1._76_Delegates_Multicasting
{
    class Program
    {
        static void MethodOne() { Console.WriteLine("MethodOne"); }
        static void MethodTwo() { Console.WriteLine("MethodTwo"); }

        delegate void Del();

        static void Main(string[] args)
        {
            Del d = MethodOne;
            d += MethodTwo;
            d();

            d -= MethodTwo;
            d();

            Console.ReadLine();
        }
    }
}
