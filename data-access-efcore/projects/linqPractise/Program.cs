using System;
using System.Linq;
using System.Collections.Generic;

namespace linqPractise
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> words = new List<string> { "Cow", "Dog", "at", "the", "Cow", "at", "providence" };


            var test = words.Sum((word) => word.Count());
            Console.WriteLine(test);
            var wordGroupings = from word in words
                                group word by word;

            foreach (var grouping in wordGroupings)
            {
                Console.WriteLine($"The group is {grouping.Key}");

                foreach (var group in grouping)
                {
                    Console.WriteLine(group);

                }

                Console.WriteLine(grouping.Count());
            }

            Action fake = () => Console.WriteLine("Hey there");

            fake();



        }
    }
}
