using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comparison operators can be used to compare expressions such as two numbers, two numerical expressions, or a number and a variable.The result of the comparison is a Boolean value(true or false)
            int weight = 700;
            Console.WriteLine(weight >= 500); //True
            char gender = 'm';
            Console.WriteLine(gender <= 'f');   //False

            //The numbers are compared by size while characters are compared by their lexicographical order.
            //data types that can be compared
            // numbers (int,long,float,double,ushort,decimal)
            //characters(char)
            //Booleans(bool)
            //References to objects, also known as object pointers(string, object, arrays )


            //When comparing integers and characters, we directly compare their binary representation in memory i.e we compare their values

            Console.WriteLine("char 'a' == 'a'? " + ('a' == 'a')); // True
            Console.WriteLine("char 'a' == 'b'? " + ('a' == 'b')); // False
            Console.WriteLine("5 != 6? " + (5 != 6)); // True
            Console.WriteLine("5.0 == 5L? " + (5.0 == 5L)); // True
            Console.WriteLine("true == false? " + (true == false)); // False


            //In .NET Framework, there are reference data types that do not contain their value(unlike the value types), but contain address of the memory in the heap where thier value is located
        }
    }
}
