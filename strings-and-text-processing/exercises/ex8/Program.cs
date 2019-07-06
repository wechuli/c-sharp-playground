using System;
using System.Text;

namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that converts a given string into the form of array of Unicode escape sequences in the format used in the C# language. Sample input: "Test". Result: "\u0054\u0065\u0073\u0074".
            string input = "Test";
            var utf8 = Encoding.UTF8;
            byte[] utf8Bytes = utf8.GetBytes(input);
            foreach (byte b in utf8Bytes)
            {
                Console.Write("\\u{0:X4}", b);
            }
        }
    }
}
