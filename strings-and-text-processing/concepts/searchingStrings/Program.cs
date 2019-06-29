using System;

namespace searchingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = "Introduction to C# book";
            int index2 = book.IndexOf("C#");

            Console.WriteLine(index2);

            string str = "C# Programming Course";
            int index = str.IndexOf("C#"); // index = 0
            index = str.IndexOf("Course"); // index = 15
            index = str.IndexOf("COURSE"); // index = -1
            index = str.IndexOf("ram"); // index = 7
            index = str.IndexOf("r"); // index = 4
            index = str.IndexOf("r", 5); // index = 7
            index = str.IndexOf("r", 10); // index = 18

        }
    }
}
