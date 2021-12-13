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

        public override bool deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override bool withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
