using System;

namespace visibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Dog
    {
        private string name = "doggy";
        public string name
        {
            get { return this.name; }
        }
        public void Bark()
        {
            Console.WriteLine("wow-wow");
        }
        public void DoSomething()
        {
            this.Bark();
        }
    }

    public class Kid

    {
        public void CallTheDog(Dog dog)
        {
            Console.WriteLine($"Come, ${dog.Name}");
        }
        public void WagTheDog(Dog dog)
        {
            dog.Bark();
        }
    }
}
