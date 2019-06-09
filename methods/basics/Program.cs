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

            //arrays
            int[] arrArg = new int[] { 1, 2, 3 };
            Console.Write("Before ModifyArray() the argument is: ");
            PrintArray(arrArg);
            // Modifying the array's argument
            ModifyArray(arrArg);
            Console.Write("After ModifyArray() the argument is: ");
            PrintArray(arrArg);
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

        //Functions of reference types

        public static void ModifyArray(int[] arrParam)
        {
            arrParam[0] = 5;
            Console.WriteLine("In ModifyArray() the param is: ");
            PrintArray(arrParam);
        }
        public static void PrintArray(int[] arrParam)
        {
            Console.Write("[");
            int length = arrParam.Length;

            if (length > 0)
            {
                Console.Write(arrParam[0].ToString());
                for (int i = 1; i < length; i++)
                {
                    Console.Write($",{arrParam[i]}");
                }
            }
            Console.WriteLine("]");
        }
    }
}
