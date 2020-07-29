using System;
using System.Globalization;

namespace _3._5_ParseTryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parse");
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b);

            Console.WriteLine("\nTryParse");
            string value1 = "1";
            int result;
            bool success = int.TryParse(value1, out result);
            if (success)
                Console.WriteLine(result);
            else
                Console.WriteLine("failure");

            Console.WriteLine("\nParsing with culture info");
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");
            string value2 = "$19.95";
            decimal d = decimal.Parse(value2, NumberStyles.Currency, english);
            Console.WriteLine(d.ToString(dutch));

            Console.ReadLine();
        }
    }
}
