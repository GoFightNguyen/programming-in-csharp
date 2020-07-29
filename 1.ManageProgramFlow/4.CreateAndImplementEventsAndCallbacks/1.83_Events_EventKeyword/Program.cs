using System;

namespace _1._83_Events_EventKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pub();
            p.OnChange += () => Console.WriteLine("Method 1");
            p.OnChange += () => Console.WriteLine("Method 2");
            p.Raise();

            Console.ReadLine();
        }
    }

    public class Pub
    {
        public event Action OnChange = delegate { };

        public void Raise()
        {
            OnChange();
        }
    }
}
