using System;

namespace ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given a sequence of positive integer numbers given as string of numbers separated by a space. Write a program, which calculates their sum. Example: "43 68 9 23 318"  461.
            Console.WriteLine(CalculateSumFromString("43 68 9 23 318"));
        }

        static int CalculateSumFromString(string numberString)
        {
            string[] stringArray;
            stringArray = numberString.Split(" ");
            int sum = 0;
            for (int i = 0; i < stringArray.Length; i++)
            {
                sum += int.Parse(stringArray[i]);
            }

            return sum;
        }
    }
}
