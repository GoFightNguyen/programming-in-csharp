using System;
using System.Linq;
using System.Xml.Linq;

namespace _4._65_QueryXml
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

            XDocument doc = XDocument.Parse(xml);
            var personNames = from p in doc.Descendants("person")
                              select (string)p.Attribute("firstName") + " " + (string)p.Attribute("lastName");

            foreach (var name in personNames)
                Console.WriteLine(name);

            Console.ReadLine();
        }
    }
}
