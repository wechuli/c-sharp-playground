using System;
using System.Linq;
using System.Collections.Generic;


namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            // The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program that finds the majorant of given array and prints it. If it does not exist, print "The majorant does not exist!".
            //Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            List<int> numbers2 = new List<int>() { 2, 2, 3, 8, 2, 3, 4, 3, 4 };

            FindMajorant(numbers);
            FindMajorant(numbers2);
        }
        static void FindMajorant(List<int> numbers)
        {


            var listGroups = numbers.GroupBy(i => i);
            int majorant = 0;
            bool majorantExists = false;

            foreach (var group in listGroups)
            {

                if (group.Count() > (numbers.Count / 2))
                {
                    majorant = group.Key;
                    majorantExists = true;
                    break;
                }


            }

            if (majorantExists)
            {
                Console.WriteLine($"The majorant is {majorant}");
            }
            else
            {
                Console.WriteLine("The majorant does not exist!");
            }
        }
    }
}
