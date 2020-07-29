using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _3._24_DigitalCertificate
{
    class Program
    {
        //This will not work until I run the following
        //makecert -n "CN=WouterDeKort" -sr currentuser -ss testCertStore

        static void Main(string[] args)
        {
            string textToSign = "Test paragraph";
            byte[] signature = Sign(textToSign, "cn=WouterDeKort");
            //signature[0] = 0; //uncomment to make the verification step fail
            Console.WriteLine(Verify(textToSign, signature));
        }

        static byte[] Sign(string text, string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        private static byte[] HashData(string text)
        {
            HashAlgorithm alg = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = alg.ComputeHash(data);
            return hash;
        }

        private static X509Certificate2 GetCertificate()
        {
            X509Store store = new X509Store("testCertStore", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            return store.Certificates[0];
        }
    }
}
