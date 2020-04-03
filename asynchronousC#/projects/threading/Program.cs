using System;
using System.Threading;
using System.Threading.Tasks;

namespace threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread currentThread = Thread.CurrentThread;

            Console.WriteLine($"Current thread: {currentThread.ManagedThreadId}");

            Task t = Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(Thread.CurrentThread.IsBackground);
                // Just loop.
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            });


            Thread.Sleep(1000);
            Console.WriteLine("I am a log after the Task.Run call");
            //t.Wait();

        }
    }
}
