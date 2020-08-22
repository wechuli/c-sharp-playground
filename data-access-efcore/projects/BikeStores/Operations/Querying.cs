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


            // order by ascending
            var customers = bikeStoresContext.Customers.OrderBy(customer => customer.FirstName).Take(5);

            ConsoleTable.From(customers).Write();

            // order by descending

            var staffs = bikeStoresContext.Staffs.OrderByDescending(staff => staff.StaffId).Take(5).Select(staff => new { staff.StaffId, staff.FirstName, staff.LastName, staff.Email, staff.Phone });
            ConsoleTable.From(staffs).Write();

            // combine multiple ordering parameters

            var stores = from s in bikeStoresContext.Stores
                         orderby s.City ascending, s.StoreName descending
                         select new { s.StoreId, s.StoreName, s.Phone, s.Email, s.Street, s.City, s.State, s.ZipCode };

            ConsoleTable.From(stores).Write();

        }


        public static async Task Paging(BikeStoresContext bikeStoresContext)
        {

            //using Take and Skip to page through the results
            var customers = (from c in bikeStoresContext.Customers
                             orderby c.CustomerId
                             select new { c.CustomerId, c.FirstName, c.LastName, c.Phone, c.Email }).Skip(10).Take(10);

            ConsoleTable.From(customers).Write();


        }

        public static async Task QueryingRelatedData(BikeStoresContext bikeStoresContext)
        {
            var customer_one = bikeStoresContext.Customers.Single(customer => customer.CustomerId == 1);

            var ordersByOne = bikeStoresContext.Orders.Where(order => order.CustomerId == customer_one.CustomerId).Include(order => order.Customer);
            Console.WriteLine(ordersByOne.Count());

            foreach (var item in ordersByOne)
            {
                var customer = item.Customer;
                Console.WriteLine($"{customer.CustomerId}, {customer.Email}");

            }

            ConsoleTable.From(ordersByOne).Write();

        }

        public static async Task RawSQLQueries(BikeStoresContext bikeStoresContext)
        {
            var AllOrders = bikeStoresContext.Orders.FromSqlRaw("SELECT * from sales.orders").Take(10);


            ConsoleTable.From(AllOrders).Write();



        }
    }
}