using System;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            string myText = "one\\two\\three";
            //How many backslashes you must specify as an argument to the method Split(…) in order to split the text by a backslash?
            //Example: one\two\three.

            string[] splitStrings = myText.Split("\\");
            foreach (var item in splitStrings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
