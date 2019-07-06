using System;
using System.Text;

namespace ex9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that encrypts a text by applying XOR (excluding or) operation between the given source characters and given cipher code. The encryption should be done by applying XOR between the first letter of the text and the first letter of the code, the second letter of the text and the second letter of the code, etc. until the last letter of the code, then goes back to the first letter of the code and the next letter of the text. Print the result as a series of Unicode escape characters \xxxx.
            // Sample source text: "Test". Sample cipher code: "ab". The result should be the following: "\u0035\u0007\u0012\u0016".
            string text = "Test";
            string code = "ab";
            string paddedCode = RepeatPadLeft(code, text.Length / code.Length);
            // Console.WriteLine((int)a ^ (int)T);

            int cypher;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                cypher = (int)text[i] ^ (int)paddedCode[i];
                sb.Append(String.Format("\\u{0:X4}", cypher));

            }
            Console.WriteLine(sb.ToString());
        }

        static string RepeatPadLeft(string s, int n)
        {
            return "".PadLeft(n, 'X').Replace("X", s);
        }
    }
}
