using System;

namespace unnecessary_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileData = "  \n\n  David allen  ";
            Console.WriteLine(fileData);
            string reduced = fileData.Trim();
            Console.WriteLine(reduced);

            //the Trim() method can accept an array of characters, which we want to remove from the string.
            string fileData2 = " 111 $ % David Allen ### s ";
            char[] trimChars = new char[] { ' ', '1', '$', '%', '#', 's' };
            string reduced2 = fileData2.Trim(trimChars);
            Console.WriteLine(reduced2);

            //If we want to remove the white spaces only at the beginning or in the end of the string, we can use the methods TrimStart() and TrimEnd()
        }
    }
}
