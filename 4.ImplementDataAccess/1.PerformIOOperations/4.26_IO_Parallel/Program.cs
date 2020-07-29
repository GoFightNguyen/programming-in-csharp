using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace _4._26_IO_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            NotParallel();
            Parallel();
            Console.ReadLine();
        }

        private static async Task NotParallel()
        {
            HttpClient client = new HttpClient();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string microsoft = await client.GetStringAsync("http://www.microsoft.com");
            string msdn = await client.GetStringAsync("http://www.msdn.microsoft.com");
            string blogs = await client.GetStringAsync("http://www.blogs.msdn.com");
            stopWatch.Stop();

            Console.WriteLine("not parallel: {0}", stopWatch.Elapsed);
        }

        private static async Task Parallel()
        {
            HttpClient client = new HttpClient();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task microsoft = client.GetStringAsync("http://www.microsoft.com");
            Task msdn = client.GetStringAsync("http://www.msdn.microsoft.com");
            Task blogs = client.GetStringAsync("http://www.blogs.msdn.com");

            await Task.WhenAll(microsoft, msdn, blogs);

            stopWatch.Stop();
            Console.WriteLine("parallel: {0}", stopWatch.Elapsed);
        }
    }
}
