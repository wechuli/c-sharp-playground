using System;

namespace fib_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            long result = Fib(n);
            Console.WriteLine($"fib({n}) = {result}");
        }

        //In the below calculation, if we set the value of n = 100, the calculations would take so much time that no one would wait to see the result. The reason is that this implementation is extremely inefficient. Each recursive call leads to two more calls and each of these calls cases two more calls and so on. This will grow exponentially.
        static long Fib(int n)
        {
            if (n <= 2)
            {
                return 1;

            }
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
