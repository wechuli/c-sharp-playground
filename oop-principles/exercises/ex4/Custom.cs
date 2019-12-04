using System;
using System.Collections.Generic;

namespace ex4
{
    public class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }


        public Animal(string name, string gender, int age)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;

        }

        public virtual void makeAnimalSound()
        {
            Console.WriteLine("Generic Sound AAAAWW");
        }

    }
    public class Dog : Animal
    {
        public string Sound { get; set; }
        public string dogSound = "Woof";
        public Dog(string name, string gender, int age) : base(name, gender, age)
        {


        }

        public override void makeAnimalSound()
        {
            Console.WriteLine(this.dogSound, this.dogSound);

        }
    }

    public class Frog : Animal
    {
        public string Sound { get; set; }
        public string frogSound = "Crock";
        public Frog(string name, string gender, int age) : base(name, gender, age)
        {


        }

        public override void makeAnimalSound()
        {
            Console.WriteLine(this.frogSound, this.frogSound);

        }
    }

    public class Cat : Animal
    {
        public string Sound { get; set; }
        public string catSound = "meow";
        public Cat(string name, string gender, int age) : base(name, gender, age)
        {


        }

        public override void makeAnimalSound()
        {
            Console.WriteLine(this.catSound, this.catSound);

        }
    }

}