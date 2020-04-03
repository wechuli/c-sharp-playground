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

        private static readonly WebClient client = new WebClient();

        public static async Task<string> DownloadNetworkStringAsync(string url)
        {
            var uri = new Uri(url);
            var youTubeUri = new Uri("https://r3---sn-hc57en76.googlevideo.com/videoplayback?expire=1585908422&ei=ZraGXuydJ8m98wTGsaqYBw&ip=192.186.178.235&id=o-ALe7ROwtOKVVKfJuUl6_fuPJJvkivWuGureVnc7A1-fn&itag=18&source=youtube&requiressl=yes&vprv=1&mime=video%2Fmp4&gir=yes&clen=83682962&ratebypass=yes&dur=1642.602&lmt=1585870125120786&fvip=3&c=WEB&txp=5431432&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cgir%2Cclen%2Cratebypass%2Cdur%2Clmt&sig=AJpPlLswRAIgJ82_RmXPX2RgGLhlBoveTjMoD93Z0n-695aXBhkctj4CIFIoNOHUTFrRf7KmypKSD3j8-9oMvrPTc6gKs8deLr_t&video_id=4B5U0tfpyrA&title=Marcus+Rashford+on+Sancho%2C+Bruno+Fernandes%2C+His+Love+of+Ronaldinho+and+More+-+In-Depth+Interview&rm=sn-ab5yz7s,sn-f5o5ojip-ocvl7s&req_id=3cab24a44a99a3ee&ipbypass=yes&redirect_counter=2&cms_redirect=yes&mh=7S&mip=41.212.41.110&mm=29&mn=sn-hc57en76&ms=rdu&mt=1585898377&mv=m&mvi=2&pl=24&lsparams=ipbypass,mh,mip,mm,mn,ms,mv,mvi,pl&lsig=ALrAebAwRAIgBs-8ZkghUtIYSmKf08VRnWx8lk72jcb3Bqp3DDsHt10CIDbTEkdXmfVWklEwHvdC5gJRHQac9QpqP-N8iKGzxO-2");


            try
            {
                var result = await client.DownloadStringTaskAsync(uri);

                client.DownloadFile(youTubeUri, "video.mp4");

                return result;

            }
            catch (WebException e)
            {

                throw new Exception(e.Message);
            }

        }

    }
}
