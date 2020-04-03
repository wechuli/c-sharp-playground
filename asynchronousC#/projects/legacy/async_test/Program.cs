using System;
using System.Threading.Tasks;

namespace async_test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fetchter = new TestClass();
            int numberOfCharacters = await fetchter.AccessTheWebAsync();
            Console.WriteLine(numberOfCharacters);
        }
    }
}
