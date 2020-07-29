using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace _3._23_Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 hasher = SHA256.Create();

            string data = "A paragraph of text";
            byte[] hashA = hasher.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of changed text";
            byte[] hashB = hasher.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of text";
            byte[] hashC = hasher.ComputeHash(byteConverter.GetBytes(data));

            Console.WriteLine("HashA: {0}", byteConverter.GetString(hashA));
            Console.WriteLine("\n\n\n");
            Console.WriteLine("HashB: {0}", byteConverter.GetString(hashB));
        
            Console.WriteLine("\n\n\n");
            Console.WriteLine(hashA.SequenceEqual(hashB));
            Console.WriteLine(hashA.SequenceEqual(hashC));
            Console.ReadLine();
        }
    }
}
