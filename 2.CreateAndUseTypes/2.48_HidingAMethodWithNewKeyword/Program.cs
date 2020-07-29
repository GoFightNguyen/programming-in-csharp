using System;

namespace _2._48_HidingAMethodWithNewKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Base();
            b.Execute();
            b = new Derived();
            b.Execute();

            var d = new Derived();
            d.Execute();

            Console.ReadLine();
        }
    }
    
    class Base
    {
        public void Execute()
        {
            Console.WriteLine("Base");
        }
    }

    class Derived : Base
    {
        public new void Execute()
        {
            Console.WriteLine("Derived");
        }
    }
}
