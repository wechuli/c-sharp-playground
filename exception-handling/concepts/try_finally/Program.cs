using System;
using System.IO;

namespace try_finally
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
            TextReader reader = null;
            try
            {
                reader = new StreamReader(fileName);
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            finally
            {
                //Always close 'reader'If it was opened
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
