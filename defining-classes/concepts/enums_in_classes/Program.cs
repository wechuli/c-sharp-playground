using System;

namespace enums_in_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Coffee
    {
        //Enumeration declared inside a class

        public static enum CoffeeSize
        {
            Small = 100, Normal = 150, Double = 300
        }

        //Instance variables of the enumerated type

        private CoffeeSize size;

        public Coffee(CoffeeSize size)
        {
            this.size = size;
        }
        public CoffeeSize Size
        {
            get { return size; }
        }
    }
}
