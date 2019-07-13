using System;

namespace properties_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Point myPoint = new Point(2, 3);
            double myPointXCoord = myPoint.X;
            double myPointYCoord = myPoint.Y;

            Console.WriteLine("The X coordinate is: " + myPointXCoord);
            Console.WriteLine("The Y coordinate is: " + myPointYCoord);
        }
    }

    class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double x
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}
