using System;
namespace Bank
{
    class Loan : Account
    {

        public Loan() : base()
        {
        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
            return true;
        }

        public static string getType()
        {
            return "Loan";
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            this.balance = balance - ammount;
            Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
            return true;
        }
    }
}
