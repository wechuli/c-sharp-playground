using System;
using System.Threading.Tasks;
using AsyncCoinConsole;

namespace async_console_app
{
    class Program
    {


        static async Task Main(string[] args)
        {
            AsyncCoinManager coinManager = new AsyncCoinManager();
            var coinTask = coinManager.AcquireAsyncCoinAsync();
            Console.WriteLine("from main: I am not blocked");
            await coinTask;
            Console.ReadLine();
        }
    }
}
