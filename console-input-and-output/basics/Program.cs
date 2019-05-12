using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {

            // The Console is a windows of the operating system through which users can interact with the system programs of the operating system or with other console applications.The interaction consists of text input from the standard input(usually keyboard) or text dispplay on the standard output
            Console.WriteLine("Hello World!");

            Console.Write("Please enter your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Please enter your last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine($"Hello, {firstName}, {lastName}");

            //The method Read() behaves slighlty different than ReadLine(). It reads only one character and not the entire line.The other difference is that the method does not return directly the read charcter but its code.If we want to use the result as a charcter, we must convert it to a character or use the method Convert.ToChar() on it.
            // int codeRead = 0;
            // do
            // {
            //     codeRead = Console.Read();
            //     if (codeRead != 0)
            //     {
            //         Console.Write((char)codeRead);
            //     }
            // } while (codeRead != 10);

            //All primitive types have methods for parsing

            //Conditional parsing
            string str = Console.ReadLine();
            int intValue;
            bool parseSuccess = Int32.TryParse(str, out intValue);
            Console.WriteLine(parseSuccess ? $"The square of the number is {intValue * intValue}" : "Invalid number!");

            //Console.ReadKey()
            // The method Console.ReadKey() waits for key pressing on the console and reads its chracter equivalent without need of pressing enter.

            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Character entered: ", key.KeyChar);
            Console.WriteLine("Special keys: ", key.Modifiers);

            //
            NewClass fake = new NewClass();
            fake.test();
        }
    }
}
