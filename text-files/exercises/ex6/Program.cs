using System;
using System.IO;
using System.Collections.Generic;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            //   Write a program that reads a list of names from a text file, arranges them in alphabetical order, and writes them to another file. The lines are written one per row.
            string unSortedFile = "names.txt";
            string sortedNames = "namesSorted.txt";
            SortNamesAndWriteToNewFile(unSortedFile, sortedNames);

        }

        static void SortNamesAndWriteToNewFile(string namesfile, string sortedFile)
        {

            List<string> namesList = new List<string>();

            try
            {
                StreamReader reader = new StreamReader(namesfile);
                StreamWriter writer = new StreamWriter(sortedFile);

                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        namesList.Add(line);
                        line = reader.ReadLine();
                    }
                }
                using (writer)
                {
                    namesList.Sort();
                    foreach (var name in namesList)
                    {
                        writer.WriteLine(name);
                    }
                }

                Console.WriteLine("Successfully sorted your names list");
            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine("File not found");
            }
            catch (IOException io)
            {
                Console.WriteLine("A problem occured while opening the file");
            }
        }
    }
}
