using System;
using System.Numerics;

namespace nested_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nested loops are programming constructs consisting of several loops located into each other. The innermost loop is executed more times, and the outermost - less times.

            //After initialization of the first for loop, the execution of its body will start which contains the second (nested) loop. Its variable will be initialized, its condition will be checked and the code within its body will be executed, then the variable will be updated and the execution of thhe first for loop will continue, its variable will be updated and the whole second loop will be performed once again. The inner loop will be fully executed as many times as the body of the outer loop
            Console.WriteLine("Please input n: ");

            int n = Int32.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write($"{col} ");
                }
                Console.WriteLine();
            }

            //Prime Numbers in an Interval

            Console.Write("n = ");
            int no = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());
            for (int num = no; num <= m; num++)
            {
                bool prime = true;
                int divider = 2;
                int maxDivider = (int)Math.Sqrt(num);
                while (divider <= maxDivider)
                {
                    if (num % divider == 0)
                    {
                        prime = false;
                        break;
                    }
                    divider++;
                }
                if (prime)
                {
                    Console.Write(" " + num);
                }
            }

            //Lottery 6/49 -Example

            BigInteger counter = 0;
            for (int i1 = 1; i1 <= 44; i1++)
            {
                for (int i2 = i1 + 1; i2 <= 45; i2++)
                {
                    for (int i3 = i2 + 1; i3 <= 46; i3++)
                    {
                        for (int i4 = i3 + 1; i4 <= 47; i4++)
                        {
                            for (int i5 = i4 + 1; i5 <= 48; i5++)
                            {
                                for (int i6 = i5 + 1; i6 <= 49; i6++)
                                {
                                    // Console.WriteLine(i1 + " " + i2 + " " +
                                    // i3 + " " + i4 + " " + i5 + " " + i6);
                                    counter += 1;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"The number of combinations is {counter}");
        }
    }
}
