using System;
using System.Threading.Tasks;

namespace _1._12_Tasks_ChildTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = Task.Run(() =>
            {
                var results = new int[3];

                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

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
