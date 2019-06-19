using System;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Write a program which calculates the area of a triangle with the following given:
            // - three sides;
            // - side and the altitude to it;
            // - two sides and the angle between them in degrees.
            Console.WriteLine($"{CalculateTriangleArea(7.0, 3.0, 4.0)}");


        }

        static double CalculateTriangleArea(double side1, double side2, double side3)
        {
            double p = (side1 + side2 + side3) / 2.0;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        static double CalculateTriangleArea(double side, double altitude)
        {
            return (side * altitude) / 2.0;
        }
        static double TriangleFromDegress(double side1, double side2, double angleInDegrees)
        {
            double angle = Math.PI * angleInDegrees / 180.0;
            double sinAngle = Math.Sin(angle);

            return (side1 * side2 * sinAngle) / 2.0;
        }
    }
}
