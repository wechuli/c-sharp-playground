using System;

namespace ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number;
            Console.Write("Please enter a number: ");
            try
            {
                number = UInt32.Parse(Console.ReadLine());

                double squareroot = Math.Sqrt(number);
                Console.WriteLine($"The square root of {number} is {squareroot}");

            }
            catch (System.Exception se)
            {

                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }
    }
}
