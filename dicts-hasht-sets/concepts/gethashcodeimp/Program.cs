using System;

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
}
