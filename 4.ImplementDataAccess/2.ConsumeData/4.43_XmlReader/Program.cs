using System;
using System.IO;
using System.Xml;

namespace _4._43_XmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                            <people>
                                <person firstName='John' lastName='Doe'>
                                    <contactDetails>
                                        <emailAddress>john@microsoft.com</emailAddress>
                                    </contactDetails>
                                </person>
                                <person firstName='jane' lastName='doe'>
                                    <contactDetails>
                                        <emailAddress>jane@microsoft.com</emailAddress>
                                        <phoneNumber>0001112222</phoneNumber>
                                    </contactDetails>
                                </person>
                            </people>";

            using (var stringReader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                xmlReader.MoveToContent();
                xmlReader.ReadStartElement("people");

                string firstName = xmlReader.GetAttribute("firstName");
                string lastName = xmlReader.GetAttribute("lastName");

                Console.WriteLine("Person: {0} {1}", firstName, lastName);

                xmlReader.ReadStartElement("person");
                Console.WriteLine("Contact Details");
                xmlReader.ReadStartElement("contactDetails");
                string emailAddress = xmlReader.ReadElementContentAsString();

                Console.WriteLine("Email: {0}", emailAddress);
            }

            Console.ReadLine();
        }
    }
}
