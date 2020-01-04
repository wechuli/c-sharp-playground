using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
    public class Triangle:AbstractRegularPolygon
    {

        public Triangle(double length):base(3,length)
        { }

        public override double GetArea()
        {
            return SideLength * SideLength * Math.Sqrt(3) / 4;
        }

    }
}
