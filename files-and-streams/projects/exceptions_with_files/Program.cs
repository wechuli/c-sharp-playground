using System;
using System.IO;

namespace exceptions_with_files
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"somedir\somefile.txt";
            try
            {
                StreamReader reader = new StreamReader(fileName);
                Console.WriteLine($"File {fileName} successfully opened");
                Console.WriteLine("File contents: ");
                using (reader)
                {
                    Console.WriteLine(reader.ReadToEnd());

                }

            }
            catch (FileNotFoundException e)
            {
                Console.Error.WriteLine($"Cannot find file  {fileName} {e}");
            }
            catch (DirectoryNotFoundException d)
            {
                Console.Error.WriteLine($"Cannot find directory  {fileName} {d}");
            }
            catch (IOException io)
            {
                Console.Error.WriteLine($"Cannot open the file  {fileName} {io}");
            }

            // The example demonstrates reading a file and printing its contents to the console. If we accidentaly confuse the name of the file or deleted it, an exception of type FileNotFoundException will be thrown. In ths catch block, we intercept this sort of exception and if such occurs, we will process it properly and print a message to the console, saying that this file cannot be found. The same will happen if there were no directory named "somedir". Finally, for better security, we have also added a catch block for IOExceptions. There, all other IO exceptions, that might occur when working with files will be intercepted.

        }
    }
}
