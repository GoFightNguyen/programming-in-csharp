using System;

namespace _1._86_Events_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pub();

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1");
            p.OnChange += (sender, e) => { throw new Exception(); };
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3");

            p.Raise();

            Console.ReadLine();
        }
    }

    public class Pub
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, EventArgs.Empty);
        }
    }
}
