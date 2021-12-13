using System;

namespace Bank
{
    class Savings : Account
    {
        public Savings() : base()
        {
            type = "Savings";
            id = counter;
            counter++;
        }

        public override bool deposit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
            return true;
        }

        public override bool withdraw(double amount)
        {

            this.balance -= amount;
            Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
            return true;
        }
    }
}