using System;
using System.Diagnostics;

namespace _2._62_Reflection_GetSpecificAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var conditionalAttributes = Attribute.GetCustomAttributes(typeof(PersonAttribute), typeof(ConditionalAttribute));

            foreach (var att in conditionalAttributes)
            {
                var conditionalAtt = att as ConditionalAttribute;
                Console.WriteLine(conditionalAtt.ConditionString);
            }

            Console.ReadLine();
        }
    }

    [Conditional("Condition1")]
    [Conditional("Condition2")]
    class PersonAttribute : Attribute
    {

    }
}
