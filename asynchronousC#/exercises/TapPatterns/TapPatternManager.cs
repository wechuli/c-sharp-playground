using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace TapPatterns
{
    public class TapPatternManager
    {

        #region launch methods

        public void Launch()
        {

        }

        public async Task LaunchAsync()
        {

        }

        #endregion


        #region Task 2 - introduction


        #endregion

        #region base methods

        private string CallCoinService(int howMany)
        {
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/asynccoin/{howMany}");
            var webClient = new WebClient();
            var result = webClient.DownloadString(uri);
            return result;
        }

        private async Task<string> CallCoinServiceAsync(int howMany)
        {
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/asynccoin/{howMany}");
            var webClient = new WebClient();
            var result = await webClient.DownloadStringTaskAsync(uri);
            return result;
        }

        private async Task CallCoinServiceNoResponseAsync(int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                await Task.Delay(1000);
            }
        }

        private double MineAsyncCoinsWithNthRoot(int iterationMultiplier)
        {
            double allCoins = 0;
            for (int i = 1; i < iterationMultiplier * 2500; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Math.Pow(i, 1.0 / j);
                    allCoins += .000001;
                }
            }
            return allCoins;
        
        }

        private bool AuthorizeTheToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }

        #endregion

    }
}