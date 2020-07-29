using System;
using System.IO;
using System.Text;

namespace _4._16_StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\test.dat";

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];

                for(int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }

                Console.WriteLine(Encoding.UTF8.GetString(data));
            }

            using (StreamReader streamReader = File.OpenText(path))
            {
                Console.WriteLine(streamReader.ReadLine());
            }
        }
    }
}
