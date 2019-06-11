using System;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //write a program that for a given (by the user) body temperature, measured in Fahrenheit degrees, has to convert that temperature and output it in Celsius degrees, with the following message: "Your body temperature in Celsius degrees is X", where X is respectively the Celsius degrees
            Console.Write("Please enter the temprature in fahrenheit: ");
            double fahrenheit = Double.Parse(Console.ReadLine());
            double degrees = FahrToDegress(fahrenheit);
            Console.WriteLine($"Your body temperature in Celsius degrees is {degrees}");
            if (degrees > 37)
            {
                Console.WriteLine("You are ill");
            }
            else
            {
                Console.WriteLine("You are fine");
            }


        }

        public static double FahrToDegress(double fahrenheit)
        {
            Console.WriteLine(fahrenheit);
            double results = (fahrenheit - 32) * (5.0 / 9.0);//Be careful when doing division with integers, 5/9 will be 0, but 5.0/9.0 return a double
            return results;
        }
    }
}
