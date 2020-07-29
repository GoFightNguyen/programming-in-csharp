using System;

namespace _2._61_Reflection_IsAttributeDefined
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
                Console.WriteLine("Defined");
            else
                Console.WriteLine("Not defined");

            Console.ReadLine();
        }
    }

    [Serializable]
    class Person { }
}
