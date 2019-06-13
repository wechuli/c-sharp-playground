using System;
using System.Numerics;

namespace ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a method that finds the biggest element of an array. Use that method to implement sorting in descending order.
            int[] myNumbers = { 1, 2, 3, 4, 5 };
            int[] sortedNumbers = SortingNumbers(myNumbers);
            foreach (var item in sortedNumbers)
            {
                Console.WriteLine(item);
            }

        }
        public static int[] SortingNumbers(int[] numberArray)
        {
            //loop through the array switching the numbers
            int currentNumber = numberArray[0];
            int nextNumber;
            for (int i = 0; i < numberArray.Length - 1; i++)
            {
                if (currentNumber < numberArray[i + 1])
                {
                    numberArray[i + 1] = currentNumber;
                    numberArray[i] = numberArray[i + 1];                    

                }

            }

            return numberArray;
        }
    }
}
