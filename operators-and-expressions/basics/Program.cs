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

            //Bitwise Operators
            // a bitwise operaot is an operator that acts on the binary representation of numeric types
            //The bit shift left(<<) and bit shift right(>>) are used on numerical values, they move all the bits of the value to the left or right

            byte aByte = 3; // 0000 0011 = 3
            byte bByte = 5; // 0000 0101 = 5

            Console.WriteLine(aByte | bByte);  //0000 0111 = 7
            Console.WriteLine(aByte & bByte);  //0000 0001 = 1
            Console.WriteLine(aByte ^ bByte);  //0000 0110 = 6
            Console.WriteLine(~aByte & bByte);  //0000 0100 = 4
            Console.WriteLine(aByte << 1);  //0000 0110 = 6
            Console.WriteLine(aByte << 2);  //0000 1100 = 12
            Console.WriteLine(aByte >> bByte);  //0000 0000 = 0



        }
    }
}
