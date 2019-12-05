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
            


            //    Create DepositAccount - individual
            DepositAccount individualDepositAccount = new DepositAccount(individualCustomer);
     


            //    Create DepositAccount - company


            //    Create LoanAccount - individual

            //    Create LoanAccount - company


            //    Create MortgageAccount - individual

            //    Create MortgageAccount - company

        }
    }
}
