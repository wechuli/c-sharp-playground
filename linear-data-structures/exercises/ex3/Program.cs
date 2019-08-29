using System;
using System.Collections.Generic;

namespace ex3
{
    class Program
    {

        // Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when an empty line is entered. Print the sequence sorted in ascending order.
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sequence of numbers and I will sort them in ascending order. Enter an empty line when done");

            List<long> numbers = new List<long>();
            string enteredText;


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

            numbers.Sort();
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }


        }
    }
}
