using System;
using System.Threading.Tasks;

namespace CreditCard
{
    public class CreditCardApplication
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal GrossAnnualIncome { get; set; }
        public string FrequentFlyerNumber { get; set; }
    }


    interface IPerson
    {
        string firstName { get; set; }
        string lastName { get; set; }

    }
    public class Person : IPerson
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        private Boolean IsAdmin = false;
        public Person(string name)
        {
            this.firstName = name;
        }

        public async Task<string> ReturnFullName()
        {

            await Task.Delay(2000);
            return this.firstName + this.lastName;
        }
    }
}
