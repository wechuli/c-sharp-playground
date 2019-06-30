using System;

namespace replacing_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string doc = "Hello, some@gmail.com, you have been using some@gmail.com in your resistration";
            string fixedDoc = doc.Replace("some@gmail.com", "john@smith.com");
            Console.WriteLine(fixedDoc);
        }
    }
}
