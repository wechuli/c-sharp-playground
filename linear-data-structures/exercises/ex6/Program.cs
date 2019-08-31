using System;
using System.Collections.Generic;
using System.Linq;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that removes from a given sequence all numbers that appear an odd count of times
            // Example: array = {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}

            var initialList = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var listGroups = initialList.GroupBy(i => i);

            foreach (var group in listGroups)
            {

                if (group.Count() % 2 != 0)
                {

                    initialList.RemoveAll(item => item == group.Key);

                }
            }
            Console.Write("{ ");
            foreach (var item in initialList)
            {
                Console.Write($"{item} ");
            }

            Console.Write("}");


        }
    }
}
