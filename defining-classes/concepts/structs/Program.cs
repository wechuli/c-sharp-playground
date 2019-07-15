using System;

namespace structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    struct Point2D
    {
        private double x;
        private double y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

    }
}
