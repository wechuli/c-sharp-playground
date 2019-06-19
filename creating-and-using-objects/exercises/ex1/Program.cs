using System;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Write a program, which reads from the console a year and checks if it is a leap year.
            Console.Write("Please specify the year: ");
            int year = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Leap year: {CheckLeapYear(year)}");

        }

        public static bool CheckLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }
    }
}
