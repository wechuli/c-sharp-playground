using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n= ");
            ulong number = ulong.Parse(Console.ReadLine());

            Console.WriteLine($"The factorial of {number} is {Factorial(number)}");
        }

        static ulong Factorial(ulong n)
        {
            //The botoom of the recursion
            if (n == 0)
            {
                return 1;
            }

            //Recursive call: the method calls itself
            return n * Factorial(n - 1);
        }
    }
}
