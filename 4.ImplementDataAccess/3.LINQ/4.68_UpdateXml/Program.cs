using System;
using System.Linq;
using System.Xml.Linq;

namespace _4._68_UpdateXml
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <people>
                                <person firstName=""john"" lastName=""doe"">
                                    <contactDetails>
                                        <emailAddress>john@microsoft.com</emailAddress>
                                    </contactDetails>
                                </person>
                                <person firstName=""jane"" lastName=""doe"">
                                    <contactDetails>
                                        <emailAddress>john@microsoft.com</emailAddress>
                                        <phoneNumber>1234567890</phoneNumber>
                                    </contactDetails>
                                </person>
                            </people>";

            //Procedural way (non-LINQ)
            XElement root = XElement.Parse(xml);
            foreach(XElement p in root.Descendants("person"))
            {
                string name = (string)p.Attribute("firstName") + " " + (string)p.Attribute("lastName");
                p.Add(new XAttribute("isMale", name.Contains("john")));
                XElement contactDetails = p.Element("contactDetails");
                if (!contactDetails.Descendants("phoneNumber").Any())
                    contactDetails.Add(new XElement("phoneNumber", "001122334455"));
            }

            Console.WriteLine(root);
            Console.WriteLine();

            //Functional Constructor way (LINQ)
            XElement root2 = XElement.Parse(xml);
            XElement newTree = new XElement("people",
                from p in root2.Descendants("person")
                let name = (string)p.Attribute("firstName") + " " + (string)p.Attribute("lastName")
                let contactDetails = p.Element("contactDetails")
                select new XElement("person",
                    new XAttribute("isMale", name.Contains("john")),
                    p.Attributes(),
                    new XElement("contactDetails",
                        contactDetails.Element("emailAddress"),
                        contactDetails.Element("phoneNumber") ?? new XElement("phoneNumber", "001122334455"))));

            Console.WriteLine(newTree);
            Console.ReadLine();
        }
    }
}
