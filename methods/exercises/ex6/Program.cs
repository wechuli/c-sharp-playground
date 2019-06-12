using System;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(returnLastLetter(1234432479));




        }
        public static string returnLastLetter(int numbers)
        {
            string[] numberNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string numToString = numbers.ToString();
            int lastNumberIndex = Int32.Parse(numToString.Substring(numToString.Length - 1));
            return numberNames[lastNumberIndex];

        }

    }
}
