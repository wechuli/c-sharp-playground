using System;

namespace fib_sequence2
{
    class Program
    {

        static long[] numbers;
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            numbers = new long[n + 2];
            numbers[1] = 1;
            numbers[2] = 1;

            long result = Fib(n);
            Console.WriteLine($"fib({n}) = {result}");
        }
        static long Fib(int n)
        {
            if (numbers[n] == 0)
            {
                numbers[n] = Fib(n - 1) + Fib(n - 2);
            }
            return numbers[n];
        }
    }
}
