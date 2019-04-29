using System;
// Interger types - sbyte,byte,short,ushort,int,uint,long,ulong
// Real floating-point types - float,double
//Real type with decimal precision - decimal
//Boolean type - bool
//Character type - char
//String - string
//Object type - object

//These data types are called primitive(built-in types), because they are embedded in C# language at the lowest level.

namespace Primitive_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centuries = 20;
            ushort years = 2000;
            uint days = 730480;
            ulong hours = 17531520;

            //Not all real numbers have accurate representation in float and double types
            float floatPI = 3.14f;
            Console.WriteLine(floatPI);
            double doublePI = 3.14;
            Console.WriteLine(doublePI);

            //Notice the 'm' at the end of a decimal declaration
            decimal decimalPI = 3.14159265358979323846m;
            Console.WriteLine(decimalPI);

            //The main difference between real floating-point numbers and real numbers with decimal precision is the accuracy of calculations and the extent to which they round up the stored values
            
            double nan = Double.NaN;
            Console.WriteLine(nan);
            double infinity = Double.PositiveInfinity;
            Console.WriteLine(infinity);
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{centuries} centuries are {years} years, or {days} days, or {hours} hours");
        }
    }
}
