using System;
using System.Collections.Generic;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program, which removes all negative numbers from a sequence
            var myunTouchedlist = new List<int>() { 19, -10, 12, -6, -3, 34, -2, 5 };
            var touchedList = RemoveAllNegativeNumbers(myunTouchedlist);
            foreach (var item in touchedList)
            {
                Console.WriteLine(item);
            }

        }

        static List<int> RemoveAllNegativeNumbers(List<int> list)
        {
            List<int> newList = new List<int>();
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] >= 0)
                {
                    newList.Add(list[i]);

                }
            }
            return newList;
        }
    }
}
