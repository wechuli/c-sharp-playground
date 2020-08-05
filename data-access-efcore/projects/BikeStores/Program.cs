using System;
using System.Threading.Tasks;
using BikeStores.Models;


namespace BikeStores
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using (var bikeStoresContext = new BikeStoresContext())
            {

                // await Querying.Sorting(bikeStoresContext);
                await Querying.Paging(bikeStoresContext);

            }



        }
    }
}
