using System;
using System.Collections.Generic;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a method that finds the longest subsequence of equal numbers in a given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly.
        }

        static List<int> FindLongestSubsequence(List<int> numberList)
        {
            int winnerIndex = 0;
            int winnerCount = 0;
            int currentIndex = 0;
            int currentIndexCount = 0;

            for (var i = 0; i < numberList.Count - 1; i++)
            {
                if (numberList[i] == numberList[i + 1])
                {
                    currentIndexCount++;
                }
            }
        }
    }
}
