using System;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program, which generates and prints on the console 10 random numbers in the range [100, 200].
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rand.Next(100, 201));
            }

        }

    }
}
