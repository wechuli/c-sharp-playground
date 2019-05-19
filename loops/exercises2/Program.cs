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

            float expo = 1;
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"I was reached {i}");

                expo += (((float)factorial(i) / (float)Math.Pow(x, i)));
            }
            Console.WriteLine(expo);

            // //10.Write a program that reads from the console a positive integer number
            // N (N < 20) and prints a matrix of numbers as on the figures below:
            int Nlocal = 8;
            for (int i = 1; i <= Nlocal; i++)
            {


                for (int j = i; j < Nlocal + i; j++)
                {
                    Console.Write($"{j}|");
                }
                Console.WriteLine();
            }


            //Write a program that calculates with how many zeroes the factorial of
            // a given number ends. Examples:
            // N = 10 -> N! = 3628800 -> 2
            // N = 20 -> N! = 2432902008176640000 -> 4

            int anotherN = 20;
            int noOfZeros = 0;
            BigInteger result4 = factorial(anotherN);

            while (result4 % 10 == 0)
            {
                result4 /= 10;
                noOfZeros++;

            }
            Console.WriteLine($"The factorial of {anotherN} has {noOfZeros} 0s");


            // Write a program that converts a given number from decimal to binary
            // notation (numeral system).
            BigInteger number = 895565565455;
            BigInteger remainder = 0;
            BigInteger quotient = 0;
            string binary = "";



            while (true)
            {
                quotient = number / 2;
                remainder = number % 2;

                number = quotient;
                // Console.Write(remainder);
                binary = remainder.ToString() + binary;
                // binary = String.Concat(binary, remainder);

                if (quotient == 1 && (remainder == 0 || remainder == 1))
                {

                    // Console.Write(quotient);
                    // Console.Write(0);
                    binary = "0" + quotient.ToString() + binary;
                    break;
                }

            }
            Console.WriteLine(binary);

        }
    }
}
