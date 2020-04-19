using System;
using static System.Console;


namespace ContactWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting");
            Contact sarah = new Contact { FirstName = "Sarah", AgeInYears = 42 };
            ContactConsoleWriter sarahWriter = new ContactConsoleWriter(sarah);
            sarahWriter.Write();

            WriteLine("\n\n Hit enter to exit....");
            ReadLine();
        }
    }
}
