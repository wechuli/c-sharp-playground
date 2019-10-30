using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 67, 1, 4354, 5, 4, -676 };
            Console.WriteLine(FindMaxElementInArray(numbers));
        }

        public static int FindMaxElementInArray(int[] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
