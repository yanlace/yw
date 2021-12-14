using System;

namespace Bank
{
    class Savings : Account
    {
        public Savings() : base()
        {
            type = "Savings Account";
            id = counter;
            counter++;
        }

        public Savings(double balance) : base()
        {
            this.balance = balance;
            type = "Loan Account";
            id = counter;
            counter++;
        }

        public override void deposit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance + "\n");
        }

        public override void withdraw(double amount)
        {

            this.balance -= amount;
            Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance + "\n");
        } 
    }
}