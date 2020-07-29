using System;
using System.Threading.Tasks;

namespace _1._13_Tasks_TaskFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = Task.Run(() =>
            {
                var results = new int[3];

                var factory = new TaskFactory(TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);
                factory.StartNew(() => results[0] = 0);
                factory.StartNew(() => results[1] = 1);
                factory.StartNew(() => results[2] = 2);

                return results;
            });

            var final = parent.ContinueWith(parentTask =>
            {
                foreach (var i in parentTask.Result)
                    Console.WriteLine(i);
                Console.ReadLine();
            });

            final.Wait();
        }
    }
}
