using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _4._67_CreateXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = new XElement("Root",
                new List<XElement>
                {
                    new XElement("Child1"),
                    new XElement("Child2")
                },
                new XAttribute("MyAttribute", 42));
            Console.WriteLine(root);
            Console.WriteLine();

            XElement root3 = new XElement("Root",
                new XElement("Child1"),
                new XElement("Child2"),
                new XAttribute("MyAttribute", 42));

            Console.WriteLine(root3);
            Console.WriteLine();

            XElement root2 = new XElement("Root2");
            root2.Add(new XElement("Child1"));
            root2.Add(new XElement("Child2"));
            root2.Add(new XAttribute("MyAttribute", 42));
            Console.WriteLine(root2);

            Console.ReadLine();
        }
    }
}
