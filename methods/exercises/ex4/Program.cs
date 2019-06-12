using System;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a method that sorts (puts in order) a set of values in ascending order. The result will be a string with the sorted numbers.

            int[] numbers = Sort(10, 3, 5, -1, 0, 12, 8);
            PrintNumbers(numbers);

        }

        public static int[] Sort(params int[] numbers)
        {
            //The sorting logic

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                //Loop that is operating over the un-sorted part of the array
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    //swapping the values
                    if (numbers[i] > numbers[j])
                    {
                        int oldNum = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = oldNum;

                    }
                }
            }
            return numbers;
        }
        public static void PrintNumbers(params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}");
                if (i < (numbers.Length - 1))
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
