using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRectangleArea(12, 10));
            UselessPrint();
            PrintLogo("My Logo");
            decimal[] prices = { 12, 33, 23, 23, 12, 22 };
            PrintTotalAmountForBooks(prices);

            int numberArg = 3;
            Console.WriteLine($"Number before {numberArg}");
            PrintNumner(numberArg);
            Console.WriteLine($"Number after {numberArg}");

        }

        static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }
        private static void UselessPrint()
        {
            Console.WriteLine("This is a fake print");
        }

        public static void PrintLogo(string logo)
        {
            Console.WriteLine(logo);
        }

        public static void PrintTotalAmountForBooks(decimal[] prices)
        {
            decimal totalAmount = 0;
            foreach (decimal singleBookPrice in prices)
            {
                totalAmount += singleBookPrice;
            }
            Console.WriteLine($"The total amount for all books is: {totalAmount}");
        }

        static void PrintNumner(int number)
        {
            //Modifying the primitive-type parameter
            number = 5;
            Console.WriteLine(number);
        }
    }
}
