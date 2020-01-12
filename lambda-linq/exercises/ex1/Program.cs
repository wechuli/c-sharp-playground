using System;
using System.Text;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implement an extension method Substring(int index, int length) for the class StringBuilder that returns a new StringBuilder and has the same functionality as the method Substring(...) of the class String

            string testString = "This is a fake string, lets see what we get when we call both methods, from string and from the exesntion method";
            Console.WriteLine(testString.Substring(5, 10));
            StringBuilder testStringInBuilder = new StringBuilder(testString);

            Console.WriteLine(testStringInBuilder.Substring(5, 10).ToString());



        }
    }

    public static class AdditionalExtensionMethods
    {
        public static StringBuilder Substring(this StringBuilder originalString, int index, int length)
        {
            StringBuilder newSubString = new StringBuilder();
            string substring = originalString.ToString().Substring(index, length);
            newSubString.Append(substring);
            return newSubString;
        }
    }
}
