using System;
using System.Text.RegularExpressions;

namespace _2._94_RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach (var name in names)
                Console.WriteLine(Regex.Replace(name, pattern, string.Empty));

            Console.ReadLine();
        }
    }
}
