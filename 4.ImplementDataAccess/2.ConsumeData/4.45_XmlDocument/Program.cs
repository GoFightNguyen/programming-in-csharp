using System;
using System.Xml;

namespace _4._45_XmlDocument
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
            XmlNodeList nodes = doc.GetElementsByTagName("person");

            ReadNames(nodes);
            var newNode = CreatePersonNode(doc);
            doc.DocumentElement.AppendChild(newNode);

            Console.WriteLine("Modified xml");
            doc.Save(Console.Out);

            Console.ReadLine();
        }

        private static XmlNode CreatePersonNode(XmlDocument doc)
        {
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
            firstNameAttribute.Value = "Foo";
            lastNameAttribute.Value = "Bar";
            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);
            return newNode;
        }

        private static void ReadNames(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstName"].Value;
                string lastName = node.Attributes["lastName"].Value;
                Console.WriteLine("name: {0} {1}", firstName, lastName);
            }
        }
    }
}
