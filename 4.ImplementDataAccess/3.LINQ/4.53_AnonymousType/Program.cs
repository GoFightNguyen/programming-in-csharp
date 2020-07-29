using System;

namespace _4._53_AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uses both implicit typing and object initialization
            var person = new
            {
                FirstName = "Jason",
                LastName = "Kidd"
            };

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.GetType().Name);
            Console.ReadLine();
        }
    }
}
