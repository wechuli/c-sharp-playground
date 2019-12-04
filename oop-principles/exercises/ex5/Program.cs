using System;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test customers

            Customer individualCustomer = new Individual("Paul", "Wechuli");
            Customer companyCustomer = new Company("Microsoft");
            Console.WriteLine(individualCustomer);
            Console.WriteLine(companyCustomer);
        }
    }
}
