using System;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method GetMax() with two integer (int) parameters, that returns maximal of the two numbers. Write a program that reads three numbers from the console and prints the biggest of them. Use the GetMax() method you just created. Write a test program that validates that the methods works correctly.
            Console.Write("Please enter the first number: ");
            int first = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter the second number: ");
            int second = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"The bigger number is {GetMax(first, second)}");


        }
        public static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            return second;

        }

    }
}
