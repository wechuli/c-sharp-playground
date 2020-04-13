using System;
using System.Threading.Tasks;


namespace TapPatterns
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start !");
            var manager = new TapPatternManager();
            await manager.LaunchAsync();
            Console.ReadLine();
        }

        // static void Main(string[] args)
        // {
        //     Console.WriteLine("Start !");
        //     var manager = new TapPatternManager();
        //     manager.Launch();
        //     Console.ReadLine();
        // }



    }
}
