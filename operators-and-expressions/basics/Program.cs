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

            //Comparison Operators
            // Comparion operators in C# are used to compare two or more operands.
            //All comparion operators in C# are binary(take two operands) and the returned result is a Boolean value(true or false)

            int x = 10, y = 5; Console.WriteLine("x > y : " + (x > y)); // True 
            Console.WriteLine("x < y : " + (x < y)); // False 
            Console.WriteLine("x >= y : " + (x >= y)); // True 
            Console.WriteLine("x <= y : " + (x <= y)); // False 
            Console.WriteLine("x == y : " + (x == y)); // False 
            Console.WriteLine("x != y : " + (x != y)); // True


            //Assignement Operators
            // '='
            //cascade asignmenent
            int xa, ya, za;
            xa = ya = za = 25; //cascade
            Console.WriteLine(xa);
            Console.WriteLine(ya);
            Console.WriteLine(za);

            //Compound Assignement Operators
            int xc = 6;
            int yc = 4;

            xc *= yc; // Same as xc = xc * yc;
            Console.WriteLine(xc);  //24
            int zc = yc = 3;
            Console.WriteLine(zc);
            Console.WriteLine(xc |= 1); //bitwise operation xc = xc | 1
            Console.WriteLine(xc += 3);
            Console.WriteLine(xc /= 2);

            //Conditional Operator(ternary)
            //Uses the Boolean value of an expression to determine of two other expressions must be calculated and returned as a result

            int ab = 6;
            int bb = 4;

            Console.WriteLine(ab > bb ? "ab>bb" : "bb<=ab");
            int num = ab == bb ? 1 : -1;
            Console.WriteLine(num);  //num will be -1

            //The '.' Operator
            //The access operator  "." (dot) is used to access the member fields or methods of a class or object
            Console.WriteLine(DateTime.Now);

            //Square Brackets[] Operator
            //square brackets are used to access elements of an array by index

            int[] arr = { 1, 2, 3 };
            Console.WriteLine(arr[1]);
            string str = "Hello";
            Console.WriteLine(str[2]);

            //Operator "??"
            //The operator ?? is similar to the conditional operator ?: The difference is that it is placed between two operands and returns the left opoerand only if its value is not null, otherwise it returns the right operand

            int? an = 5;
            Console.WriteLine(an ?? -1); //5
            string name = null;
            Console.WriteLine(name ?? "(no name)"); // (no name)
            /*
            
             */


        }
    }
}
