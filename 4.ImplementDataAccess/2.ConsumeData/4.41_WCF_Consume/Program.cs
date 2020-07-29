using System;

namespace _4._41_WCF_Consume
{
    class Program
    {
        static void Main(string[] args)
        {
            var wcfService = new ExternalService.MyServiceClient();
            string result = wcfService.DoWork("John", "Doe");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
