using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;



namespace async_test
{
    class TestClass
    {
        public async Task<int> AccessTheWebAsync()
        {

            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("https://twitter.com/");

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Some random number {i}");
            }
            string urlContents = await getStringTask;

            return urlContents.Length;

        }

    }

}