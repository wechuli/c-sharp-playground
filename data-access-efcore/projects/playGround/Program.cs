using System;

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
        }
    }
}
