using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._87_Events_ManuallyRaisingEventsWithExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pub();

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1");
            p.OnChange += (sender, e) =>
            {
                throw new Exception();
            };
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3");

            try
            {
                p.Raise();
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }

            Console.ReadLine();
        }
    }

    public class Pub
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach(Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch(Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if(exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
