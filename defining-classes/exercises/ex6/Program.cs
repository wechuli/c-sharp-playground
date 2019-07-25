using System;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fraction.Parse("3.3423ew"));
        }
    }

    class Fraction
    {
        public double RationalNumber { get; set; }
        public Fraction(string stringFraction)
        {

        }
        public static double Parse(string stringFraction)
        {
            double parsedFraction;
            
            try
            {
                parsedFraction = Double.Parse(stringFraction);
            }
            catch (System.Exception e)
            {

                throw new Exception("Cannot parse the given string", e);
            }
            return parsedFraction;
        }
    }
}
