using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace parallelCodeErrorHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExecuteTasks();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine("{0}:\n   {1}", e.GetType().Name, e.Message);
                }
            }
        }

        static void ExecuteTasks()
        {
            // Assume this is a user-entered string
            String path = @"C:\";
            List<Task> tasks = new List<Task>();

            Task first = Task.Run(() =>
            {
                // This should throw an UnauthorizedAccessException.
                return Directory.GetFiles(path, "*.txt",
                                          SearchOption.AllDirectories);
            });

            Task second = Task.Run(() =>
            {
                if (path == @"C:\")
                    throw new ArgumentException("The system root is not a valid path.");
                return new String[] { ".txt", ".dll", ".exe", ".bin", ".dat" };
            });

            Task third = Task.Run(() =>
            {
                throw new NotImplementedException("This operation has not been implemented.");
            });

            tasks.Add(first);
            tasks.Add(second);
            tasks.Add(third);

            try
            {
                Task.WaitAll(tasks.ToArray());

            }
            catch (AggregateException ae)
            {
                foreach (Exception ex in ae.InnerExceptions)
                {

                }
                throw ae.Flatten();
            }


        }
    }

}
