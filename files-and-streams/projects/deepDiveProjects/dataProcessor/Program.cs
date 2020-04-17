using System;
using System.IO;
using System.Text;

namespace dataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parsing command line options");

            var command = args[0];

            if (command == "--file")
            {
                var filePath = args[1];
                Console.WriteLine($"Single file {filePath} selected");
                ProcessSingleFile(filePath);
            }

            else if (command == "dir")
            {
                var directoryPath = args[1];
                var fileType = args[2];

                Console.WriteLine($"Directory {directoryPath} selected for {fileType} files");
                ProcessDirectory(directoryPath, fileType);
            }
            else
            {
                Console.WriteLine("Invalid command line options");
            }
            Console.WriteLine("Press enter to quit. ");
            Console.ReadLine();

        }

        private static void ProcessSingleFile(string filePath)
        {
            var fileProcessor = new FileProcessor(filePath);
            fileProcessor.Process();
        }

        private static void ProcessDirectory(string directoryPath, string fileType)
        {

            //  var allFiles = Directory.GetFiles(directoryPath);// to get all files

            switch (fileType)
            {
                case "TEXT":
                    string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");
                    foreach (var textFilePath in textFiles)
                    {
                        var fileProcessor = new FileProcessor(textFilePath);
                        fileProcessor.Process();
                    }
                    break;
                default:
                    Console.WriteLine($"Error");
                    break;

            }

        }
    }
}
