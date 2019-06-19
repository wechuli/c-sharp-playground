using System;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int mil = Environment.TickCount;
            Console.WriteLine($"Number of seconds: {mil / (1000.0)}");
            Console.WriteLine($"Number of minutes: {mil / (1000.0 * 60)}");
            Console.WriteLine($"Number of hours: {mil / (1000.0 * 60 * 60)}");
            Console.WriteLine($"Number of days: {mil / (1000.0 * 60 * 60 * 24)}");


        }
    }
}
