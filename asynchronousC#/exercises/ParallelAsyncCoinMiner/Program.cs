using System;

namespace ParallelAsyncCoinMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");
            var miningManager = new ParallelMiningManager();
            miningManager.Execute();
            Console.ReadKey();
        }
    }
}
