using System;

namespace ex12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads a number from console and prints it in 15-character field, aligned right in several ways: as a decimal number, hexadecimal number, percentage, currency and exponential (scientific) notation.
            Console.Write("Please input your number: ");
            int number = 0;
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine("Incorrect value. Please input a number");
            }

            Console.WriteLine(String.Format("{0:d15}", number));
            Console.WriteLine(String.Format("{0:x15}", number));
            Console.WriteLine(String.Format("{0:P15}", number));
            Console.WriteLine(String.Format("{0:C15}", number));
            Console.WriteLine(String.Format("{0:0.##E+00}", number));
        }
    }
}
