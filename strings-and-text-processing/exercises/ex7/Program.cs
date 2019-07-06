using System;
using System.Text;

namespace ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads a string from the console (20 characters maximum) and if shorter complements it right with "*" to 20 characters.

            Console.Write("Please enter your charater sequence: ");
            string word = Console.ReadLine();
            if (word.Length > 20)
            {
                throw new Exception("Characters exceed the maximum allowed");
            }

            StringBuilder sb = new StringBuilder(word, 20);

            for (int i = sb.Length + 1; i <= sb.Capacity; i++)
            {
                sb.Append('*');
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine(sb.Length);

            // We can use the padright method on the string

            string newWord = word.PadRight(20, '*');
            Console.WriteLine(word);
            Console.WriteLine(newWord);




        }
    }
}
