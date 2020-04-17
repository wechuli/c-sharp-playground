using System;
using System.IO;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads a text file and prints its odd lines on the console

            string fileName = "middlemarch.txt";
            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    int lineNumber = 0;
                    string lineContent = reader.ReadLine();

                    while (lineContent != null)
                    {
                        if (lineNumber % 2 != 0)
                        {
                            Console.WriteLine(lineContent);
                        }
                        lineNumber++;
                        lineContent = reader.ReadLine();
                    }

                }

            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"The file {fileName} was not found");
            }
            catch (IOException)
            {
                Console.WriteLine($"Something went wrong while reading the file {fileName}");
            }

        }
    }
}
