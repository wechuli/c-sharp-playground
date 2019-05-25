using System;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Write a program, which creates an array of 20 elements of type integer and initializes each of the elements with a value equals to the index of the element multiplied by 5. Print the elements to the console.
            int[] myArray = new int[20];
            for (int i = 0; i < 20; i++)
            {
                myArray[i] = i * 5;

            }
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
            //2. Write a program, which reads two arrays from the console and checks whether they are equal (two arrays are equal when they are of equal length and all of their elements, which have the same index, are equal).
            int length;

            Console.Write("Please enter the length of the arrays");
            length = Int32.Parse(Console.ReadLine());
            int[] array1 = new int[length];
            int[] array2 = new int[length];

            Console.WriteLine("Please enter the values for array 1, click enter to move to the next element");
            for (var i = 0; i < length; i++)
            {
                array1[i] = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("Please enter the values for array 2, click enter to move to the next element");
            for (var i = 0; i < length; i++)
            {
                array2[i] = Int32.Parse(Console.ReadLine());
            }
            bool equal = checkEquality(array1, array2);
            if (equal)
            {
                Console.WriteLine("The two arrays you entered are equal");
            }
            else
            {
                Console.WriteLine("Sorry buddy, unequal arrays entered");
            }

            //3.Write a program, which compares two arrays of type char lexicographically (character by character) and checks, which one is first in the lexicographical order.
            char[] cArray1 = { 'x', 'w', 'w', 'x', 't', 'u' };
            char[] cArray2 = { 'x', 'w', 'w', 'x' };

            Console.WriteLine(checkLex(cArray1, cArray2));

        }
        static bool checkEquality(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        static char[] checkLex(char[] array1, char[] array2)
        {
            char[] shorter;
            if (array1.Length > array2.Length)
            {
                shorter = array2;
            }
            else if (array2.Length > array1.Length)
            {
                shorter = array1;
            }
            else
            {
                shorter = array1;
            }

            for (int i = 0; i < shorter.Length; i++)
            {
                if (array1[i] > array2[i])
                {
                    return array2;
                }
                else if (array1[i] < array2[i])
                {
                    return array1;
                }
                else
                {
                    continue;
                }
            }


            return shorter;
        }
    }
}
