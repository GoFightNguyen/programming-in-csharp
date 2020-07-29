using System;
using System.Security.Cryptography;

namespace _3._18_ExportingKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKey = rsa.ToXmlString(false);
            string publicAndPrivateKey = rsa.ToXmlString(true);

            Console.WriteLine(publicKey);
            Console.WriteLine("\n\n\n");
            Console.WriteLine(publicAndPrivateKey);
            Console.ReadLine();
        }
    }
}
