using System.IO;

namespace _4._03_Directory_Delete
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(@"c:\temp\ProgrammingInCSharp\Directory"))
                Directory.Delete(@"c:\temp\ProgrammingInCSharp\Directory");

            var directoryInfo = new DirectoryInfo(@"c:\temp\ProgrammingInCSharp\DirectoryInfo");
            if (directoryInfo.Exists)
                directoryInfo.Delete();
        }
    }
}
