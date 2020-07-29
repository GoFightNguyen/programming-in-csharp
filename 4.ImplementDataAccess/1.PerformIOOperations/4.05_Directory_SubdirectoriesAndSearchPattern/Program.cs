using System;
using System.IO;

namespace _4._05_Directory_SubdirectoriesAndSearchPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryInfo = new DirectoryInfo(@"c:\Program Files");
            ListDirectories(directoryInfo, "*a*", 5, 0);
            Console.ReadLine();
        }

        private static void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel) return;

            string indent = new string('-', currentLevel);

            try
            {
                var subDirectories = directoryInfo.GetDirectories(searchPattern);
                foreach(var subDir in subDirectories)
                {
                    Console.WriteLine(indent + subDir.Name);
                    ListDirectories(subDir, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(indent + "Can't access: " + directoryInfo.Name);
                return;
            }
            catch(DirectoryNotFoundException)
            {
                //Folder might have been removed while iterating
                Console.WriteLine(indent + "Can't find: " + directoryInfo.Name);
                return;
            }
        }
    }
}
