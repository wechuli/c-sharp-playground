using System;
using System.Collections.Generic;

namespace prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = GetPrimes(200, 400);
            foreach (var item in primes)
            {
                Console.WriteLine($"{item}");
            }
        }


        static List<int> GetPrimes(int start, int end)
        {
            List<int> primeList = new List<int>();

            for (int num = start; num <= end; num++)
            {
                bool prime = true;
                double numSqrt = Math.Sqrt(num);
                for (int div = 2; div <= numSqrt; div++)
                {
                    if (num % div == 0)
                    {
                        prime = false;
                        break;
                    }
                    if (prime)
                    {
                        primeList.Add(num);
                    }
                }
            }
            return primeList;
        }
    }
}
