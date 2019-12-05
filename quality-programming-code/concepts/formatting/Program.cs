using System;
using System.Collections.Generic;

namespace formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(CalculateCircumference(7, 9));

        }
        public static double CalculateCircumference(double radius, int fakeParam)
        {
            return 2 * Math.PI * radius;
        }
    }
}
