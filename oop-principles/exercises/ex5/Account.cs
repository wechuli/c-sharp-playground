using System;
using System.Collections.Generic;

namespace ex5
{
    public abstract class Account
    {


        public Guid AccountId { get; protected set; }
        // day the account was opened
        public DateTime accountOpenDate { get; protected set; }
        private double balance = 0;
        public double Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                this.balance = value;
            }
        }
        public Customer accountCustomer { get; protected set; }

        public double InterestRate { get; protected set; }

        public double DepositMoneyToAccount(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be less than 0");
            }
            this.balance += amount;
            return this.Balance;

        }
        public abstract double CalculateInterest(int numberOfMonths);

    }
    public class LoanAccount : Account
    {

        public static double interestRate = 14.2;


        public LoanAccount(Customer customer)
        {
            this.accountCustomer = customer;
            this.InterestRate = LoanAccount.interestRate;
            this.AccountId = Guid.NewGuid();
            this.accountOpenDate = DateTime.Now;
        }
        public override double CalculateInterest(int numberOfMonths)
        {

            if (numberOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be below zero");
            }
            Type customerType = this.accountCustomer.GetType();

            if (customerType.Equals(typeof(Individual)))
            {
                if (numberOfMonths <= 3)
                {
                    return 0;
                }
                return (numberOfMonths - 3) * this.InterestRate;

            }
            else if (customerType.Equals(typeof(Company)))
            {
                if (numberOfMonths <= 2)
                {
                    return 0;
                }
                return (numberOfMonths - 2) * this.InterestRate;

            }
            else
            {
                throw new Exception("Invalid Customer type");
            }


        }



    }
    public class DepositAccount : Account
    {


        public static double interestRate = 8;


        public DepositAccount(Customer customer)
        {
            this.accountCustomer = customer;
            this.InterestRate = DepositAccount.interestRate;
            this.AccountId = Guid.NewGuid();
            this.accountOpenDate = DateTime.Now;

        }
        public double WithDrawFromAccount(double amountToWithdraw)
        {
            if (amountToWithdraw > this.Balance)
            {
                throw new ArgumentException("Amount to be withdrawn exceeds the balance");
            }
            this.Balance -= amountToWithdraw;
            return this.Balance;
        }
        public override double CalculateInterest(int numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be below zero");
            }
            // If less than 1000 in balance, no interest
            if (this.Balance < 1000)
            {
                return 0;
            }
            return numberOfMonths * this.InterestRate;
        }

    }
    public class MortgageAccount : Account
    {

        public static double interestRate = 4.5;


        public DepositAccount(Customer customer)
        {
            this.accountCustomer = customer;
            this.InterestRate = MortgageAccount.interestRate;
            this.AccountId = Guid.NewGuid();
            this.accountOpenDate = DateTime.Now;

        }

        public override double CalculateInterest(int numberOfMonths)
        {

            if (numberOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be below zero");
            }
            Type customerType = this.accountCustomer.GetType();

            if (customerType.Equals(typeof(Individual)))
            {
                if (numberOfMonths <= 6)
                {
                    return 0;
                }
                return (numberOfMonths - 6) * this.InterestRate;

            }
            else if (customerType.Equals(typeof(Company)))
            {
                if (numberOfMonths <= 12)
                {
                    return 0.5 * numberOfMonths * this.InterestRate;
                }
                return (0.5 * 12 * this.InterestRate) + ((numberOfMonths - 12) * this.InterestRate);

            }
            else
            {
                throw new Exception("Invalid Customer type");
            }


        }



    }

}