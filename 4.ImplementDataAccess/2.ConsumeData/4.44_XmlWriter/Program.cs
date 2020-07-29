using System;
using System.IO;
using System.Xml;

namespace _4._44_XmlWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("people");
                    xmlWriter.WriteStartElement("person");
                    xmlWriter.WriteAttributeString("firstName", "John");
                    xmlWriter.WriteAttributeString("lastName", "Doe");
                    xmlWriter.WriteStartElement("contactDetails");
                    xmlWriter.WriteElementString("emailAddress", "john@microsoft.com");
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.Flush();
                }
                Console.WriteLine(stream);
            }
            Console.ReadLine();
        }
    }
}
