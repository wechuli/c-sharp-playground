using System;

namespace ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a method that prints the digits of a given decimal number in a reversed order. For example 256, must be printed as 652.
            DigitReverser(9566842);
        }

        public static void DigitReverser(int digits)
        {
            //turn the digits into a string
            string sDigits = digits.ToString();
            //initialize an empty string you will use to store the reversed string
            string rDigits = "";
            // loop through the sDigits string
            for (int i = sDigits.Length - 1; i >= 0; i--)
            {
                rDigits += sDigits[i];
            }
            Console.WriteLine(rDigits);
        }
    }
}
