using System;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            //we have to write a program which, by given two numbers, that are between 1 and 12 (so to correspond to a particular month) prints the count of months between these months. The message that must be printed to the console must be "There is X months period from Y to Z.", where X is the count of the months, that we must calculate, and Y and Z, are respectively the names of the months that mark start and end of the period.

            Console.Write("Please enter the month to begin with: ");
            int beginMonth = Int32.Parse(Console.ReadLine());

            Console.Write("Please enter the month to end with: ");
            int endMonth = Int32.Parse(Console.ReadLine());

            MonthDifference(beginMonth, endMonth);

        }

        public static void MonthDifference(int month1, int month2)
        {
            int period;
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            if (month1 < month2)
            {
                period = month2 - month1;
                Console.WriteLine($"There is {period} months between {months[month1 - 1]} and {months[month2 - 1]}");

            }
            else
            {

                period = month2 - month1 + 12;
                Console.WriteLine($"There is {period} months between {months[month1 - 1]} and {months[month2 - 1]}");
            }
        }
    }
}
