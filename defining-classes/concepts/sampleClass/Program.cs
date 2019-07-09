using System;

namespace sampleClass
{
    class Program
    {
        public static int defaultVal;
        static void Main(string[] args)
        {


            Console.WriteLine(defaultVal);

            string firstDogName = null;
            Console.Write("Enter first dog name: ");
            firstDogName = Console.ReadLine();

            //using a constructor to create a dog with specified name
            Dog firstDog = new Dog(firstDogName);

            //using a constructor to create a dog with a default name
            Dog secondDog = new Dog();

            Console.Write("Enter the second dog name: ");
            string secondDogName = Console.ReadLine();

            //using property to set the name of the dog
            secondDog.Name = secondDogName;

            //creating a dog with a default name
            Dog thirdDog = new Dog();

            Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog };

            foreach (Dog dog in dogs)
            {
                dog.Bark();
            }
        }

        public static void TestMethod()
        {
            string testString;
        }
    }

    //class declaration
    class Dog
    {
        //Field declaration
        private string name;
        //Constructor declaration
        public Dog()
        {

        }
        //Another constructor declaration
        public Dog(string name)
        {
            this.name = name;
        }
        //propert declaration
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //Method declaration(non-static)
        public void Bark()
        {
            Console.WriteLine($"{name ?? "[unnamed dog]"} said: Wow-wow!");
        }
    }
}
