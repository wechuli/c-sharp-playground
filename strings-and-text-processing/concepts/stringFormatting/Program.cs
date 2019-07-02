using System;

namespace stringFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentdate = DateTime.Now;
            Console.WriteLine(currentdate);

            int[] test = { 1, 2, 3, 4, 5 };
            Console.WriteLine(test); // Prints the full name of the class

            string name = "Paul Wechuli";
            string task = "Introduction to C# book";
            string location = "Nairobi";

            string formattedText = string.Format("Today is {0:MM/dd/yyyy} and {1} is working on {2} in {3}.", currentdate, name, task, location);

            Console.WriteLine(formattedText);

        }
    }
}

