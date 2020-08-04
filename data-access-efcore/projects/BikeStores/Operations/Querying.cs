using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BikeStores.Models;
using ConsoleTables;


namespace BikeStores
{
    public static class Querying
    {
        public static async Task Sorting(BikeStoresContext bikeStoresContext)
        {

            var customers = bikeStoresContext.Customers.OrderBy(customer => customer.FirstName).Take(10);

            ConsoleTable.From(customers).Write();


        }
    }
}