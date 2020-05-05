using System;
using System.Linq;
using System.Collections.Generic;

namespace playGround
{
    class Program
    {
        static void Main(string[] args)
        {


            Func<string> something = () => "Hello World!";

            Action anotherThing = () => Console.WriteLine("Hi ther");
            Console.WriteLine(something());
            anotherThing();

            double[] someNames = { 1.2, 3.5, 5, 5, 34.6, 43 };

            var sum = someNames.Select(number => number + 100);
            IEnumerable<double> numbers = sum;

            Console.WriteLine(sum.GetType());
            foreach (var num in sum)
            {
                Console.WriteLine(num);
            }

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }


        }
    }
}
