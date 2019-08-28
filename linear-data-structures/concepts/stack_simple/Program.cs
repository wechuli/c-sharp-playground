using System;
using System.Collections.Generic;

namespace stack_simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicolas");
            stack.Push("3. Mary");
            stack.Push("4. George");
            Console.WriteLine("Top = " + stack.Peek());

            while (stack.Count > 0)
            {
                string personName = stack.Pop();
                Console.WriteLine(personName);
            }
        }
    }
}
