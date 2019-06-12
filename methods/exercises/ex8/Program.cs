using System;

namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a method that checks whether an element, from a certain position in an array is greater than its two neighbors. Test whether the method works correctly.
            int[] myArray = { 1, 2, 3, 4, 4, 4, 335, 68, 7, 53, 2, 78 };
            int position = 6;
            Console.WriteLine(CheckNeighbors(myArray, position));
        }
        public static bool CheckNeighbors(int[] array, int position)
        {
            if (array[position] > array[position + 1] & array[position] > array[position - 1])
            {
                return true;
            }
            return false;
        }
    }
}
