using System;
using System.Collections.Generic;

namespace union_intersect
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = new List<int>();

            firstList.Add(1);
            firstList.Add(2);
            firstList.Add(3);
            firstList.Add(4);
            firstList.Add(5);
            Console.Write("firstList = ");
            PrintList(firstList);

            List<int> secondList = new List<int>();
            secondList.Add(2);
            secondList.Add(4);
            secondList.Add(6);
            Console.Write("secondList = ");
            PrintList(secondList);


            List<int> unionList = Union(firstList, secondList);
            Console.Write("union = ");
            PrintList(unionList);


            List<int> intersectList = Intersect(firstList, secondList);
            Console.Write("intersect = ");
            PrintList(intersectList);
        }

        static List<int> Union(List<int> firstList, List<int> secondList)
        {
            List<int> union = new List<int>();
            union.AddRange(firstList);

            foreach (var item in secondList)
            {
                if (!union.Contains(item))
                {
                    union.Add(item);
                }
            }
            return union;
        }
        static List<int> Intersect(List<int> firstList, List<int> secondList)
        {
            List<int> intersect = new List<int>();

            foreach (var item in firstList)
            {
                if (secondList.Contains(item))
                {
                    intersect.Add(item);
                }
            }
            return intersect;
        }

        static void PrintList(List<int> list)
        {

            Console.Write("{ ");
            foreach (var item in list)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine("}");

        }
    }
}
