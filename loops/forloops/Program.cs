using System;
using System.Numerics;

namespace forloops
{
    class Program
    {
        static void Main(string[] args)
        {
            //For loops contain an initialization(A), the condition(B), the body(D) and the updating commands
            //The numner of iterations of a given for-loop is usually known before its execution start

            //loop from 1 to 10

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"The number is {i}");
            }

            //looping through two variables

            for (int i = 1, sum = 1; i <= 128; i *= 2, sum += i)
            {
                Console.WriteLine($"i={i},sum={sum}");
            }

            //Write a program that raises the number n to a power of m using a for loop
            Console.Write("Plese insert m");
            int m = Int32.Parse(Console.ReadLine());
            Console.Write("Please insert n");
            int n = Int32.Parse(Console.ReadLine());


            for (BigInteger number = 1, product = m; number <= n; number++, product *= m)
            {
                Console.WriteLine($"{number},{product}");
            }

            //We can have the counters moving in different directions
            for (int small = 1, large = 10; small < large; small++, large--)
            {
                Console.WriteLine(small + " " + large);
            }

            //the continue operator stops the current iteration of the inner loop without terminating the loop
            //e.g We will calculate the sum of all odd integers in the range [1…n], which are not divisible by 7 by using the for-loop:

            BigInteger ng7 = 99038393;
            BigInteger sum7 = 0;
            for (int i = 1; i <= ng7; i += 2)
            {
                if (i % 7 == 0)
                {
                    continue;
                }
                sum7 += i;
            }
            Console.WriteLine($"Sum = {sum7}");
        }
    }
}
