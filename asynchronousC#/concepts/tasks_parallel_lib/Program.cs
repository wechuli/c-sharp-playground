using System;
using System.Threading.Tasks;

namespace tasks_parallel_lib
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = Task.Run(() =>
            {
                // just loop

                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                {

                }
                Console.WriteLine($"Finished {ctr} loop iterations");
            });

            Console.WriteLine("I am after the task before wait");

            t.Wait();

            Console.WriteLine("I am after the task after wait");


        }
    }
}
