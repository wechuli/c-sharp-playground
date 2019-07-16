using System;

namespace enumarations
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Days.Mon.GetType());

            Coffee normalCoffee = new Coffee(CoffeeSize.Normal);
            Coffee doubleCoffee = new Coffee(CoffeeSize.Double);

            Console.WriteLine("The {0} coffee is {1} ml.", normalCoffee.Size, (int)normalCoffee.Size);
            Console.WriteLine("The {0} coffee is {1} ml.",
            doubleCoffee.Size, (int)doubleCoffee.Size);
        }
    }

    public enum Days
    {
        Sun, Mon, Tue, Wed, Thu, Fri, Sar
    }

    public class Coffee
    {
        private CoffeeSize size;
        public Coffee(CoffeeSize size)

        {
            this.size = size;
        }
        public CoffeeSize Size
        {
            get { return this.size; }
        }

    }

    public enum CoffeeSize
    {
        Small = 100, Normal = 150, Double = 300
    }
}
