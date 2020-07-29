using System;
using System.Xml;
using System.Xml.XPath;

namespace _4._46_XPath_Query
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

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XPathNavigator nav = doc.CreateNavigator();
            string query = "//people/person[@firstName='jane']";
            //string query = "//people/person";
            XPathNodeIterator iterator = nav.Select(query);

            while(iterator.MoveNext())
            {
                string firstName = iterator.Current.GetAttribute("firstName", "");
                string lastName = iterator.Current.GetAttribute("lastName", "");
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            Console.Read();
        }
    }
}
