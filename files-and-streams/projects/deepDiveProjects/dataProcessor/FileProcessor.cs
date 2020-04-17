using System;
using System.IO;



namespace dataProcessor
{

    internal class FileProcessor
    {

        private static readonly string BackupDirectoryName = "backup";
        private static readonly string InProgressDirectoryName = "processing";
        private static readonly string CompletedDirectoryName = "complete";

        public string InputFilePath { get; }

        public FileProcessor(string filePath)
        {


            this.InputFilePath = filePath;
        }

        public void Process()
        {
            Console.WriteLine($"Begin process of {InputFilePath}");

            // Check if file exists
            if (!File.Exists(this.InputFilePath))
            {
                Console.WriteLine($"ERROR: file {InputFilePath} does not exist. ");
                return;
            }

            string rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent.Parent.FullName;
            Console.WriteLine("Root data path is ", rootDirectoryPath);

            // check if backup dir exists

            string inputFileDirectoryPath = Path.GetDirectoryName(this.InputFilePath);
            string backupDirectoryPath = Path.Combine(rootDirectoryPath, BackupDirectoryName);

            // if (!Directory.Exists(backupDirectoryPath))
            // {
            //     Console.WriteLine($"Creating {backupDirectoryPath}");
            //     Directory.CreateDirectory(backupDirectoryPath);
            // }

            Directory.CreateDirectory(backupDirectoryPath);


            // Copy file backup dir
            string inputFileName = Path.GetFileName(InputFilePath);
            string backupFilePath = Path.Combine(backupDirectoryPath, inputFileName);
            Console.WriteLine($"Copying {this.InputFilePath} to {backupFilePath}");

            File.Copy(this.InputFilePath, backupFilePath, true);

            // Move to in progress dir
            Directory.CreateDirectory(Path.Combine(rootDirectoryPath, InProgressDirectoryName));


            string inProgressFilePath = Path.Combine(rootDirectoryPath, InProgressDirectoryName, inputFileName);

            if (File.Exists(inProgressFilePath))
            {
                Console.WriteLine($"Error: a file with the name {inProgressFilePath} is already being processed");
                return;
            }

            Console.WriteLine($"Moving {this.InputFilePath} to {inProgressFilePath}");
            File.Move(InputFilePath, inProgressFilePath);

            // Determine type of file

            string extension = Path.GetExtension(this.InputFilePath);
            switch (extension)
            {
                case ".txt":
                    ProcessTextFile(inProgressFilePath);
                    break;

                default:
                    Console.WriteLine($"{extension} is an unsupported file type");
                    break;
            }

            string completedDirectoryPath = Path.Combine(rootDirectoryPath, CompletedDirectoryName);
            Directory.CreateDirectory(completedDirectoryPath);

            Console.WriteLine($"Moving {inProgressFilePath} to {completedDirectoryPath}");
            var completedFileName = $"{Path.GetFileNameWithoutExtension(this.InputFilePath)}-{Guid.NewGuid()}{extension}";

            var completedFilePath = Path.Combine(completedDirectoryPath, completedFileName);

            File.Move(inProgressFilePath, completedFilePath);


            string inProgressDirectoryPath = Path.GetDirectoryName(inProgressFilePath);
            Directory.Delete(inProgressDirectoryPath, true);
        }

        private void ProcessTextFile(string inProgressFilePath)
        {
            Console.WriteLine($"Processing text file {inProgressFilePath}");
            // Read in and process
        }


    }

}