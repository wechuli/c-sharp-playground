using System;
using System.Linq;

namespace sorting_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "cherry", "apple", "blueberry", "maple", "tomatoes", "eggs", "carrots", "sugar" };
            var wordsSortedBylength =
                from word in words
                orderby word.Length descending
                select word;

            foreach (var word in wordsSortedBylength)
            {
                Console.WriteLine(word);
            }
        }
    }
}
