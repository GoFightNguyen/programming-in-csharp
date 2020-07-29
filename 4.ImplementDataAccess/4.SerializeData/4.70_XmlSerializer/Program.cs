using System;
using System.IO;
using System.Xml.Serialization;

namespace _4._70_XmlSerializer
{
    public class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string xml;

            using (StringWriter writer = new StringWriter())
            {
                var p = new Person { FirstName = "kevin", LastName = "Durant", Age = 24 };
                serializer.Serialize(writer, p);
                xml = writer.ToString();
            }

            Console.WriteLine(xml);
            Console.WriteLine();

            using (StringReader reader = new StringReader(xml))
            {
                var p = (Person)serializer.Deserialize(reader);
                Console.WriteLine("{0} {1} is {2} years old", p.FirstName, p.LastName, p.Age);
            }

            Console.ReadLine();
        }

        [Serializable]
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}
