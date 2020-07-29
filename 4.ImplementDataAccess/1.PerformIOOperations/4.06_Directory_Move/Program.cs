using System.IO;

namespace _4._06_Directory_Move
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.Move(@"c:\source", @"c:\destination");

            var directoryInfo = new DirectoryInfo(@"c:\source");
            directoryInfo.MoveTo(@"c:\destination");
        }
    }
}
