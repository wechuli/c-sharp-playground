using System;
using System.IO;


namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that joins two text files and records the results in a third file

            string file1 = "survive1.txt";
            string file2 = "survive2.txt";
            string newFileName = "survive.txt";

            JoinContentsOfTwoFiles(file1, file2, newFileName);
        }

        static void JoinContentsOfTwoFiles(string file1, string file2, string newFileName)
        {
            try
            {
                StreamReader file1Reader = new StreamReader(file1);
                StreamReader file2Reader = new StreamReader(file2);
                StreamWriter finalFileWriter = new StreamWriter(newFileName);

                string allFileContents;

                using (file1Reader)
                {
                    allFileContents = file1Reader.ReadToEnd();
                }
                using (file2Reader)
                {
                    allFileContents = string.Concat(allFileContents, file2Reader.ReadToEnd());
                }
                using (finalFileWriter)
                {
                    finalFileWriter.Write(allFileContents);
                }



            }
            catch (FileNotFoundException)
            {

                Console.WriteLine($"The file(s) was not found");
            }
            catch (IOException)
            {
                Console.WriteLine($"Something went wrong while reading the file(s)");
            }

        }
    }




}
