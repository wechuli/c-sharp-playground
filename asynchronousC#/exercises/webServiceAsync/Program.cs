using System;
using System.Threading.Tasks;
using System.Net;

namespace webServiceAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/todos";
            string downloadedString = await WebServicesClient.DownloadNetworkStringAsync(url);
            Console.WriteLine(downloadedString);
        }
    }

    public static class WebServicesClient
    {

        public static async Task<string> DownloadNetworkStringAsync(string url)
        {
            var uri = new Uri(url);
            var webClient = new WebClient();
            var result = await webClient.DownloadStringTaskAsync(uri);

            return result;
        }

    }
}
