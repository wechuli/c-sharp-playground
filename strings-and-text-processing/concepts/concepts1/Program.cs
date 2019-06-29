using System;

namespace concepts1
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Hello, C#";
            string escaping = "Let us escape some \" we have escaped\" quotes";
            string message = "This is a sample string message";

            Console.WriteLine($"message={message}");
            Console.WriteLine($"message.Length = {message.Length}");
            for (int i = 0; i < message.Length; i++)
            {
                Console.WriteLine($"message[{i}] = {message[i]}");
            }
        }
    }
}
