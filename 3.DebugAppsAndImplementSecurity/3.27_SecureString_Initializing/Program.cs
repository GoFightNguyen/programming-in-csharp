using System;
using System.Security;

namespace _3._27_SecureString_Initializing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ss = new SecureString())
            {
                Console.Write("Please enter password: ");
                while(true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }

                ss.MakeReadOnly();
            }
        }
    }
}
