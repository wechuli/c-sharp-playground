using System;

namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int stop = 100;
            int[] values = new int[10];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = ReadNumber(start, stop);
            }
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }

        public static int ReadNumber(int start, int end)
        {
            int number;
            Console.Write("Please insert your integer: ");
            try
            {
                number = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                throw new Exception("Entered number not an integer", e);
            }

            if (number < start || number > end)
            {
                throw new ApplicationException("Value is outside that range");
            }
            return number;
        }
    }
}
