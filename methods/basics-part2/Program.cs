using System;

namespace basics_part2
{
    class Program
    {
        static void Main(string[] args)
        {

            float oldQuantity = 3L;
            float newQuantity = 2L;

            float result = returnMax(2, 3);

            Console.WriteLine(returnMax(oldQuantity * 3, newQuantity * 4));
            Console.WriteLine(result.GetType());

            //Params
            long sum = CalcSum(2, 5);
            Console.WriteLine(sum);
            long sum2 = CalcSum(1, 2, 3, 5, 6, 8, 6, 6);
            Console.WriteLine(sum2);
            long sum3 = CalcSum(85);
            Console.WriteLine(sum3);

            doSomething("My hello message", 1, 2, 3, 6, 8);

            //default parameters
            int summation = Summation(1);
            int summation2 = Summation(1, 10);
            int summation3 = Summation(1, 10, 10);
            Console.WriteLine($"Summation: {summation}");
            Console.WriteLine($"Summation2: {summation2}");
            Console.WriteLine($"Summation3: {summation3}");

            //Named arguments

            int summation4 = Summation(8, z: 10, y: 10);
            Console.WriteLine($"Summation4: {summation4}");
            int summation5 = Summation(z: 10, y: 100, x: 1);
            Console.WriteLine($"Summation5: {summation5}");
        }

        public static float returnMax(float oldNumber, float newNumber)
        {
            if (oldNumber > newNumber)
            {
                return oldNumber;
            }
            return newNumber;
        }

        //Accepting Multiple params

        public static long CalcSum(params int[] elements)
        {
            long sum = 0;
            foreach (var item in elements)
            {
                sum += item;
            }
            return sum;
        }

        // params with other params

        private static void doSomething(string sayHello, params int[] otherRandomNumbers)
        {
            Console.WriteLine(sayHello);
            for (int i = 0; i < otherRandomNumbers.Length; i++)
            {
                Console.WriteLine(otherRandomNumbers[i]);
            }
        }

        //Default/Optional params

        public static int Summation(int x, int y = 1, int z = 2)
        {
            return x + y + z;
        }
    }
}
