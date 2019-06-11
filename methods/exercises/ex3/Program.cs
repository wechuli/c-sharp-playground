using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            //    write a program that asks the user what time it is, by printing on the console "What time is it?". Then the user must enter two numbers – one for hours and one for minutes.
            Console.Write("Please enter the hours: ");
            int hour = Int32.Parse(Console.ReadLine());

            Console.Write("Please enter the minutes: ");
            int minute = Int32.Parse(Console.ReadLine());

            currentTime(hour, minute);


        }
        public static void currentTime(int hours, int minutes)
        {
            if (hours >= 24 || minutes >= 60 || hours < 0 || minutes < 0)
            {
                Console.WriteLine("Incorrect time");
            }
            else
            {
                Console.WriteLine($"The time is {hours}:{minutes} now");
            }
        }
    }
}
