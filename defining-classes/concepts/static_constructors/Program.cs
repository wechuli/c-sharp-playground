using System;

namespace static_constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SqrtPrecalculated.GetSqrt(254));

        }
    }

    static class SqrtPrecalculated
    {
        public const int MaxValue = 1000;
        //static field
        private static int[] sqrtValues;


        //static Constructor
        static SqrtPrecalculated()
        {
            sqrtValues = new int[MaxValue + 1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = (int)Math.Sqrt(i);
            }
        }

        // Static method
        public static int GetSqrt(int value)
        {
            if ((value < 0) || (value > MaxValue))
            {
                throw new ArgumentOutOfRangeException(String.Format(
                    "The argument should be in range [0...{0}].",
                MaxValue));
            }
            return sqrtValues[value];
        }

    }
}
