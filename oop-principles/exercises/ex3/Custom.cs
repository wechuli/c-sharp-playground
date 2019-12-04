using System;
using System.Collections.Generic;


namespace ex3
{

    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public abstract double CalculateSurface();


    }

    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }
    }
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculateSurface()
        {
            return (this.Width * this.Height);
        }
    }
    public class Circle : Shape
    {

        // Pi*r^2

        public Circle(double radius)
        {
            this.Width = radius;
            this.Height = radius;
        }
        public override double CalculateSurface()
        {
            return (Math.PI * Math.Pow(this.Height, 2));
        }

    }

}