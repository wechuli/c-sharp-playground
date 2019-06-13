using System;

namespace ex9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a method that returns the position of the first occurrence of an element from an array, such that it is greater than its two neighbors simultaneously. Otherwise the result must be -1.
            int[] myArray = { 1, 2, 3, 4, 4, 4, 335, 68, 7, 53, 2, 78 };
            int value = 7;

            Console.WriteLine(ReturnFirstOccurence(myArray, value));

        }
        public static bool CheckNeighbors(int[] array, int position)
        {
            if ((array[position] > array[position - 2]) & (array[position] > array[position - 1]))
            {
                return true;
            }
            return false;
        }
        public static int ReturnFirstOccurence(int[] array, int value)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if ((array[i] == value) & (CheckNeighbors(array, i)))
                {
                    Console.WriteLine("Hmm");
                    return array[i];
                }

            }
            return -1;
        }
    }
}
