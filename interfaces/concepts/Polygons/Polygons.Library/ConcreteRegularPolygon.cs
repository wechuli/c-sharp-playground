using System;

namespace Polygons.Library
{
    public class ConcreteRegularPolygon
    {
        public int NumberOfSides { get; set; }
        public double SideLength { get; set; }

        public ConcreteRegularPolygon(int sides,double length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }
        public virtual double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
