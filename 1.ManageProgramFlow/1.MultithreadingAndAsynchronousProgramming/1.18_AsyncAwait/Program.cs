using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _1._18_AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //if i could make this method async, then we would use var result = await DownloadContent();

            var result = DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static async Task<string> DownloadContent()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}
