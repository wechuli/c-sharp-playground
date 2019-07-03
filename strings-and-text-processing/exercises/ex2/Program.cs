using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. Write a program that reads a string, reverses it and prints it to the console.
            string stringToReverse = "introduction";
            Console.WriteLine(ReverseString(stringToReverse));
           

        }

        public static string ReverseString(string str)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
