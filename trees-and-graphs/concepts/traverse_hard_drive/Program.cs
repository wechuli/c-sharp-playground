using System;
using System.IO;

namespace traverse_hard_drive
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryTraverserDFS.TraverseDir("G:\\videos");
            
        }
    }

    public static class DirectoryTraverserDFS
    {
        private static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            //Visit the current directory
            Console.WriteLine(spaces + dir.FullName);

            DirectoryInfo[] children = dir.GetDirectories();

            //For each child go and visit its sub-trees
            foreach (var child in children)
            {
                TraverseDir(child,spaces + " ");
            }
        }

        // Traverse and print the given directory recursively

        public static void TraverseDir(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath),string.Empty);
        }
    }
}
