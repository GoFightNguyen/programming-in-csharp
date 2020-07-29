using System;
using System.Diagnostics;

namespace _3._49_EventLog_Write
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("Created Event Source");
                Console.WriteLine("Restart application");
                Console.ReadKey();
                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "MySource";
            myLog.WriteEntry("Log event!");
        }
    }
}
