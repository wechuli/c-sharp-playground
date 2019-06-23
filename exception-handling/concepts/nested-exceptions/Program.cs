using System;
using System.IO;

namespace nested_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName = "WrongFileName.txt";
                ReadFile(fileName);
            }
            catch (System.Exception e)
            {

                throw new ApplicationException("Somethind bad happened", e);
            }
        }

        static void ReadFile(string fileName)
        {
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            Console.WriteLine(line);
            reader.Close();

        }
    }
}
