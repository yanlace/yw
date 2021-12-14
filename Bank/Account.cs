using System;


namespace Bank
{
   abstract class Account
    {
        protected static int counter = 1;
        protected int id { get; set; }
        public double balance;
        protected string type;

        public abstract void deposit(double amount);

        public abstract void withdraw(double amount);
        
        public double getBalance()
        {
            return balance;
        }
        public void printAccount()
        {
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Balance : $" + balance + "\n");
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

        public void DisplayAccountCreatedMessage()
        {
            Console.WriteLine(type + " created successfully!");
            Console.WriteLine("Your account ID is " + id);
        }
    }
}