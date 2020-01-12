using System;
using System.Collections.Generic;
using System.Linq;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Implement the following extension methods for the classes, implementing the interface IEnumerable<T>: Sum(), Min(), Max(), Average().

            IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 45, 4, 34, 23, 55, 2, 0, 4 };
            Console.WriteLine(numbers.SumCustom());
            Console.WriteLine(numbers.AverageCustom());
            Console.WriteLine(numbers.MaxCustom());
            Console.WriteLine(numbers.MinCustom());


        }
    }

    public static class IEnumerableExtensionMethods
    {
        public static decimal SumCustom<T>(this IEnumerable<T> enumerable)
        {
            decimal totalSum = 0;
            foreach (T value in enumerable)
            {
                totalSum += Convert.ToDecimal(value);
            }
            return totalSum;

        }
        public static decimal AverageCustom<T>(this IEnumerable<T> enumerable)
        {

            return Math.Round(SumCustom(enumerable) / enumerable.Count(), 4);
        }
        public static T MinCustom<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
        {
            T min = enumerable.First();
            foreach (var value in enumerable)
            {
                if (min.CompareTo(value) < 0)
                {
                    min = value;
                }
            }
            return min;

        }

        public static T MaxCustom<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
        {
            T max = enumerable.First();
            foreach (T value in enumerable)
            {
                if (max.CompareTo(value) > 0)
                {
                    max = value;
                }
            }

            return max;

        }
    }
}
