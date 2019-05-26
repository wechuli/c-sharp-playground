using System;

namespace exercises2
{
    class Program
    {
        static void Main(string[] args)
        {
            //4.Write a program, which finds the maximal sequence of consecutive equal elements in an array. E.g.: {1, 1, 2, 3, 2, 2, 2, 1} -> {2, 2, 2}.
            int[] arr = { 1, 2, 3, 4, 4, 2, 1, 3, 2, 5, 2, 2, 2, 2, 2, 11, 11 };
            int count = 1, tempCount = 1, number = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    tempCount++;
                }
                else
                {
                    tempCount = 1;
                }

                if (tempCount > count)
                {
                    count = tempCount;
                    number = arr[i];
                }
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write("{0}, ", number);
            }

        }
    }
}
