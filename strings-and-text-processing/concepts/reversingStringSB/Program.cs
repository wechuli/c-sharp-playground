using System;
using System.Text;

namespace reversingStringSB
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "edit Me Please";
            string reversed = ReverseText(text);
            Console.WriteLine(reversed);

        }

        static string ReverseText(string text)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            return sb.ToString();
        }
    }
}
