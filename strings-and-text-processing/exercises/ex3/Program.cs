using System;
using System.Text.RegularExpressions;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that checks whether the parentheses are placed correctly in an arithmetic expression. Example of expression with correctly placed brackets: ((a+b)/5-d). Example of an incorrect expression: )(a+b)).
            Console.Write("Enter the equation: ");
            string input = Console.ReadLine();
            char[] inputArr = input.ToCharArray();

            int counter = 0;
            foreach (var itemChar in inputArr)
            {
                if (itemChar == '(')
                {
                    counter++;
                }
                if (itemChar == ')')
                {
                    counter--;
                }
                if (counter < 0)
                {
                    break;
                }

            }

            if (counter == 0)
            {
                Console.WriteLine("Correct equation");
            }
            else
            {
                Console.WriteLine("Wrong bracker placement");
            }

        }
    }
}
