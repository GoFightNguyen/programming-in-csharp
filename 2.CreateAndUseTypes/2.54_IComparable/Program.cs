using System;
using System.Collections.Generic;

namespace _2._54_IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
            {
                new Order { Created = new DateTime(2012,12, 1) },
                new Order { Created = new DateTime(2012, 1, 6) },
                new Order { Created = new DateTime(2012, 7, 8) },
                new Order { Created = new DateTime(2012, 2, 20) }
            };

            orders.Sort();
            foreach(var o in orders)
            {
                Console.WriteLine(o.Created);
            }

            Console.ReadLine();
        }
    }

    class Order : IComparable
    {
        public DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Order o = obj as Order;

            if (o == null)
                throw new ArgumentException("Object is not an " + nameof(Order));

            return Created.CompareTo(o.Created);
        }
    }
}
