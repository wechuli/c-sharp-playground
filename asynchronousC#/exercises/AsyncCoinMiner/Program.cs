using System;

namespace AsyncCoinMiner
{
    class Program
    {
        static void Main(string[] args)
        {

            // Console.ForegroundColor = "green";
            Console.WriteLine("Begin");
            var miningManager = new AsyncCoinMiningManager();
            miningManager.Execute();

        }
    }
}
