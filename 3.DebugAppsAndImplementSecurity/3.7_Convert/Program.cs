using System;

namespace _3._7_Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = Convert.ToInt32(null);
            Console.WriteLine(i);

            double d = 23.32;
            int i2 = Convert.ToInt32(d);
            Console.WriteLine(i2);

            Console.ReadLine();
        }
    }
}
