using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PhysicalProductModel> cart = AddSampleData();
            CustomerModel customer = GetCustomer();

            foreach (PhysicalProductModel prod in cart)
            {
                prod.ShipItem(customer);
            }

            Console.ReadLine();
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Paul",
                LastName = "Wechuli",
                City = "Nairobi",
                EmailAddress = "wechuli@wechuli.dev",
                PhoneNumber = "123456789"
            };
        }

        private static List<PhysicalProductModel> AddSampleData()
        {
            List<PhysicalProductModel> output = new List<PhysicalProductModel>();

            output.Add(new PhysicalProductModel { Title = "SSD Drive" });
            output.Add(new PhysicalProductModel { Title = "Mattress" });
            output.Add(new PhysicalProductModel { Title = "Duvee" });

            return output;
        }
    }
}
