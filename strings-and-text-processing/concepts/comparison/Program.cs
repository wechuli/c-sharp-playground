using System;

namespace comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "C#";
            string word2 = "c#";

            Console.WriteLine(word1.Equals(word2));
            Console.WriteLine(word2.Equals("c#"));

            // If we are not interested in the Case
            Console.WriteLine(word1.Equals(word2, StringComparison.CurrentCultureIgnoreCase));
           
        }
    }
}
