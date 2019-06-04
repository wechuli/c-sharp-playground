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

            //In case the fragment is in an unchecked block, an exception will not be thrown and the output result will be wrong. In case these blocks are not used, the C# compiler works in unchecked mode by default
            checked
            {
                int a = int.MaxValue;
                a = a + 1;
                Console.WriteLine(a);
            }
            //C# includes unsigned types, which can be useful when a larger range is needed for the variables in the scope of the positive numbers.
        }
    }
}
