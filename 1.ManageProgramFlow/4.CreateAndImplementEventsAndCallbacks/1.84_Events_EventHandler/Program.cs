using System;

namespace _1._84_Events_EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pub();
            p.OnChange += (sender, e) => Console.WriteLine(e.Value);
            p.Raise();

            Console.ReadLine();
        }
    }

    public class MyArgs : EventArgs
    {
        public int Value { get; set; }

        public MyArgs(int value)
        {
            Value = value;
        }
    }

    public class Pub
    {
        public event EventHandler<MyArgs> OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }
}
