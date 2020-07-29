using System.IO;
using System.Security.AccessControl;

namespace _4._04_Directory_AccessControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryInfo = new DirectoryInfo("TestDirectory");
            directoryInfo.Create();
            var directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}
