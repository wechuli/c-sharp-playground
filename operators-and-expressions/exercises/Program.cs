using System;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Write an expression that checks whether an integer is odd or even.
            int number = 35;
            string odd_even = (number % 2) == 0 ? "even" : "odd";
            Console.WriteLine(odd_even);

            //2. Write a Boolean expression that checks whether a given integer is divisible by both 5 and 7, without a remainder.
            bool div5_7 = (number % 5 == 0) && (number % 7 == 0);
            Console.WriteLine(div5_7);

            //3. Write an expression that looks for a given integer if its third digit (right to left) is 7.
            int longnumber = 857645;
            bool third7 = (longnumber / 100) % 10 == 7;
            Console.WriteLine(third7);
        }
    }
}
