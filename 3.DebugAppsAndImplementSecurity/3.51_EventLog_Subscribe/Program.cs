using System;
using System.Diagnostics;

namespace _3._51_EventLog_Subscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog appLog = new EventLog("Application", ".", "testEventLogEvent");
            appLog.EntryWritten += (sender, e) => Console.WriteLine(e.Entry.Message);
            appLog.EnableRaisingEvents = true;
            appLog.WriteEntry("Test Message", EventLogEntryType.Information);
            Console.ReadKey();
        }
    }
}
