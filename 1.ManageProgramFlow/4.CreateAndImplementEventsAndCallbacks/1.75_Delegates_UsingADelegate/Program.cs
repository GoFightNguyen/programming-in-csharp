using System;

namespace _1._75_Delegates_UsingADelegate
{
    class Program
    {
        public delegate int Calculate(int x, int y);

        public static int Add(int x, int y) { return x + y; }
        public static int Multiply(int x, int y) { return x * y; }

        static void Main(string[] args)
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            calc = Multiply;
            Console.WriteLine(calc(3, 4));

            Console.ReadLine();
        }
    }
}
