using System;
namespace Bank
{
    class Loan : Account
    {
        public Loan() : base()
        {
            type = "Loan";
            id = counter;
            counter++;
        }

        public override bool deposit(double amount)
        {
            this.balance -= amount;
            Console.WriteLine("You paid $" + amount
                + " balance has been paid. The balance is: " + balance);
            return true;
        }

        public override bool withdraw(double amount)
        {
            this.balance += amount;
            Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
            return true;
        }
    }
}
