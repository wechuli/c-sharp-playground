using System;
using System.Collections.Generic;

namespace sorted_dict
{
    class Program
    {
        private static readonly string Text = "Mary had a little lamb, little Lamb, little Lamb, Mary had a Little lamb, Whose whose fleexe were white as snow";
        static void Main(string[] args)
        {
            SortedDictionary<string, int> wordOccurenceMap = GetWordOccurrenceMap(Text);
            PrintWordOccurrenceCount(wordOccurenceMap);

        }
        private static SortedDictionary<string, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!');
            SortedDictionary<string, int> words = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
            foreach (var word in tokens)
            {
                if (!string.IsNullOrEmpty(word.Trim()))
                {
                    int count;
                    if (!words.TryGetValue(word, out count))
                    {
                        count = 0;
                    }
                    words[word] = count + 1;
                }
            }
            return words;
        }
        private static void PrintWordOccurrenceCount(SortedDictionary<string, int> wordOccurenceMap)
        {
            foreach (var wordEntry in wordOccurenceMap)
            {
                Console.WriteLine($"Word {wordEntry.Key} occurs {wordEntry.Value} time(s) in the text");
            }
        }
    }
    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            return string.Compare(s1, s2, true);
        }
    }
}
