using System;

namespace ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implement the data structure "Deque". This is a specific list-like structure, similar to stack and queue, allowing to add elements at the beginning and at the end of the structure. Implement the operations for adding and removing elements, as well as clearing the deque. If an operation is invalid, throw an appropriate exception.

            Deque<string> queue = new Deque<string>();

            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.EnqueueStart("Message test for quee");
            queue.Enqueue("Message Four");

            while (queue.Count > 0)
            {
                string msg = queue.Dequeue();
                Console.WriteLine(msg);
            }
        }
    }
}
