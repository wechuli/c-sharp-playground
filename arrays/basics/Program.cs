﻿using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrays are collection of variables which we call elements
            //Arrays are numbered from 0 to N,those numbers are called indices. The total number of elements in agiven array we call length of an array
            //All elements of a given array are of the same type, no matter whether they are primitive or reference. This allows us to represent a group of similar elemnts as an ordered sequence and work on them as a whole. Arrays can be in different dimensions, but most used are the one dimensional and two-dimensional arrays. One dimensional arrays are called vectors and two dimensional are also known as matrices
            //In C#, the arrays have fixed length, which is set at the time of their instanctiation and determines the total number of elements. Once the length of an array is set, we cannot change it anymore

            int[] myArray;
            //When we declare an array type variable, it is a reference, which does not have a value(it points to null).This is because the memory of the elements is not allocated yet

            //we can create an array using the new keyword
            int[] myOtherArray = new int[6];
            Console.WriteLine(myOtherArray.Length);

            //setting the values
            int[] anotherOne = { 1, 2, 3, 4, 5, 6, 7 };

            string[] daysOfTheWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Sartuday", "Sunday" };
            Console.WriteLine(daysOfTheWeek);
            //In this case, we allocate an array of seven elements of type string. The type string is a refernve type(object) and its values are stored in the dynamic memory. The variable daysOfTheWeek is allocated in the stack memory, and points to a section of the dynamic memory containing the elemnts of the array. The type of each of these seven elements is string, which itself points to a different section of the dynamic memory, where the real value is stored


            // we access the array elements directly using their indices, we can change individual elements(but can't delete elemnts)
            daysOfTheWeek[0] = "Monday2";
            Console.WriteLine(daysOfTheWeek[0]);
            daysOfTheWeek[0] = "Monday";

            for (int i = 0; i < daysOfTheWeek.Length; i++)
            {
                Console.WriteLine(daysOfTheWeek[i]);
            }
            // Trying to access an element out of range will throw an error

            ArrayReverse();
            getSymmentricArrays();
            forEachLoop();
        }
        static void ArrayReverse()
        {
            //reversing the elements in an array
            int[] array = { 1, 2, 3, 4, 5 };
            //Get array size
            int length = array.Length;
            //Decalre and create the reversed array
            int[] reversed = new int[length];
            //Initialize the reversed array
            for (int index = 0; index < length; index++)
            {
                reversed[length - index - 1] = array[index];
            }

            //Print the reversed array
            for (int index = 0; index < length; index++)
            {
                Console.WriteLine(reversed[index] + "");
            }

        }
        static void getSymmentricArrays()
        {
            Console.Write("Enter a positive integer: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];


            Console.WriteLine("Enter the values of the array: ");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            bool symmetric = true;
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[n - i - 1])
                {
                    symmetric = false;
                    break;
                }
            }
            Console.WriteLine($"Is symmentric? {symmetric}");
        }
        static void forEachLoop()
        {
            string[] capitals = { "Sofia", "Washington", "London", "Paris", "Moscow", "Beijing", "Nairobi", "Kisumu", "Berlin" };
            foreach (var capital in capitals)
            {
                Console.WriteLine($"{capital}");
            }
        }
    }
}
