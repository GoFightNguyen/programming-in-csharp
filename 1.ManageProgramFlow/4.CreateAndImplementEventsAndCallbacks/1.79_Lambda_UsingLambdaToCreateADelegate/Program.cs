using System;

namespace _1._79_Lambda_UsingLambdaToCreateADelegate
{
    class Program
    {
        //This shows how you would write the 1.75 example with the new lambda syntax

        delegate int Calculate(int x, int y);

        static void Main(string[] args)
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4));

            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));
            
            Console.ReadLine();
        }
    }
}
