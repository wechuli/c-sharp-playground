using System;
using System.Collections.Generic;
using System.Text;
namespace extension_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string helloString = "Hello, Extension Methods!";
            int wordCount = helloString.WordCount();
            Console.WriteLine(wordCount);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.ToString<int>());
            numbers.IncreaseWith(5);
            Console.WriteLine(numbers.ToString<int>());
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


    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this IEnumerable<T> enumaration)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");
            foreach (var item in enumaration)
            {
                result.Append(item.ToString());
                result.Append(", ");
            }
            if (result.Length > 1)
            {
                result.Remove(result.Length - 2, 2);
            }
            result.Append("]");
            return result.ToString();

        }
    }
}
