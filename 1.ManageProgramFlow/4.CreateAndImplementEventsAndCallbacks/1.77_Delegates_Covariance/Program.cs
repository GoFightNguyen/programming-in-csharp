using System.IO;

namespace _1._77_Delegates_Covariance
{
    class Program
    {
        public delegate TextWriter CovarianceDel();

        public static StreamWriter MethodStream() { return null; }
        public static StringWriter MethodString() { return null; }

        static void Main(string[] args)
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }
    }
}
