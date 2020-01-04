using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
    public class Octagon:IRegularPolygon
    {
        public int NumberOfSides { get; set; }
        public double SideLength { get; set; }


        public Octagon(double length)
        {
            NumberOfSides = 8;
            SideLength = length;
        }

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }
        public double GetArea()
        {
            return SideLength * SideLength * (2 + 2 * Math.Sqrt(2));
        }
    }
}
