using System;
using System.Threading;
using System.Threading.Tasks;


namespace consoleAsync
{
    public class AsyncCoinManager
    {

        private string PretendToConnectToCoinService()
        {
            // Simulate a long-running network connection
            Thread.Sleep(5000);
            return "You've got 25 Asynccoin!";
        }

        private async Task<string> PretendToConnectToCoinServiceAsync()
        {
            await Task.Delay(5000);
            return "You've got 25 Asynccoin!";
        }

        public async Task AcquireAsyncCoinAsync()
        {
            Console.WriteLine($"Start call to long-running service at {DateTime.Now}");
            var result = await PretendToConnectToCoinServiceAsync();
            Console.WriteLine($"Finish call to long-running service at {DateTime.Now}");
            var savedColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"result: {result}");
            Console.ForegroundColor = savedColor;
        }


    }
}