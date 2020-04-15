using System;
using System.Threading.Tasks;
using System.Net;





namespace TapCompliance
{

    class TapComplianceClass


    {

        private readonly WebClient client = new WebClient();
        public string SellSomeCoin(string authToken, int howMany, out int currentMarketPrice)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new Exception("Failed Authorization");
            }
            currentMarketPrice = new Random().Next(50, 120);
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/sellcoin/{howMany}");
            var webClient = new WebClient();
            var result = webClient.DownloadString(uri);
            return result;
        }

        public async Task<CoinInfo> SellSomeCoinAsync(string authToken, int howMany)
        {
            CoinInfo result = new CoinInfo();
            if (string.IsNullOrEmpty(authToken))
            {
                throw new Exception("Failed Authorization");
            }
            result.currentMarketPrice = new Random().Next(50, 120);

            Uri uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/sellcoin/{howMany}");
            var resultString = await client.DownloadStringTaskAsync(uri);
            result.resultString = resultString;


            return result;


        }
    }

    public struct CoinInfo
    {
        public int currentMarketPrice { get; set; }
        public string resultString { get; set; }
    }



}



