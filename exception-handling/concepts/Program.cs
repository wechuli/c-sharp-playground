using System;
using System.IO;

namespace concepts
{
    class Program
    {
        static void Main(string[] args)
        {
            //example error
            string fileName = "WrongTextFile.txt";
            ReadFile(fileName);
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
