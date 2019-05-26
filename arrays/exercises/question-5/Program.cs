using System;

namespace question_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //5.Write a program, which finds the maximal sequence of consecutively placed increasing integers. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
            int[] array = { 3, 2, 3, 4, 2, 4 };
            int index = 0;
            int tempCount = 1;
            int count = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    tempCount++;
                }
                if (array[i] > array[i + 1] || array[i] == array[i + 1])
                {
                    tempCount = 1;
                }
                if (tempCount > count)
                {
                    count = tempCount;
                    index = i + 1;
                }
            }
            for (int i = index + 1 - count; i < index + 1; i++)
            {
                Console.Write($"{array[i]} ");
            }


        }
    }
}
