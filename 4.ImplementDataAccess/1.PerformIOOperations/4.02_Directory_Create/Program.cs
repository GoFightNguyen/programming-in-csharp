using System.IO;

namespace _4._02_Directory_Create
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = Directory.CreateDirectory(@"c:\temp\ProgrammingInCSharp\Directory");

            var directoryInfo = new DirectoryInfo(@"c:\temp\ProgrammingInCSharp\DirectoryInfo");
            directoryInfo.Create();
        }
    }
}
