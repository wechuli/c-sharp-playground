using System;

namespace tri_with_diff
{
    class Program
    {
        static void Main(string[] args)

        {
            FancyTriangle();
        }

        public static void FancyTriangle()
        {
            Console.WriteLine("Please enter the size of the triangle");
            int triSize = Int32.Parse(Console.ReadLine());

            for (int i = 0; i <= triSize; i++)
            {
                for (int m = 1; m <= i; m++)
                {
                    Console.Write($"{m} ");
                    if (m == triSize)
                    {
                        for (int z = 0; z < triSize - 1; z++)
                        {
                            Console.Write($"{m} ");
                        }
                    }
                }
                Console.WriteLine();
                if (i == triSize)
                {
                    for (int n = triSize; n >= 1; n--)
                    {
                        for (int j = 1; j < n; j++)
                        {
                            Console.Write($"{j} ");
                        }
                        Console.WriteLine();
                    }

                }
            }
        }
    }
}
