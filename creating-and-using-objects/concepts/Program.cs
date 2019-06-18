using System;
using myclasses;

namespace concepts
{
    class Program
    {
        static void Main(string[] args)
        {
            myclasses.Cat firstCat = new myclasses.Cat();
            firstCat.Name = "Tony";
            firstCat.Color = "red";
            firstCat.SayMiau();

            myclasses.Cat secondCat = new myclasses.Cat("Pepy", "black");
            secondCat.SayMiau();
            Console.WriteLine($"Cat {secondCat.Name} is {secondCat.Color}");

            int number = Sequence.NextValue();
            Console.WriteLine(number);
            Console.WriteLine(Sequence.NextValue());


        }
    }
}
