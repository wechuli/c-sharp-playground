using System;
using System.Numerics;

namespace ex12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates and prints the n! for any n in the range [1…100].

            Console.WriteLine(GetFactorial(50));

        }
        public static BigInteger GetFactorial(BigInteger number)
        {
            if (number < 1)
            {
                return 1;
            }
            return number * GetFactorial(number - 1);
        }
    }
}
