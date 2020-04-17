using System;
using System.IO;

namespace substring_in_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "sample.txt";
            string subString = "C#";

            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    int occurences = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        int index = line.IndexOf(subString);
                        while (index != -1)
                        {
                            occurences++;
                            index = line.IndexOf(subString, (index + 1));
                        }
                        line = reader.ReadLine();
                    }
                    Console.WriteLine("The subString {0} occurs {1} times.", subString, occurences);
                }

            }
            catch (FileNotFoundException)
            {

                Console.Error.WriteLine("Can not find file {0}.", fileName);
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Cannot read the file {0}.", fileName);
            }
        }
    }
}
