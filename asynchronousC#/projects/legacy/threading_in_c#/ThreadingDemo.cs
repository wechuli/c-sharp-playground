using System;
using System.Threading;

namespace threading_in_c_
{
    class ThreadDemoManager
    {
        public void ShowThreadInfo()
        {
            // Thread.CurrentThread
            Console.WriteLine("Thread information for the current thread");
            Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Is background: {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"ThreadState: {Thread.CurrentThread.ThreadState}");
            Console.WriteLine($"Current Culture: {Thread.CurrentThread.CurrentCulture}");
            Console.WriteLine($"AppDomain ID: {AppDomain.CurrentDomain.Id}");
        }

        public void RunCodeOnSeparateThread()
        {
            Console.WriteLine("Primary thread");
            Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Is background: {Thread.CurrentThread.IsBackground}");

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Console.WriteLine("Worker Thread");
                Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Is background: {Thread.CurrentThread.IsBackground}");

            }).Start();
        }


        public void RunCodeInThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(p => RunALoop());
            }
        }

        private void RunALoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Number: {i} from thread id: {Thread.CurrentThread.ManagedThreadId}");

            }
        }
        public void Execute()
        {
            RunCodeInThreadPool();

        }
    }
}
