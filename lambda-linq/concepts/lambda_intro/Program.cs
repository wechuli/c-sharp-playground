using System;
using System.Linq;
using System.Collections.Generic;

namespace lambda_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);

            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }

            List<Dog> dogs = new List<Dog>() { new Dog { Name = "Rex", Age = 4 }, new Dog { Name = "Sean", Age = 0 }, new Dog { Name = "Stacy", Age = 3 } };
            var names = dogs.Select(x => x.Name);
            foreach (var item in names)
            {
                Console.WriteLine(item);

            }
        }


    }

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
