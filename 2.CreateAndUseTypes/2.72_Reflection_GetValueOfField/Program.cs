using System;
using System.Reflection;

namespace _2._72_Reflection_GetValueOfField
{
    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle();
            var nonPublicFields = rect.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in nonPublicFields)
                if (field.FieldType == typeof(int))
                    Console.WriteLine(field.Name + ": " + field.GetValue(rect));

            Console.ReadLine();
        }
    }

    class Rectangle
    {
        private static int NonInstance = 33;
        public int Public = 43;
        private double ignore = 33.2;

        private int height = 25;
        private int width = 100;
    }
}
