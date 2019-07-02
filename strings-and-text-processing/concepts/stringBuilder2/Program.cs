using System;
using System.Text;

namespace stringBuilder2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extract all capital letter from a string
            string words = "thIs is My string Filled WITH a miXTure oF smalL and Captial Letters";

            Console.WriteLine(ExtractCapitals(words));
        }

        public static string ExtractCapitals(string str)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (char.IsUpper(ch))
                {
                    result.Append(ch);
                }
            }
            return result.ToString();
        }
    }

}
