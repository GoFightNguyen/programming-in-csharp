using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace _4._78_DataContractSerializer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Person CreateAndRead()
        {
            string xml;
            var p = new Person { Id = 3, Name = "John Doe" };

            using (StringWriter stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
                serializer.WriteObject(xmlWriter, p);
                xmlWriter.Flush();
                xml = stringWriter.ToString();
            }

            Person result;
            using (StringReader stringReader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(stringReader))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
                result = (Person)serializer.ReadObject(xmlReader);
            }

            return result;
        }
    }
}
