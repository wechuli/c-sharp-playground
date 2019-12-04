using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {

            Circle myCircle = new Circle(7);
            Rectangle myRectangle = new Rectangle(10, 10);
            Triangle triangle = new Triangle(10, 10);

            Console.WriteLine($"Circle: {myCircle.CalculateSurface()}");
            Console.WriteLine($"Rectangle: {myRectangle.CalculateSurface()}");
            Console.WriteLine($"Triangle: {triangle.CalculateSurface()}");

        }
    }
}
