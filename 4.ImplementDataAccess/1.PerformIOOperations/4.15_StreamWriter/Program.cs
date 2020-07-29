using System.IO;

namespace _4._15_StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\test.dat";

            using (StreamWriter streamWriter = File.CreateText(path))
            {
                //Compare this to the previous example, and notice here we don't have to encode the data
                string myValue = "myValue";
                streamWriter.Write(myValue);
            }
        }
    }
}
