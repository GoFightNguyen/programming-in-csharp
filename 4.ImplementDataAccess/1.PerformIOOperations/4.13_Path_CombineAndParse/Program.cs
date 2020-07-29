using System;
using System.IO;

namespace _4._13_Path_CombineAndParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"c:\temp\subdir";
            string fileName = "test.dat";
            string fullPath = Path.Combine(folder, fileName);

            Console.WriteLine(Path.GetDirectoryName(fullPath));
            Console.WriteLine(Path.GetExtension(fullPath));
            Console.WriteLine(Path.GetFileName(fullPath));
            Console.WriteLine(Path.GetPathRoot(fullPath));

            Console.ReadLine();
        }
    }
}
