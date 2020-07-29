using System;
using System.Diagnostics;

namespace _3._47_TraceListener_Configure
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleTraceListener listener = new ConsoleTraceListener();
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.Listeners.Clear();
            traceSource.Listeners.Add(listener);
            traceSource.TraceInformation("Trace Output");

            traceSource.Flush();
            traceSource.Close();
            Console.ReadLine();
        }
    }
}
