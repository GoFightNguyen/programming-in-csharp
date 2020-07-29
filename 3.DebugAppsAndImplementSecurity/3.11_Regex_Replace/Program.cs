using System;
using System.Text.RegularExpressions;

namespace _3._11_Regex_Replace
{
    class Program
    {
        static void Main(string[] args)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);

            string input = "1     2 3 4   5";
            string result = regex.Replace(input, " ");

            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
