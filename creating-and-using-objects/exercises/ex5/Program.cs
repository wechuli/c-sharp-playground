using System;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program which by given two sides finds the hypotenuse of a right triangle. Implement entering of the lengths of the sides from the standard input, and for the calculation of the hypotenuse use methods of the class Math.
            Console.Write("Please enter the first side of the right angled triangle: ");
            double right = Int64.Parse(Console.ReadLine());
            Console.Write("Please enter the left side of the right angled triangle: ");
            double left = Int64.Parse(Console.ReadLine());

            Console.WriteLine($"The hypotenuse is:{ReturnHypotenese(right, left)}");


        }

        static double ReturnHypotenese(double side1, double side2)
        {
            return Math.Round(Math.Sqrt((Math.Pow(side1, 2.0) + Math.Pow(side2, 2.0))), 4);
        }
    }
}
