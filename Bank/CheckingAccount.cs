using System;
namespace Bank
{
    class CheckingAccount : Account
    {
        public CheckingAccount() : base()
        {
        }

        public override bool deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override bool withdraw(double amount)
        {
            throw new NotImplementedException();
        }

        public static string getType()
        {
            return "Checking Account";
        }

        
    }
}
