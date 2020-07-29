using System.ServiceModel;

namespace _4._39_WCF
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string DoWork(string left, string right);
    }
}
