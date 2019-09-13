using System;
using System.Collections.Generic;
using System.IO;

namespace traverse_hard_drive_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            TraverseDir("G:\\videos");
        }


        public static void TraverseDir(string directoryPath)
        {
            // Traverses and prints given directory with BFS

            Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
            visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));
            while (visitedDirsQueue.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);

                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    visitedDirsQueue.Enqueue(child);
                }
            }

        }
    }

}
