using System;
using System.Security.Cryptography;
using System.Text;

namespace _3._19_AsymmetricEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider sourceRsa = new RSACryptoServiceProvider();
            string publicKeyXML = sourceRsa.ToXmlString(false);
            string privateKeyXML = sourceRsa.ToXmlString(true);

            var byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes("My Secret Data!");

            byte[] encryptedData;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXML);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXML);
                decryptedData = rsa.Decrypt(encryptedData, false);
            }

            string decryptedString = byteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString);
            Console.ReadLine();
        }
    }
}
