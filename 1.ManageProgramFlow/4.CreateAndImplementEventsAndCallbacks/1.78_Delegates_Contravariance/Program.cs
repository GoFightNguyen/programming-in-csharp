using System.IO;

namespace _1._78_Delegates_Contravariance
{
    class Program
    {
        public delegate void ContravarianceDel(StreamWriter sw);
        static void DoSomething(TextWriter tw) { }

        static void Main(string[] args)
        {
            ContravarianceDel del;
            del = DoSomething;
        }
    }
}
