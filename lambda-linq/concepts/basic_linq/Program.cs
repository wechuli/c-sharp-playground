using System;
using System.Linq;
using System.Collections.Generic;

namespace basic_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // specify the data source
            int[] scores = new int[] { 97, 92, 81, 60 };
            

            //Define the query expression
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80 && score < 95
                select score;

            // Execute the query
            foreach (int i in scoreQuery)
            {
                Console.WriteLine(i);
            }

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var evenNumbers =
                from num in numbers
                where num % 2 == 0
                select num;

            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item + " ");
            }

        }
    }


}
