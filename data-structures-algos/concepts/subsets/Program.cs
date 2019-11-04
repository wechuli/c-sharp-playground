using System;
using System.Collections.Generic;

namespace subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            // It is given a set of strings S. The tasks is to write a program, which prints all subsets of S
            string[] words = { "ocean", "beer", "money", "happiness" };
            Queue<HashSet<string>> subsetsQueue = new Queue<HashSet<string>>();

            HashSet<string> emptySet = new HashSet<string>();
            subsetsQueue.Enqueue(emptySet);
            while (subsetsQueue.Count > 0)
            {
                HashSet<string> subset = subsetsQueue.Dequeue();

                // Print current subset
                Console.Write("{ ");
                foreach (string word in subset)
                {
                    Console.Write("{0} ", word);
                }
                Console.WriteLine("}");

                // Generate and enqueue all possible child subsets
                foreach (string element in words)
                {
                    if (!subset.Contains(element))
                    {
                        HashSet<string> newSubset = new HashSet<string>();
                        newSubset.UnionWith(subset);
                        newSubset.Add(element);
                        subsetsQueue.Enqueue(newSubset);
                    }
                }
            }

        }
    }
}
