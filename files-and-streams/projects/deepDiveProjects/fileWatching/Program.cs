using System;
using static System.Console;
using System.Text;
using System.IO;

namespace fileWatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parsing command line options");

            var directoryToWatch = args[0];

            if (!Directory.Exists(directoryToWatch))
            {
                WriteLine($"ERROR: {directoryToWatch} does not exist");

            }
            else
            {

                var directoryWatcher = new DirectoryWatcher(directoryToWatch);
                directoryWatcher.Watch();

            }
        }


    }


}

