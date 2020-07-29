using System;
using System.Runtime.Serialization;

namespace _1._98_CustomExceptions_Creating
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [Serializable]
    public class OrderProcessingException : Exception, ISerializable
    {
        public int OrderId { get; private set; }

        public OrderProcessingException(int orderId)
        {
            OrderId = orderId;
            HelpLink = "http://www.msn.com";
        }

        public OrderProcessingException(int orderId, string message)
            : base(message)
        {
            OrderId = orderId;
            HelpLink = "http://www.msn.com";
        }

        public OrderProcessingException(int orderId, string message, Exception innerException)
            : base(message, innerException)
        {
            OrderId = orderId;
            HelpLink = "http://www.msn.com";
        }

        protected OrderProcessingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            OrderId = (int)info.GetValue("OrderId", typeof(int));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("OrderId", OrderId, typeof(int));
        }
    }
}
