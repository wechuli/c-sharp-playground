using System;
using System.Numerics;

namespace exercises2
{
    class Program
    {
        static BigInteger factorial(int number)
        {
            BigInteger results = 1;
            for (int i = number; i > 0; i--)
            {
                results *= i;
            }
            return results;
        }
        static void Main(string[] args)
        {
            // 6. Write a program that calculates N!/K! for given N and K (1<K<N).
            int N = 3;
            int K = 5;
            BigInteger resultsN = 1;
            BigInteger resultsK = 1;
            for (int i = N; i > 0; i--)
            {
                resultsN *= i;
            }
            for (int i = K; i > 0; i--)
            {
                resultsK *= i;
            }

            BigInteger results = resultsN / resultsK;
            Console.WriteLine(results);
            BigInteger results2 = 1;
            BigInteger diff = (N - K) + 1;
            for (int i = N; i > K; i--)
            {
                results2 *= i;
            }
            Console.WriteLine(results2);

            //            Write a program that calculates N!*K!/(N-K)! for given N and K
            // (1<K<N).
            BigInteger nFactorial = 1;
            BigInteger kFactorial = 1;
            BigInteger nkSub = 1;
            for (int i = N; i > 0; i--)
            {
                nFactorial *= i;
            }
            for (int i = K; i > 0; i--)
            {
                kFactorial *= i;
            }
            for (int i = N - K; i > 0; i--)
            {
                nkSub *= i;
            }

            BigInteger results3 = (nFactorial * kFactorial) / nkSub;
            Console.WriteLine(results3);

            //8.
            BigInteger catalan = factorial(2 * N) / (factorial(N + 1) * factorial(N));

            Console.WriteLine(catalan);
            Console.WriteLine(factorial(3));

            //9.Write a program that for a given integers n and x, calculates the sum:
            double x = 3;
            Math.Pow(4, 2);
            BigInteger expo = 1;
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"I was reached {i}");
                expo += ((factorial(i) / (BigInteger)Math.Pow(x, i)));
            }
            Console.WriteLine(expo);
        }
    }
}
