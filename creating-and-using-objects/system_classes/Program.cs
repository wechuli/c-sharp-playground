using System;

namespace system_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int startTime = Environment.TickCount; //The static property TickCount of the class Environment returns as a result the count of milliseconds that hae passed since the computer is on until the time of the method call.

            //The code fragment to be tested
            for (int i = 0; i < 10000000; i++)
            {
                sum++;
            }
            int endTime = Environment.TickCount;
            Console.WriteLine($"The time elapsed in seconds is {(endTime - startTime) / 1000.0}");
            Console.WriteLine(Math.PI.GetType());
            

            Random rand = new Random();
            double randNumber;
            int randInt;
            for (int i = 0; i < 100; i++)
            {
                randNumber = rand.NextDouble();
                randInt = rand.Next(1, 49);
                Console.WriteLine($"Random Double = {randNumber} , Random Integer btw 1 and 49 = {randInt}");
            }
        }
    }
}
