using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelAsyncCoinMiner
{
    public class ParallelMiningManager
    {
        public void Execute()
        {
            Console.WriteLine($"Started mining at {DateTime.UtcNow}");
            Console.WriteLine($"Primary Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            //MineWithParallelInvoke();
            //MineWithForLoop();
            MineWithParallelForLoop();

            Console.WriteLine($"Finished mining at {DateTime.UtcNow}");

        }

        public void MineAsyncCoinsWithPrimes(int howMany)
        {
            double allCoins = 0;
            for (int x = 2; x < howMany * 50000; x++)
            {
                int primeCounter = 0;
                for (int y = 1; y < x; y++)
                {
                    if (x % y == 0)
                    {
                        primeCounter++;
                    }

                    if (primeCounter == 2) break;
                }
                if (primeCounter != 2)
                {
                    allCoins += .01;
                }

                primeCounter = 0;
            }
            Console.WriteLine($"Found {allCoins} Async Coin with primes");
            Console.WriteLine($" Worker Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void MineAsyncCoinsWithNthRoot(int howMany)
        {
            double allCoins = 0;
            for (int i = 1; i < howMany * 2500; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Math.Pow(i, 1.0 / j);
                    allCoins += .00001;
                }
            }
            Console.WriteLine($"Found {allCoins} Async Coin with roots");
            Console.WriteLine($" Worker Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void MineWithParallelInvoke()
        {
            Action mineWithRoots = () => MineAsyncCoinsWithNthRoot(2);
            Action mineWithPrimes = () => MineAsyncCoinsWithPrimes(3);
            Action mineWithRoots2 = () => MineAsyncCoinsWithNthRoot(3);
            Action mineWithPrimes2 = () => MineAsyncCoinsWithPrimes(2);

            Parallel.Invoke(mineWithRoots, mineWithPrimes, mineWithRoots2, mineWithPrimes2);
        }


        // normal loop
        public void MineWithForLoop()
        {
            for (var i = 0; i < 5; i++)
            {
                MineAsyncCoinsWithPrimes(i);
            }
        }


        // parallel loop
        public void MineWithParallelForLoop()
        {
            Parallel.For(0, 5, i => MineAsyncCoinsWithPrimes(i));


        }

        public void MineWithAdvancedParallelForLoop()
        {
            int totalSeconds = 0;

            var result = Parallel.For<int>(0, 5,
                () => 0,
                (i, loop, subtotal) =>
                {
                    var startDate = DateTime.UtcNow;
                    MineAsyncCoinsWithPrimes(i);
                    var subtotalSeconds = (DateTime.UtcNow - startDate).Seconds;
                    Console.WriteLine($"Processed for {subtotalSeconds} seconds");
                    subtotal += subtotalSeconds;
                    return subtotal;
                },
                (x) => Interlocked.Add(ref totalSeconds, x)
                );

            Console.WriteLine($"Total number of seconds spent processing was {totalSeconds}");
        }

        public void MineWithForEachLoop()
        {
            var numberArray = new int[] { 3, 2, 4, 1, 2 };

            foreach (var num in numberArray)
            {
                MineAsyncCoinsWithNthRoot(num);
            }
        }

        public void MineWithParallelForEachLoop()
        {
            var numberArray = new int[] { 3, 2, 4, 1, 2 };

            Parallel.ForEach(numberArray, num => MineAsyncCoinsWithNthRoot(num));
        }
    }
}