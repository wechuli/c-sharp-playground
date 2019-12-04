using System;
using System.Collections.Generic;

namespace ex5
{

    public abstract class Customer
    {
        public Guid CustomerId { get; protected set; }


    }
    public class Individual : Customer
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }


        // create a customer, and note the day th
        public Individual(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CustomerId = Guid.NewGuid();

        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} - {this.CustomerId}";
        }

    }
    public class Company : Customer
    {
        public string CompanyName { get; protected set; }

        public Company(string companyName)
        {
            this.CompanyName = companyName;
            this.CustomerId = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"{this.CompanyName} - {this.CustomerId}";
        }


    }

}