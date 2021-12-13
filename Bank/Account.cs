using System;


namespace Bank
{
   abstract class Account
    {
        protected static int counter = 1;
        protected int id { get; set; }
        public double balance;
        protected string type;

        public abstract bool deposit(double amount);

        public abstract bool withdraw(double amount);
        
        public double getBalance()
        {
            return balance;
        }
        public void printAccount()
        {
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Balance : $" + balance);
        }
        public Account()
        {
            balance = 0.0;
        }
        public Account(double balance)
        {
            this.balance = balance;
        }

        public string getType()
        {
            return type;
        }

        public int getID()
        {
            return id;
        }
    }
}