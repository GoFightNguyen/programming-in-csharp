using System;
using System.IO;
using System.Security.Cryptography;

namespace _3._17_SymmetricEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = "My secret data!";

            using (var symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundTrip = Decrypt(symmetricAlgorithm, encrypted);

                Console.WriteLine("Original: {0}", original);
                Console.WriteLine("Roundtrip: {0}", roundTrip);
            }
            Console.ReadLine();
        }

        static byte[] Encrypt(SymmetricAlgorithm alg, string plainText)
        {
            ICryptoTransform encryptor = alg.CreateEncryptor(alg.Key, alg.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncryp = new StreamWriter(csEncrypt))
                    {
                        swEncryp.Write(plainText);
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        static string Decrypt(SymmetricAlgorithm alg, byte[] cipherText)
        {
            ICryptoTransform decryptor = alg.CreateDecryptor(alg.Key, alg.IV);

            using (var msDecrypt = new MemoryStream(cipherText))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecryp = new StreamReader(csDecrypt))
                    {
                        return srDecryp.ReadToEnd();
                    }
                }
            }
        }
    }
}
