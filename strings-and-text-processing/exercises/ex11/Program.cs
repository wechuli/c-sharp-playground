using System;

namespace ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            string forbiddenWords = "C#,CLR,Microsoft";
            string text = "Microsoft announced its next generation C# compiler today. It uses advanced parser and special optimizer for the Microsoft CLR.";

            string[] forbiddenWordsArray = forbiddenWords.Split(',');
            foreach (string word in forbiddenWordsArray)
            {
                Console.WriteLine(word);
                text = text.Replace(word, RepeatPadLeft("*", word.Length));
            }
            Console.WriteLine(text);
        }

        static string RepeatPadLeft(string s, int n)
        {
            return "".PadLeft(n, 'X').Replace("X", s);
        }
    }
}
