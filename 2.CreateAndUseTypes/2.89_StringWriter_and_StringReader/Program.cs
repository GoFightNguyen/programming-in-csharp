using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace _2._89_StringWriter_and_StringReader
{
    class Program
    {
        static void Main(string[] args)
        {

            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }

            string xml = stringWriter.ToString();
            Console.WriteLine(xml);

            var stringReader = new StringReader(xml);
            using (var reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(), new CultureInfo("en-us"));
                Console.WriteLine(price);
            }

            Console.ReadLine();
        }
    }
}
