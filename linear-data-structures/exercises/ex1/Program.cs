using System;
using System.Collections.Generic;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. Calculate and print the sum and the average of the sequence. Keep the sequence in List<int>.


            Console.WriteLine("Please enter a sequence of numbers and I will get the sum. Enter an empty line when done: ");
            List<long> numbers = new List<long>();
            string enteredText;
            long sum = 0;

            while (true)
            {
                enteredText = Console.ReadLine();
                if (enteredText == "")
                {
                    break;
                }
                try
                {
                    numbers.Add(long.Parse(enteredText));
                }
                catch (Exception e)
                {

                    throw new ArgumentException("Only numbers are allowed", e);
                }
            }

            foreach (var item in numbers)
            {
                sum += item;
            }

            Console.WriteLine($"The total sum is {sum}");
        }
    }
}
