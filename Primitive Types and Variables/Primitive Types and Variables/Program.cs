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
            Console.WriteLine(centuries);
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

            int a = 1;
            int b = 2;
            //Which one is greater
            bool greaterAB = (a > b);
            //Is 'a' equal to 1?
            bool equalA1 = (a == 1);


            if (greaterAB)
            {
                Console.WriteLine("A>B");
            }
            else
            {
                Console.WriteLine("A<=B");
            }

            // Character Type
            //Character type is a single character(16-bit number of a Unicode table character)
            char ch = 'a';
            Console.WriteLine($"The code of {ch} is {(int)(ch)}");

            //Strings
            //Strings are sequences of characters. They are declared by the keyword string

            string firstName = "Paul";
            string lastName = "Wechuli";
            string fullName = firstName + " " + lastName;

            Console.WriteLine($"Hello {firstName}!");
            Console.WriteLine($"Your Full name is {fullName}.");

            //Object Type
            //Object type is a special type, which is the parent of all other types in the .NET Framework.Declared with the keyword object, it can take values from any other type. It is a reference type

            object container1 = 5;
            object container2 = "Five";
            Console.WriteLine($"The value of container1 is: {container1}");
            Console.WriteLine($"The value of container2 is: {container2}");

            //Nullable Types
            //Nullable types are specific wrappers around the value types(as int, double and bool) that allow storing data with a null value.This provides opportunity for types that generally do not allow lack of value. Nullable types are used for storing information which is not mandatory

            int i = 5;
            int? ni = 6;
            Console.WriteLine(ni);

            // i = ni; //this will fail to compile
            Console.WriteLine(ni.HasValue);
            i = ni.Value;
            Console.WriteLine(i);


            ni = null;
            Console.WriteLine(ni.HasValue);
            // i = ni.Value; //System.InvalidOperationException
            i = ni.GetValueOrDefault();
            Console.WriteLine(i);
        }
    }
}
