using System;

namespace explicitInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare a class instance box1:
            Box box1 = new Box(30.0f, 20.0f);

            // Declare an instance of the English units interface:
            IEnglishDimensions eDimensions = box1;

            // Declare an instance of the metric units interface:
            IMetricDimensions mDimensions = box1;

            // Print dimensions in English units:
            System.Console.WriteLine("Length(in): {0}", eDimensions.Length());
            System.Console.WriteLine("Width (in): {0}", eDimensions.Width());

            // Print dimensions in metric units:
            System.Console.WriteLine("Length(cm): {0}", mDimensions.Length());
            System.Console.WriteLine("Width (cm): {0}", mDimensions.Width());
        }
    }

    // Declare the English unit interface
    interface IEnglishDimensions
    {
        float Length();
        float Width();
    }

    // Declare the metric units interface
    interface IMetricDimensions
    {
        float Length();
        float Width();
    }
    // Declare the Box class that implements the two interfaces
    // IEnglishDimensions and IMetricDimensions

    class Box : IEnglishDimensions, IMetricDimensions
    {
        private float lengthInches;
        private float widthInches;


        public Box(float lengthInches, float widthInches)
        {
            this.lengthInches = lengthInches;
            this.widthInches = widthInches;
        }

        // Explicityly implement the members of IEnglishDimension:
        float IEnglishDimensions.Length() => this.lengthInches;

        float IEnglishDimensions.Width() => this.widthInches;

        // Explicitly implement the members of IMetricDimensions

        float IMetricDimensions.Length() => lengthInches * 2.54f;
        float IMetricDimensions.Width() => widthInches * 2.54f;
    }
}
