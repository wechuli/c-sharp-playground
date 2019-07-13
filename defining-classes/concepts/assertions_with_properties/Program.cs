using System;

namespace assertions_with_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Person paul = new Person();
            paul.Age = -23; //will throw an error
        }
    }

    class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                //Take precaution: perform check for correctness
                if (value < 0)
                {
                    throw new ArgumentException("Invalid argument: Age should be positive. ");
                }

                //Assign the new correct value
                this.age = value;
            }
        }
    }
}
