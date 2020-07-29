using System.Collections.Generic;
using System.Linq;

namespace _4._60_GroupByAndProjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>();

            //How many of each product were sold?
            var result = from o in orders
                         from l in o.OrderLines
                         group l by l.Product into p
                         select new     //projection
                         {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                         };
        }

        public class Product
        {
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public class OrderLine
        {
            public int Amount { get; set; }
            public Product Product { get; set; }
        }

        public class Order
        {
            public List<OrderLine> OrderLines { get; set; }
        }
    }
}
