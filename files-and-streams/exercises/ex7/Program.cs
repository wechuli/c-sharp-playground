using System;
using System.Collections.Generic;
using System.IO;
namespace ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that replaces every occurrence of the substring "start" with "finish" in a text file. Can you rewrite the program to replace whole words only? Does the program work for large files (e.g. 800 MB)?
            ReplaceGivenWord("file1.txt", "start", "finish");
            ReplaceGivenWord("file2.txt", "start", "finish", "w");

        }

        static void ReplaceGivenWord(string fileName, string wordToReplace, string wordToReplaceWith, string replaceMethod = "a")
        {

            // w - to replace whole words only

            List<string> editedWords = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(fileName);

                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (String.Equals(replaceMethod, "w"))
                        {
                            editedWords.Add(line.Replace($" {wordToReplace} ", $" {wordToReplaceWith} "));
                        }
                        else
                        {
                            editedWords.Add(line.Replace(wordToReplace, wordToReplaceWith));
                        }


                        line = reader.ReadLine();

                    }
                }
                StreamWriter writer = new StreamWriter(fileName);

                using (writer)
                {
                    foreach (var line in editedWords)
                    {
                        writer.WriteLine(line);
                    }

                }

            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine("File not found");
            }
            catch (IOException io)
            {
                Console.WriteLine("Error while opening file");
            }
        }



    }
}
