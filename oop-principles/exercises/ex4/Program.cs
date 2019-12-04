using System;
using System.Collections.Generic;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog("Pillow", "F", 5));
            animals.Add(new Frog("Frog Prince", "M", 1));
            animals.Add(new Cat("Blu", "F", 3));


            foreach (var animal in animals)
            {
                animal.makeAnimalSound();
            }
        }
    }
}
