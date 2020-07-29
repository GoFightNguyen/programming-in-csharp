using System;
using System.Xml;
using System.Xml.Schema;

namespace _3._16_XML_ReadAndValidate
{
    class Program
    {
        static void Main(string[] args)
        {
            string xsdPath = "Person.xsd";
            string xmlPath = "Person.xml";

            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                XmlDocument document = new XmlDocument();
                document.Schemas.Add("", xsdPath);
                document.Load(reader);

                //This event handler will be called if someting is wrong with the XML file
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
                document.Validate(eventHandler);
            }

            Console.WriteLine("finished");
            Console.ReadLine();
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch(e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }
    }
}
