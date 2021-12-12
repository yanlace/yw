using System;


namespace Bank
{
   abstract class Account
    {
        public readonly string nickName;
        public readonly string ID;
        public readonly string nominee;
        public double balance;
        protected string type;
        public double ammount;
        public abstract bool deposit(double amount);

        public abstract bool withdraw(double amount);
        
        public double getBalance()
        {
            return balance;
        }
        public void printAccount()
        {
            Console.WriteLine("Name : " + nickName);
            Console.WriteLine("Balance :" + balance);
        }
        public Account()
        {
        }
        public Account(string name, string nominee, double balance)
        {
            this.nickName = name;
            this.nominee = nominee;
            this.balance = balance;
        }
    }
}