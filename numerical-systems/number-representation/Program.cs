using System;
using System.Numerics;

namespace number_representation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Binary code is used to store data in the operating memory of computing machines. Depending on the type of data we want to store(strings, integers or real numbers with an integral and fractal part), information is represented in a particular manner. it is determined by the data type
            //Bit is a binary unit of information with a value of either 0 or 1
            //Information in the memory is grouped in sequences of 8 bits which form a single byte
            //For an arithmetic device to process the data, it must be presented in the memory by a set number of bytes(2,4 or 8), which form a machine word.

            //Representing Numbers in Memory
            // When numbers are represented with a sign, a signed order is introduced. It is the highest-order and has the value of 1 for negative numbers and the value of 0 for positive numbers. The rest of the orders are informational and only represent(contain) the value of the number. In the case of a number without a sign, all bits are used to represent its value

            //Unsigned Integers
            //for unsigned integers 1,2,4 or 8 bytes are allocated in the memory. Depending on the number of bytes used in the notation of a given number, different scopes of representation with variable size are formed. Through n bits, all integers in the range [0,2^n-1] can be represented.


            //Signed Integers
            //For negative numbers 1,2,4 or 8 bytes are allocated in the memory of the computer, while the highest-order(the left most bit) has a signature meaning and carries the information about the sign of the number.When the signature bit has a value of 1, the number is negative, otherwise it is positive
            //To encode negative numbers, straight, reversed and additional code is used. In all these three notations, signed. In all these three notations, signed integers are within the range: [-2^n-1,2^n-1 -1], positive numbers are always represented in the same way and the straigh, reversed and additional code all coincide for them

            //Straight Code(signed magnitude)
            // The highest-order bit carries the sign and the rest of the bits hold the absolute value of the number

            // byte myNumber = 00001b;
            // Console.WriteLine(myNumber);


            //Reversed code(one's complement)
            //is formed from the signed magintude of the number by inversion(replacing all ones with zeros and vice-versa). This code is not convenient for tha arithmetical operations addition and subtraction because it is executed in a different way if subtraction is necessary.

            //Additional code(two's complement) is a number in reversed code which one is added(through addition)

            // Binary Coded Decimal also known as BCD code , 

            //int
            int integerValue = 25;
            int integerHexValue = 0x002A;
            int y = Convert.ToInt32("1001", 2);
            Console.WriteLine(y);

            //long

            long longValue = 922353666666688666;
            Console.WriteLine(longValue.GetType());
            float twoNums = 0.1f + 0.1f;
            Console.WriteLine(twoNums);

            //In case the fragment is in an unchecked block, an exception will not be thrown and the output result will be wrong. In case these blocks are not used, the C# compiler works in unchecked mode by default
            // checked
            // {
            //     int a = int.MaxValue;
            //     a = a + 1;
            //     Console.WriteLine(a);
            // }
            //C# includes unsigned types, which can be useful when a larger range is needed for the variables in the scope of the positive numbers.



            //The Float and Double Types in C#
            //In C#, we have at our disposal two types, which can represent floating-point numbers.

            float total = 5.0f;
            float result = 5.0f;
            double sum = 10.0;
            double div = 35.4 / 3.0;
            double x = 5d;

            Console.WriteLine(sum.GetType());

            // In C#, floating-point numbers literals by default are of the double type

            //Not every real number has an exact representation in the IEEE 754 format, because not each number can be presented as a polynomial of a finite number of addends, which are negative powers of two

            float sumF = 0f;

            for (int i = 0; i < 1000; i++)
            {
                sumF += 0.1f;
            }
            Console.WriteLine(sumF);


            double sumD = 0.0;
            for (int i = 1; i <= 10; i++)
            {
                sumD += 0.1;
            }
            Console.WriteLine("{0:r}", sumD);
            Console.WriteLine(sumD);

            // By default, when printing floating-point numbers in .NET Framework, they are rounded, which seemingly reduces the errors in their inaccurate notation in the IEEE 754 format. The result of the calculation is wrong but after rounding, it looks correct. However, if we add 0.1 a several thousand times, the error will accumulate and the rounding will not be able to compensate it.

            float sumF2 = 0.0f;
            for (int i = 1; i <= 10; i++)
            {
                sumF2 += 0.1f;
            }
            Console.WriteLine("{0:r}", sumF2);

            //Double and Float types have a field called Epsilon, which is aconstant, and it contains the smallest value larger than zero, which can be represented by an inctance of  System.Single or System.Double respectively. Each value smaller than Epsilon is considered to be equal to 0;

            //The Decimal Type
            //this is tens of times slower than double, but is irreplaceable for the execution of financial calculations

            decimal calc = 20.4m;

            decimal sumDecimal = 0.0m;
            double sumDouble = 0.0;

            for (int i = 1; i <= 10000000; i++)
            {
                sumDecimal += 0.0000001m;
                sumDouble += 0.0000001;
            }
            Console.WriteLine(sumDecimal);   //this will be accurate
            Console.WriteLine(sumDouble);   //this will be inacurate


            //Even though the decimal type has a higher precision than the floating-point types, it has a smaller value range and, for example, it cannot be used to represent the following value 1e-50. As a result, an overflow may occur when converting from floating-point numbers to decimal.

            //Character Type

            char ch = 'A';
            char ch2 = 'B';

            Console.WriteLine((int)ch);
            Console.WriteLine((int)ch2);
        }
    }
}
