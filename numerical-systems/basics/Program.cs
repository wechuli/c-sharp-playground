using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Numerical Systems are a way of representing numbers by a finite type-set of hraphical signs called digits
            //The binary numerical system is the system which is used to represent and process numbers in modern computing machines. The main reason it is so widespread is explained with the fact that devices with two stable states are very simple to implement and the prooduction costs of binary arithmetic devices are very low
            //the binary digits 0 and 1 can be easily represented in the computing machines as 'current' and 'no current' or as +5 and -5V

            //The sequence of eight zeros or ones represents one byte, an ordinary eight bit binary number. All numkbers from 0 to 255 including can be represented in a sinle byte. In most cases this is not enough; as a result, several consecutive bytes can be used to represent a big number.

            int a = 3;
            int b = 4;

            int result = a & b;
            Console.WriteLine(result);
            Console.WriteLine(a ^ b); //Bitwise XOR
            Console.WriteLine(~a);
            Console.WriteLine(~b);


            //Hexadecimal numbers
            //with hexadecimal numbers we have number 16 for a system base A=10,B=11,C=12,D=13,E=14,F=15
            //The fast conversion from binary to hexadecimal numbers can be quickly and easilty done by dividing the binary number into groups of four bits(splitting it into half-bytes). If the number of digits is not divisible by four, leading zeros in the highest-orders are added.After the division and the eventual addition of zeros all the groups are placed in theis corresponding digits

            //Transitioning from a decimal to a k-based numeral system is done by consecutively dividing the decimal to the base of the k system and the remainders (their corresponding digit in the k based system) are accumulated in reverse order

            //Transitioning from a k-based numeral system to decimal is done by multiplying the last digit of the k-based number by k0, the one before it by k1, the next one by k2 and so on, and the products are the added up.

            //Transitioning from a k-based numeral system to a p-based numeral system is done by intermediately converting to the decimal system (excluding hexadecimal and binary numeral systems).

            //Transitioning from a binary to hexadecimal numeral system and back is done by converting each sequence of 4 binary bits into its corresponding hexadecimal number and vice versa.


        }
    }
}
