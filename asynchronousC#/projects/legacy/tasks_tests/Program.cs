using System;
using System.Threading.Tasks;
namespace tasks_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                // Just Loop
                int ctr = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    ctr++;
                }
                Console.WriteLine($"Finished {ctr} loop iterations");
            });

            t.Wait();



            Console.WriteLine("I am after the task ");

        }
    }
}
