using System;

namespace basics_part3
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething("1", "2");
            DoSomething(1, 2);
        }

        //Method overloading

        public static void DoSomething(string param1, string param2)
        {
            string newString = param1 + param2;
            Console.WriteLine($"Adding the two string gives {newString}");
        }
        public static void DoSomething(int number1, int number2)
        {
            int result = number1 + number2;
            Console.WriteLine($"Adding the two numbers gives {result}");

        }
    }
}
