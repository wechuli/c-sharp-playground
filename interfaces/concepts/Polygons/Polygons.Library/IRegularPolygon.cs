using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
public interface IRegularPolygon
    {
        int NumberOfSides { get; set; }
        double SideLength { get; set; }
        double GetPerimeter();
        double GetArea();

    }
}
