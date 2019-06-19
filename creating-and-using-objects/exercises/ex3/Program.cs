using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program, which prints, on the console which day of the week is today.
            DateTime date = DateTime.UtcNow;
            DayOfWeek day = new DayOfWeek();
            Console.WriteLine(day);
            Console.WriteLine(date);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}
