using System;

namespace _2._1_FlagAttributeForAnEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            var day1 = Days.Monday;
            Console.WriteLine("day1 == Monday is {0}", day1 == Days.Monday);
            Console.WriteLine();

            var day2 = Days.Monday | Days.Wednesday;
            Console.WriteLine("day2 has Monday is {0}", (day2 & Days.Monday) == Days.Monday);
            Console.WriteLine("day2 has Wednesday is  {0}", (day2 & Days.Wednesday) == Days.Wednesday);
            Console.WriteLine("day2 has Thursday is  {0}", (day2 & Days.Thursday) == Days.Thursday);
            Console.WriteLine("day2 is {0}", day2);
            Console.WriteLine();

            var day3 = Days.Monday & Days.Wednesday;
            Console.WriteLine("day3 has Monday is  {0}", (day3 & Days.Monday) == Days.Monday);
            Console.WriteLine("day3 has Wednesday is  {0}", (day3 & Days.Wednesday) == Days.Wednesday);
            Console.WriteLine("day3 is {0}", day3);

            Console.ReadLine();
        }
    }

    [Flags]
    enum Days
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
}
