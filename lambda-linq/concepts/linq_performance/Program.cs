using System;
using System.Linq;
using System.Collections.Generic;

namespace linq_performance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            DateTime startTime = DateTime.Now;
            list1.AddRange(Enumerable.Range(1, 500000000));
            Console.WriteLine($"Ext.method: {DateTime.Now - startTime}");

            startTime = DateTime.Now;
            List<int> list2 = new List<int>();
            for (int i = 0; i < 500000000; i++)
            {
                list2.Add(i);
            }
            Console.WriteLine($"For-loop: {DateTime.Now - startTime}");
        }
    }
}
