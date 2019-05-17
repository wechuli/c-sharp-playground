using System;
using System.Numerics;

namespace do_while
{
    class do_while
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = Int32.Parse(Console.ReadLine());

            //BigInteger can be used to represent very large integres(limited only by size of the memory)
            //Found in the System.Numerics namespace
            BigInteger factorial = 1;
            do
            {
                factorial *= n;
                n--;
            } while (n > 0);
            Console.WriteLine($"n! = {factorial}");

            //Always beeware of hidden integer overflow


        }
    }
}