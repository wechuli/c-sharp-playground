using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace simple_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var fileUri = new Uri("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");
            string fileName = "data.json";

            client.DownloadFile(fileUri, fileName);

        }
    }

}
