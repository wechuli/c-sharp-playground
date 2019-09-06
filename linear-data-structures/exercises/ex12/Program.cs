using System;

namespace ex12
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a DynamicStack<T> class to implement dynamically a stack (like a linked list, where each element knows its previous element and the stack knows its last element). Add methods for all commonly used operations like Push(), Pop(), Peek(), Clear() and Count.

            CustomStack<string> stack = new CustomStack<string>();

            stack.Push("1. John");
            stack.Push("2. Nicolas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Console.WriteLine("Top = " + stack.Peek());
            Console.WriteLine(stack.Count());

            while (stack.Count() > 0)
            {
                string personName = stack.Pop();
                Console.WriteLine(personName);
            }
            Console.WriteLine(stack.Count());
            stack.Pop();
        }
    }
}
