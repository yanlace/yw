using System;
namespace Bank
{
    class Loan : Account
    {
        double interestRate = 0.07;
        int durationInMonths = 24;
        double principalAmount;

        public Loan() : base()
        {
            type = "Loan Account";
            id = counter;
            counter++;
        }

        public Loan(double principalAmount) : base()
        {
            this.principalAmount = principalAmount;
            balance = principalAmount;
            type = "Loan Account";
            id = counter;
            counter++;
        }

        public override void deposit(double amount)
        {
            this.balance -= amount;
            Console.WriteLine("You paid $" + amount
                + " towards the loan balance.\nThe balance is: " + balance + "\n");
        }

        public override void withdraw(double amount)
        {
            this.balance += amount;
            Console.WriteLine("You account balance has been withdrawed.\nBalance is: " + balance + "\n");
        }

        private void CompoundInterest()
        {
            balance += CalculateMonthlyInterest();
        }

        private double CalculateMonthlyInterest()
        {
            return (interestRate / 12) * principalAmount;
        }
    }
}
