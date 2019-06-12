using System;

namespace ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 1, 2, 2, 3, 3, 2, 2, 2, 1, 3, 4, 34, 3, 23, 2, 2, 2, 2, 2 };
            int searchNumber = 2;
            Console.WriteLine(NumberInArray(myArray, searchNumber));
        }
        public static int NumberInArray(int[] array, int number)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    count += 1;
                }

            }
            return count;
        }
    }
}
