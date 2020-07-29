using System;
using System.IO;

namespace _4._01_Drives
{
    class Program
    {
        static void Main(string[] args)
        {
            var drives = DriveInfo.GetDrives();

            foreach(var drive in drives)
            {
                Console.WriteLine("Drive {0}", drive.Name);
                Console.WriteLine("\tDrive type: {0}", drive.DriveType);

                if(drive.IsReady)
                {
                    Console.WriteLine("\tVolume label: {0}", drive.VolumeLabel);
                    Console.WriteLine("\tFile System: {0}", drive.DriveFormat);
                    Console.WriteLine("\tAvailable space to current user: {0, 15} bytes", drive.AvailableFreeSpace);
                    Console.WriteLine("\tTotal available space:           {0, 15} bytes", drive.TotalFreeSpace);
                    Console.WriteLine("\tTotal size of drive:             {0, 15} bytes", drive.TotalSize);
                }
            }

            Console.ReadLine();
        }
    }
}
