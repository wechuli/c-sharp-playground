using System;

namespace ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that solves the following tasks:
            // - Put the digits from an integer number into a reversed order.
            // - Calculate the average of given sequence of numbers.
            // - Solve the linear equation a * x + b = 0.
            // Create appropriate methods for each of the above tasks.
            // Make the program show a text menu to the user. By choosing an option of that menu, the user will be able to choose which task to be invoked.            
            // Perform validation of the input data:
            // - The integer number must be a positive in the range [1…50,000,000].
            // - The sequence of numbers cannot be empty.
            // - The coefficient a must be non-zero.
            Console.WriteLine("Welcome to the most amazing program on the planet !");
            Console.WriteLine("I have severalm things I can do for you, just choose the appropriate task and I'll be on my way: ");

            Console.WriteLine("Task 1: Put the digits from an integer into a reversed order");
            Console.WriteLine("Task 2: Calculate the average of given sequence of numbers.");
            Console.WriteLine("Task 3: Solve the linear equation a * x + b = 0.");
            Console.Write("Press 1 for task 1, Press 2 for task 2 and Press 3 for task 3");
            string pressedKeys = Console.ReadLine();
            if (Int32.Parse(pressedKeys) == 1)
            {
                Console.Write("Please provide the numbers you want reversed: ");
                int numbersToReverse = int.Parse(Console.ReadLine());
                Console.WriteLine($"The reversed numbers are {DigitReverser(numbersToReverse)}");
            }
            else if (Int32.Parse(pressedKeys) == 2)
            {
                Console.Write("Please provide a sequence of numbers: ");
                int numbersToAverage = int.Parse(Console.ReadLine());
                Console.WriteLine($"The average of the numbers is {CalculateAverage(numbersToAverage)}");

            }
            else if (Int32.Parse(pressedKeys) == 3)
            {
                Console.Write("Please enter the value of a: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Please enter the value of b: ");
                int b = int.Parse(Console.ReadLine());

                double x = SolveLinearEquation(a, b);
                Console.WriteLine($"The value of x is {x}, thus the equation is a * {x} + b = 0");
            }
            else
            {
                throw new Exception("Invalid option");
            }

        }

        public static int DigitReverser(int digits)
        {
            if (digits < 1 | digits > 50000000)
            {
                throw new Exception("Number should be between 1 and 50,000,000");

            }
            //turn the digits into a string
            string sDigits = digits.ToString();
            //initialize an empty string you will use to store the reversed string
            string rDigits = "";
            // loop through the sDigits string
            for (int i = sDigits.Length - 1; i >= 0; i--)
            {
                rDigits += sDigits[i];
            }
            return Int32.Parse(rDigits);
        }
        public static double CalculateAverage(params int[] digits)
        {
            int numberLength = 0;
            if (numberLength == 0)
            {
                throw new ArgumentException("Sequence cannot be empty");
            }
            int sum = 0;
            foreach (var item in digits)
            {
                sum += item;
                numberLength += 1;
            }

            return (sum / (double)numberLength);

        }
        public static double SolveLinearEquation(int a, int b)
        {
            if (a == 0 | b == 0)
            {
                throw new ArgumentException("The coefficients must be a positive number");

            }
            return (-b / (double)a);

        }
    }
}
