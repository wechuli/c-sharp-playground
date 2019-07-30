using System;
using System.IO;

namespace reading_files
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a StreamReader connected to a file:
            StreamReader reader = new StreamReader("poem.txt");
        }
    }
}
