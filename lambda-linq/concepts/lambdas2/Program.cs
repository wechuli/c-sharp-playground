using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace lambdas2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>() { new Dog { Name = "Rex", Age = 4 }, new Dog { Name = "Sean", Age = 0 }, new Dog { Name = "Stacy", Age = 3 } };
            var newDogList = dogs.Select(x => new { AggregateException = x.Age, FirstLetter = x.Name[0] });
            foreach (var item in newDogList)
            {
                Console.WriteLine(item);
            }

            // Sorted dogs

            var sortedDogs = dogs.OrderByDescending(x => x.Age);
            foreach (var dog in sortedDogs)
            {
                Console.WriteLine($"Dog {dog.Name} is {dog.Age} years old");
            }

            // Lamdas with bodies
            List<int> numberList = new List<int>() { 20, 1, 4, 8, 9, 44 };
            // Process each argument with code statements
            var evenNumbers = numberList.FindAll((i) =>
            {
                Console.WriteLine($"Value of i is:{i}");
                return (i % 2) == 0;
            });


            Console.WriteLine("Even Numbers");
            foreach (var number in evenNumbers)
            {

                Console.WriteLine($"{number}");
            }
        }
    }

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
