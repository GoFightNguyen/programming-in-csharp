using System;
using System.Reflection;

namespace _2._73_Reflection_ExecuteAMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 42;
            MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
