using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace _4._76_ISerializable
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [Serializable]
        public class Person : ISerializable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private bool isDirty = false;

            public Person()
            {
            }

            protected Person(SerializationInfo info, StreamingContext context)
            {
                //In real scenarios, you would want to ensure nobody tampered with the data, especially since it is sensitive

                Id = info.GetInt32("value1");
                Name = info.GetString("value2");
                isDirty = info.GetBoolean("value3");
            }

            [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                //In real life, you would want to exclude some data and encrypt some

                info.AddValue("value1", Id);
                info.AddValue("value2", Name);
                info.AddValue("value3", isDirty);
            }
        }
    }
}
