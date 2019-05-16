using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //A loop is a basic programming construct that allows repeated execution of a fragment of source code
            //The condition is any expression that returns a Boolean result - true or false


            //While loop
            int counter = 0;

            while (counter <= 9)
            {
                //Print the counter value
                Console.WriteLine($"Number: {counter}");
                counter++;
            }
            //sum number from 1 to n
            Console.Write("n= ");
            int n = Int32.Parse(Console.ReadLine());
            int num = 1;
            int sum = 1;

            Console.Write("The sum 1");
            while (num < n)
            {
                num++;
                sum += num;
                Console.Write($"+ {num}");
            }
            Console.WriteLine("=" + sum);

            //find if a number is a primenumber
            Console.Write("Enter a positive number: ");
            int numb = int.Parse(Console.ReadLine());
            int divider = 2;
            int maxDivider = (int)Math.Sqrt(numb);
            bool prime = true;
            while (prime && (divider <= maxDivider))
            {
                if (numb % divider == 0)
                {
                    prime = false;
                }
                divider++;
            }
            Console.WriteLine($"Prime? {prime}");

            //The break operator is used for prematurely exiting the loop, before it has completed its execution in a natural way.When the loop reaches the break operator, it is terminated and the program's execution continues from the line immediately after the loop's body.

            Console.WriteLine("Please insert te number");
            int nFact = int.Parse(Console.ReadLine());

            //decimal is the biggest C# type that can hold integer values

            decimal factorial = 1;
            //Perform an infinite loop
            while (true)
            {
                if (nFact <= 1)
                {
                    break;
                }
                factorial *= nFact;
                nFact--;
            }
            Console.WriteLine($"{nFact}! = {factorial}");
        }
    }
}
