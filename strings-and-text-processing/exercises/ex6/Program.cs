using System;
using System.Text.RegularExpressions;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            //A text is given. Write a program that modifies the casing of letters to uppercase at all places in the text surrounded by <upcase> and </upcase> tags. Tags cannot be nested.
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.", insideTag;
            int startUpCase, endUpCase;

            Console.WriteLine("Original text: \n{0}\n", text);

            do
            {
                startUpCase = text.IndexOf("<upcase>", 0) + 8;
                endUpCase = text.IndexOf("</upcase>", startUpCase);
                insideTag = text.Substring(startUpCase, endUpCase - startUpCase).ToUpper();
                text = text.Remove(startUpCase, endUpCase - startUpCase);
                text = text.Insert(startUpCase, insideTag);
                text = text.Remove(startUpCase - 8, 8);
                text = text.Remove(endUpCase - 8, 9);
            } while (text.Contains("<upcase>") && text.Contains("</upcase>"));

            Console.WriteLine("Modified text: \n{0}\n", text);
            Console.ReadLine();
        }
    }
}