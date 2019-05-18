using System;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Write a program that prints on the console the numbers from 1 to N. The number N should be read from the standard input.
            Console.WriteLine("Please enter the number");
            int n = Int32.Parse(Console.ReadLine());
            // for (int i = 1; i <= n; i++)
            // {
            //     Console.WriteLine(i);
            // }

            //2.Write a program that prints on the console the numbers from 1 to N, which are not divisible by 3 and 7 simultaneously. The number N should be read from the standard input.

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 7 == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
            }

            //3.Write a program that reads from the console a series of integers and prints the smallest and largest of them.
            Console.WriteLine("Please enter a series of integers and separate them with a space");
            string numbers = Console.ReadLine();
            string[] split = numbers.Split(" ");
            int largest = int.MaxValue;
            int smallest = int.MinValue;
            foreach (var cha in split)
            {
                int number = Int32.Parse(cha);

                if (number > smallest)
                {
                    smallest = number;
                }
                if (number < largest)
                {
                    largest = number;
                }

            }
            Console.WriteLine($"The largest number is {largest} and the smallest is {smallest}");

            //4. Write a program that prints all possible cards from a standard deck of cards

            string[] cardType = { "Diamond", "Hearts", "Spades", "Clubs" };
            string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "K", "Q", "A" };
            int combinations = 0;
            foreach (var card in cards)
            {
                foreach (var type in cardType)
                {
                    Console.WriteLine($"{card} {type}");
                    combinations++;
                }
            }
            Console.WriteLine($"There are a total of {combinations} combinations in the deck");

            //Write a program that reads from the console number N and print the sum
            // of the first N members of the Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8,
            // 13, 21, 34, 55, 89, 144, 233, 377, …

            int size = 3;
            int previous1 = 0;
            int previous2 = 0;


            for (int i = 0; i < size; i++)
            {
                

            }


        }
    }
}
