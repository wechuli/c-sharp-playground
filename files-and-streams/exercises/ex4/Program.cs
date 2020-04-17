using System;
using System.IO;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that compares two text files with the same number of rows line by line and prints the number of equal and the number of different lines.
            string fileName1 = "poem.txt";
            string fileName2 = "poem2.txt";

            try
            {
                CompareTwoFiles(fileName1, fileName2);
            }
            catch (ApplicationException e)
            {

                Console.WriteLine("Files must have an equal number of lines to be compared");
            }


        }


        public static void CompareTwoFiles(string fileName1, string fileName2)
        {
            int identicalLines = 0;
            int differentLines = 0;
            if (File.ReadAllLines(fileName1).Length != File.ReadAllLines(fileName2).Length)
            {
                throw new ApplicationException("The files provided have different lengths");
            }

            try
            {
                StreamReader file1 = new StreamReader(fileName1);
                StreamReader file2 = new StreamReader(fileName2);


                using (file1)
                {
                    using (file2)
                    {


                        string file1Line = file1.ReadLine();
                        string file2Line = file2.ReadLine();

                        while (file1Line != null)
                        {
                            if (String.Equals(file1Line, file2Line))
                            {
                                identicalLines++;
                            }
                            else
                            {
                                differentLines++;
                            }

                            file1Line = file1.ReadLine();
                            file2Line = file2.ReadLine();
                        }

                    }
                }

                Console.WriteLine($"Identical lines: {identicalLines}");
                Console.WriteLine($"Different lines: {differentLines}");

            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine("File(s) not found");
            }
            catch (IOException io)
            {

                Console.WriteLine("Error while opening File(s)");

            }

        }
    }
}
