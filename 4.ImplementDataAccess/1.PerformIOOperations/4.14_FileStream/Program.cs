using System.IO;
using System.Text;

namespace _4._14_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\test.dat";

            //using (FileStream fileStream = new FileInfo(path).Create())
            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "myValue";
                var data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }
    }
}
