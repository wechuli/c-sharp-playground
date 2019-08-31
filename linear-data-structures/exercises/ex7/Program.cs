using System;
using System.Collections.Generic;
using System.Linq;

namespace ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds in a given array of integers (in the range [0…1000]) how many times each of them occurs.
            // Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
            // 2 -> 2 times
            // 3 -> 4 times
            // 4 -> 3 times



            var initialList = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var listGroups = initialList.GroupBy(i => i);

            foreach (var group in listGroups)
            {

                Console.WriteLine($"{group.Key} -> {group.Count()} times");
            }


        }
    }
}
