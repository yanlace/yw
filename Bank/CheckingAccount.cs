using System;
namespace Bank
{
    class CheckingAccount : Account
    {
        public CheckingAccount() : base()
        {
            type = "Checking Account";
            id = counter;
            counter++;
            Console.WriteLine(counter);
        }

        public CheckingAccount(double balance) : base()
        {
            this.balance = balance;
            type = "Loan Account";
            id = counter;
            counter++;
        }

        public override void deposit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("You account balance has been deposited.\nBalance is: " + balance);
        }

        public override void withdraw(double amount)
        {
            this.balance -= amount;
            Console.WriteLine("You account balance has been withdrawed.\nBalance is: " + balance);
        }
    }
}
