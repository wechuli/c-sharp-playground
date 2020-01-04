using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
    public class Square:ConcreteRegularPolygon
    {
        public Square(double length):base(4,length)
        {

        }
        public override double GetArea()
        {
            return SideLength * SideLength;
        }
    }
}
