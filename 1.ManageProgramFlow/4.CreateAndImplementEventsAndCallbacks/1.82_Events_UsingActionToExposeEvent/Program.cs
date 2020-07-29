using System;

namespace _1._82_Events_UsingActionToExposeEvent
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
        public Action OnChange { get; set; }

        //This is how to do it using a delegate directly
        //public delegate void ABC();
        //public ABC OnChange { get; set; }

        public void Raise()
        {
            if (OnChange != null)
                OnChange();
        }
    }
}
