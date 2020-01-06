using System;

namespace lambdas_delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<bool> boolFunc = () => true;
            Func<int, bool> intFunc = (x) => x < 10;

            if (boolFunc() && intFunc(5))
            {
                Console.WriteLine("5 < 10");
            }
        }
    }
}
