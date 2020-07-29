using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace _4._79_DataContractJsonSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person { Id = 1, Name = "John Doe" };

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
                serializer.WriteObject(stream, p);

                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                Console.WriteLine(reader.ReadToEnd());

                stream.Position = 0;
                Person result = (Person)serializer.ReadObject(stream);
            }

            Console.ReadLine();
        }

        [DataContract]
        public class Person
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            //[DataMember]
            private bool isDirty = true;
        }
    }
}
