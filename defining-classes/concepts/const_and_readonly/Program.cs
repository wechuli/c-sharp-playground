using System;

namespace const_and_readonly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PI);
            Console.WriteLine(ConstAndReadOnlyExample.PI);
            ConstAndReadOnlyExample instance =
            new ConstAndReadOnlyExample(5);
            Console.WriteLine(instance.Size);
            // Compile-time error: cannot access PI like a field
            Console.WriteLine(instance.PI);
            // Compile-time error: Size is instance field (non-static)
            Console.WriteLine(ConstAndReadOnlyExample.Size);
            // Compile-time error: cannot modify a constant
            ConstAndReadOnlyExample.PI = 0;
            // Compile-time error: cannot modify a readonly field
            instance.Size = 0;
        }
    }

    public class ConstAndReadOnlyExample
    {
        public const double PI = 3.1415926535897932385;
        public readonly double size;

        public ConstAndReadOnlyExample(int size)
        {
            this.size = size;
        }

    }
}
