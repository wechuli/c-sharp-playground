using System;

namespace access_static_non_static
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog("Doggy", 1);
            dog.PrintInfo();
            var myCirlce = new Circle(34.3);
            myCirlce.PrintSurface();
        }
    }

    public class Dog
    {
        //static variable
        static int dogCount;

        //Instance variable
        private string name;
        private int age;

        public Dog(string name, int age)
        {
            this.name = name;
            this.age = age;
            dogCount += 1;
        }
        public void Bark()
        {
            Console.WriteLine("woof-woof");
        }

        //Non-static(instance) method
        public void PrintInfo()
        {
            // Accessing instance variables – name and age
            Console.Write("Dog's name: " + this.name + "; age: "
            + this.age + "; often says: ");
            // Calling instance method
            this.Bark();
        }
        public static void PrintName()
        {
            Console.WriteLine(name); // this will be a compilation error
            Console.WriteLine(this.name); // this will be a compilation error - this cannot be defined here
        }
    }
}
