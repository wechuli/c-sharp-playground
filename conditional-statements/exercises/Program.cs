using System;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Write an if-statement that takes two integer variables and exchanges their values if the first one is greater than the second one.
            int first = 23;
            int second = 12;
            int initialFirst = first;


            if (first > second)
            {
                first = second;
                second = initialFirst;
                Console.WriteLine($"The first number is now {first} and the second is now {second}");
            }

            // 2. Write a program that shows the sign (+ or -) of the product of three real numbers, without calculating it. Use a sequence of if operators.
            float a = 124.34f;
            float b = 3485.2f;
            float c = 120;
            if ((a * b * c) > 0)
            {
                Console.WriteLine("the sign is + ");
            }
            else if ((a * b * c) == 0)
            {
                Console.WriteLine("the number is zero, no sign");
            }
            else
            {
                Console.WriteLine("The sign is -");
            }

            //3. Use nested if-statements, first checking the first two numbers then checking the bigger of them with the third.
            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine($"{a} is bigger than {b} or {c}");
                }
                else
                {
                    Console.WriteLine($"{c} is bigger than {b} or {a}");
                }

            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine($"{b} is bigger than {a} or {c}");
                }
                else
                {
                    Console.WriteLine($"{c} is bigger than {b} or {a}");
                }
            }

        }
    }
}
