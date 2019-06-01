using System;

namespace question6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program, which reads from the console two integer numbers N and K (K<N) and array of N integers. Find those K consecutive elements in the array, which have maximal sum.

            int K = 2;
            int[] myArray = { 1, -1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int N = myArray.Length;
            int startIndex = 0;
            int currentSum = 0;
            int finalresultSum = 0;


            for (int i = 0; i < N - K; i++)
            {
                for (int n = i; n < i + K; n++)
                {
                    if (myArray[n] > myArray[n + 1])
                    {
                        // Console.WriteLine($"{myArray[n]} {myArray[n + 1]}");
                        break;
                    }
                    Console.WriteLine($"${myArray[n]} {myArray[n + 1]}");
                    currentSum += myArray[n];
                    Console.Write($"{currentSum }");
                    Console.WriteLine("End");

                }
                if (currentSum > finalresultSum)
                {
                    finalresultSum = currentSum;
                    // currentSum = 0;
                    startIndex = i;
                }


            }
            Console.WriteLine($"currentSum = {currentSum}");
            Console.WriteLine($"startIndex = {startIndex}");
            Console.WriteLine($"finalresultSum = {finalresultSum}");

        }
    }
}
