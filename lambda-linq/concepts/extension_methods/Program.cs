using System;
using System.Collections.Generic;
namespace extension_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string helloString = "Hello, Extension Methods!";
            int wordCount = helloString.WordCount();
            Console.WriteLine(wordCount);
        }
    }


    // Extension method for classes
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {

            return str.Split(new char[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    // Extension method for interace

    public static class IListExtensions
    {
        public static void IncreaseWith(this IList<int> list, int amount)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += amount;
            }
        }
    }
}
