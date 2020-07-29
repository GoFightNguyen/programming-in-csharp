using System.Runtime.Serialization;
using System.ServiceModel;

namespace _4._78_DataContractSerializer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Person CreateAndRead();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        //[DataMember]
        private bool isDirty = false;   //will be excluded since it does not have DataMember
    }
}
