using System;
using System.IO;
using System.Collections.Generic;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads the contents of a text file and inserts the line numbers at the beginning of each line, then rewrites the file contents

            string fileName = "grief.txt";
            AddLineNumbersToTextFile(fileName);


        }

        static void AddLineNumbersToTextFile(string fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                
                List<string> numberedList = new List<string>();

                using (reader)
                {
                     
                    string lineContent = reader.ReadLine();

                    int lineNumber = 1;
                   
                    while (lineContent != null)
                    {
                        numberedList.Add(string.Concat($"{lineNumber} ", lineContent));

                        lineContent = reader.ReadLine();
                        lineNumber++;
                    }
                }

                StreamWriter writer = new StreamWriter(fileName);
                using (writer)
                {
                    foreach (var line in numberedList)
                    {
                        writer.WriteLine(line);
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
