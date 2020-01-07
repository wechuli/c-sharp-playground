using System;
using System.Linq;

namespace grouping_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 9, 0, 10, 11, 12, 13 };
            int divisor = 5;

            var numberGroups =
                from number in numbers
                group number by number % divisor into numberGroup
                select new { Remainder = numberGroup.Key, Numbers = numberGroup };
            foreach (var group in numberGroups)
            {
                Console.WriteLine($"Numbers with a remainder of {group.Remainder} when divided by {divisor}");
                foreach (var number in group.Numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
