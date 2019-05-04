using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Operators allow processing of primitive data types and objects. They take as input one or more operands and return some value as a result
            //-Arithmetics
            //-Assignement
            //-Comparison
            //-Logical
            //-Binary
            //-Type conversion

            int a = 7 + 9;
            Console.WriteLine(a);

            string firstName = "John";
            string lastName = "Doe";
            string fullName = firstName + " " + lastName;
            Console.WriteLine(fullName);

            //Arithmetics Operators
            int squarePerimeter = 17;
            double squareSide = squarePerimeter / 4.0;
            double squareArea = squareSide * squareSide;

            Console.WriteLine(squareSide);
            Console.WriteLine(squareArea);

            int c = 5;
            int d = 8;
            // Console.WriteLine(d + (++c));
            Console.WriteLine(d + (c++));

            //Logical Operators
            //Logical (Boolean) operators take Boolean values and return a Boolean result(true or false)
            bool at = true;
            bool bt = false;

            Console.WriteLine(at && bt);
            Console.WriteLine(at || bt);
            Console.WriteLine(!bt);
            Console.WriteLine(bt || true);
            Console.WriteLine((5 > 7) ^ (at == bt));


        }
    }
}
