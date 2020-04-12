using System;

namespace TapPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start !");
            var manager = new TapPatternManager();
            manager.Launch();
            Console.ReadLine();
        }
    }
}
