using System;
using System.Linq;
using ConsoleTableExt;


namespace BikeStoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new BikeStoresContext())
            {

                var customers = dbContext.Customers.Take(10).ToList();

                var tableBuilder = ConsoleTableBuilder.From(customers);
                tableBuilder.ExportAndWriteLine();




            }
            
        }
    }
}
