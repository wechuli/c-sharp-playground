using System;
using System.Collections.Generic;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program, which reads from the console N integers and prints them in reversed order. Use the Stack<int> class.


            Console.WriteLine("Please enter a sequence of numbers and I will print them in reverse. Enter an empty line when done: ");

            Stack<int> numbers = new Stack<int>();
            
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
                    numbers.Push(Int32.Parse(enteredText));
                }
                catch (Exception e)
                {

                    throw new ArgumentException("Only numbers are allowed", e);
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }


        }
    }
}
