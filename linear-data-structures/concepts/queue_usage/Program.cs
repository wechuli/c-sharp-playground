using System;
using System.Collections.Generic;

namespace queue_usage
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");

            while(queue.Count > 0)
            {
                string msg = queue.Dequeue();
                Console.WriteLine(msg);
            }

        }
    }
}
