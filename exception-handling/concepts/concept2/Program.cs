using System;
using System.IO;
namespace concept2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "WrongTextFile.txt";
            ReadFile(fileName);
        }
        static void ReadFile(string fileName)
        {
            //exception could be thrown in the code below
            try
            {
                TextReader reader = new StreamReader(fileName);
                string line = reader.ReadLine();
                Console.WriteLine(line);
                reader.Close();

            }
            catch (FileNotFoundException fnfe)
            {
                //Exception handler for FileNotFoundException
                //We just infrom the user that there is no such file
                Console.WriteLine($"The file {fileName} is not found");
               // Console.WriteLine(fnfe.StackTrace);


            }
            catch (IOException ioe)
            {
                //Exception handler for other input/output exceptions

                Console.WriteLine(ioe.StackTrace);
            }
        }
    }
}
