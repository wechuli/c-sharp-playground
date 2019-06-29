using System;

namespace stringConcatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            string greet = "Hello";
            string name = "reader!";
            string result = String.Concat(greet, " ", name);
            Console.WriteLine(result);

            // we could use the + and += operators
            string result2 = greet + " " + name;
            Console.WriteLine(result2);

            //we can concatenate strings to other data types
            string message = "the number of the beast i: ";
            int beastNum = 666;
            string result3 = message + beastNum;
            Console.WriteLine(result3);

        }
    }
}
