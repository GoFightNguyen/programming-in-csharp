using System;
using System.Security;
using System.Security.Permissions;

namespace _3._25_3._26_CodeAccessSecurity
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        static void DeclarativeCAS()
        {

        }

        static void ImperativeCAS()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
