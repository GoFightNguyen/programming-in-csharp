using _4._71_XmlSerializer_XmlAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace _4._72_XmlSerializer_SerializeDerivedType
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VipOrder) });
            //XmlSerializer serializer = new XmlSerializer(typeof(Order));

            string xml;
            using (StringWriter writer = new StringWriter())
            {
                Order o = CreateOrder();
                serializer.Serialize(writer, o);
                xml = writer.ToString();
            }

            Console.WriteLine(xml);
            Console.WriteLine();
            Console.ReadLine();
        }

        private static Order CreateOrder()
        {
            var p1 = new Product { Id = 1, Description = "p1", Price = 9 };
            var p2 = new Product { Id = 2, Description = "p2", Price = 6 };

            var order = new VipOrder
            {
                Id = 4,
                Description = "Order for John Doe",
                OrderLines = new List<OrderLine>
                {
                    new OrderLine {Id = 5, Amount = 1, Product = p1 },
                    new OrderLine {Id = 6, Amount = 10, Product = p2 }
                }
            };

            return order;
        }
    }
}
