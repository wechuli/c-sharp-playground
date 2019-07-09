using System;

namespace defaultFieldValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            Console.WriteLine(dog.name);
            Console.WriteLine(dog.age);
            Console.WriteLine(dog.isMale);
        }
    }

    class Dog
    {
        public string name;
        public int age;
        public int length;
        public bool isMale;
    }
}
