using System;

namespace access_static_non_static
{
    public class Circle
    {
        public static double PI = 3.141592653589793;
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public static double CalculateSurface(double radius)
        {
            return (Circle.PI * radius * radius);
        }
        public void PrintSurface()
        {
            double surface = CalculateSurface(radius);
            Console.WriteLine("Circle's surface is: " + surface);

        }
    }
}