using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _4._73_BinaryFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person { Id = 3, Name = "John Doe" };

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                Person result = (Person)formatter.Deserialize(stream);
            }

            Console.ReadLine();
        }
    }

    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isDirty = false;
    }
}
