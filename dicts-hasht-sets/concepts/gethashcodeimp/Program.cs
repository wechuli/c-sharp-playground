using System;
using System.Collections.Generic;

namespace gethashcodeimp
{
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Point3D(2.5, 2.6, 2.7);
            var point2 = new Point3D(2, 1, 0);
            var point3 = new Point3D(1, 2, 3);
            var point4 = new Point3D(2.5, 2.6, 2.7);

            Console.WriteLine(point1.GetHashCode());
            Console.WriteLine(point2.GetHashCode());
            Console.WriteLine(point3.GetHashCode());
            Console.WriteLine(point4.GetHashCode());
            Console.WriteLine(point2.Equals(point3));
            Console.WriteLine(point1.Equals(point4));


            IEqualityComparer<Point3D> comparer = new Point3DEqualityComparer();
            Dictionary<Point3D, int> dict = new Dictionary<Point3D, int>(comparer);
            dict[new Point3D(4, 2, 5)] = 5;
            dict[new Point3D(1, 2, 3)] = 1;
            dict[new Point3D(3, 1, -1)] = 3;
            dict[new Point3D(1, 2, 3)] = 10;
            foreach (var entry in dict)
            {
                Console.WriteLine("{0} --> {1}", entry.Key, entry.Value);
            }



        }
    }

    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public override string ToString()
        {
            return $"{this.X},{this.Y},{this.Z}";
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            Point3D other = obj as Point3D;
            if (other == null)
            {
                return false;
            }
            if (this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;
            unchecked
            {
                result = result * prime + X.GetHashCode();
                result = result * prime + Y.GetHashCode();
                result = result * prime + Z.GetHashCode();
            }

            return result;
        }
    }
    public class Point3DEqualityComparer : IEqualityComparer<Point3D>
    {
        public bool Equals(Point3D point1, Point3D point2)
        {
            if (point1 == point2) return true;
            if (point1 == null || point2 == null) return false;
            if (!point1.X.Equals(point2.X)) return false;
            if (!point1.Y.Equals(point2.Y)) return false;
            if (!point1.Z.Equals(point2.Z)) return false;
            return true;
        }
        public int GetHashCode(Point3D obj)
        {
            Point3D point = obj as Point3D; if (point == null) { return 0; }
            int prime = 83;
            int result = 1; unchecked { result = result * prime + point.X.GetHashCode(); result = result * prime + point.Y.GetHashCode(); result = result * prime + point.Z.GetHashCode(); }
            return result;
        }
    }
}
