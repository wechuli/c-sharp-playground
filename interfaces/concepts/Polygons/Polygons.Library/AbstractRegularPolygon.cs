using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
   public abstract class AbstractRegularPolygon
    {
        public int NumberOfSides { get; set; }
        public double SideLength { get; set; }

        public AbstractRegularPolygon(int sides, double length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }
        public abstract double GetArea();
 
    }
}
