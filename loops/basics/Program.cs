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
        }
    }
}
