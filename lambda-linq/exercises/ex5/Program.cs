using System;
using System.Text;
using System.Collections.Generic;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {

            //Write an extension method for the class String that capitalizes all letters, which are the beginning of a word in a sentence in English. For example: "this iS a Sample sentence." should be converted to "This Is A Sample Sentence.".

            string sentence = "this iS a Sample sentence.";
            Console.WriteLine(sentence.CapitalizeFirstLetterInWords());

        }
    }

    public static class StringExtensionMethods
    {
        public static string CapitalizeFirstLetterInWords(this String words)
        {

            string[] splitWords = words.Split(' ');
            StringBuilder capitalizedWords = new StringBuilder();
            foreach (var word in splitWords)
            {

                string fixedWord = word[0].ToString().ToUpper() + word.Substring(1).ToLower() + " ";

                capitalizedWords.Append(fixedWord);
            }
            capitalizedWords.Remove(capitalizedWords.Length - 1, 1);

            return capitalizedWords.ToString();


        }
    }
}
