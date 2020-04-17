using System;
using static System.Console;
using System.IO;


namespace fileWatching
{

    public class DirectoryWatcher
    {

        public string DirectoryToWatch { get; }

        public DirectoryWatcher(string directoryPath)
        {

            this.DirectoryToWatch = directoryPath;

        }

        public void Watch()
        {
            WriteLine($"Watching directory {this.DirectoryToWatch} for changes");
            using (var inputFileWatcher = new FileSystemWatcher(this.DirectoryToWatch))
            {
                inputFileWatcher.IncludeSubdirectories = false;
                inputFileWatcher.InternalBufferSize = 32768; //32KB
                inputFileWatcher.Filter = "*.*";
                inputFileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastWrite | NotifyFilters.FileName;


                inputFileWatcher.Created += FileCreated;
                inputFileWatcher.Changed += FileChanged;
                inputFileWatcher.Deleted += FileDeleted;
                inputFileWatcher.Renamed += FileRenamed;
                inputFileWatcher.Error += WatcherError;
                inputFileWatcher.EnableRaisingEvents = true;

                WriteLine("Press enter to quit. ");
                ReadLine();

            }

        }

        private static void FileCreated(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File created: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File changed: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            WriteLine($"* File deleted: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileRenamed(object sender, RenamedEventArgs e)
        {
            WriteLine($"* File renamed: {e.OldName} to {e.Name} - type: {e.ChangeType}");
        }

        private static void WatcherError(object sender, ErrorEventArgs e)
        {
            WriteLine($"ERROR: file system watching may no longer be active: {e.GetException()}");
        }

    }

}