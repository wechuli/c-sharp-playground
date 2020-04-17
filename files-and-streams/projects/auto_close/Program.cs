using System;
using System.IO;

namespace auto_close
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of StreamReader to read from a file
            StreamReader reader = new StreamReader("poem.txt");

            using (reader)
            {
                int lineNumber = 0;

                //Read first line from the text file
                string line = reader.ReadLine();

                //Read the other lines from the text file

                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine($"Line {lineNumber}: {line}");
                    line = reader.ReadLine();
                }
            }

        }
    }
}
