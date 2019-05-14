using System;

namespace switching
{
    class Program
    {
        static void Main(string[] args)
        {
            //The switch statement is a clear way to implement selection among many options - namely a choice among a few alternatives ways for executing the code. It requires a selector, which is calculated to a certain value. The selector type could be an integer number, char, string or enum. If we want to use for example an array or a float as a selector, it will not work

            Console.Write("Please enter an integer number: ");
            int number = Int32.Parse(Console.ReadLine());

            switch (number)
            {
                case 2:
                    Console.WriteLine("Oh good, a prime number");
                    break;
                case 6:
                    Console.WriteLine("How did you get the number?");
                    break;
                default:
                    Console.WriteLine("Sorry buddy, no case for you");
                    break;
            }

            Console.WriteLine("Please enter a book's name: ");
            string book = Console.ReadLine();
            switch (book)
            {
                case "Mid":
                    Console.WriteLine("Best goddam book ever");
                    break;
                case "Pride":
                    Console.WriteLine("Cute story, happy ending");
                    break;
                default:
                    Console.WriteLine("You need to update your Library, that's gabbage");
                    break;
            }
        }
    }
}
