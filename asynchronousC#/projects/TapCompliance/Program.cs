using System;
using System.Threading.Tasks;

namespace TapCompliance
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var tapComplianceObj = new TapComplianceClass();

            var result = await tapComplianceObj.SellSomeCoinAsync("Fake Auth", 5);


            Console.WriteLine(result.resultString);
            Console.WriteLine(result.currentMarketPrice);

            var syncResult = tapComplianceObj.SellSomeCoin("empty", 5, out int currentMarketPrice);

            Console.WriteLine(syncResult);
            Console.WriteLine(currentMarketPrice);

        }
    }
}
