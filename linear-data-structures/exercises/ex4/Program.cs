using System;
using System.Collections.Generic;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a method that finds the longest subsequence of equal numbers in a given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly.

            List<int> numberList = new List<int>() { 1, 1, 34, 54, 56, 56, 56 };
            var longestSequence = FindLongestSubsequence(numberList);
            foreach (var item in longestSequence)
            {
                Console.WriteLine(item);
            }
        }

        static List<int> FindLongestSubsequence(List<int> numberList)
        {
            int winnerLastIndex = 0;
            int winnerCount = 0;
            int currentIndexCount = 0;
            List<int> longestSequence = new List<int>();

            for (var i = 0; i < numberList.Count - 1; i++)
            {
                if (numberList[i] == numberList[i + 1])
                {
                    currentIndexCount++;

                }
                else
                {
                    currentIndexCount = 0;
                }
                if (currentIndexCount > winnerCount)
                {
                    winnerCount = currentIndexCount;
                    winnerLastIndex = i + 1;

                }

            }

            if (winnerCount == 0)
            {
                return longestSequence;
            }
            for (var i = winnerLastIndex - winnerCount; i <= winnerLastIndex; i++)
            {
                longestSequence.Add(numberList[i]);
            }
            return longestSequence;

        }
    }
}
