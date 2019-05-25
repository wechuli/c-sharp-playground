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
        }
    }
}
