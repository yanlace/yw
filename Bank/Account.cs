using System;


namespace Bank
{
   abstract class Account
    {
        public readonly string name;
        public readonly string ID;
        public readonly DateTime dob;
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
        public string getAccType()
        {
            string actype;
            actype = Convert.ToString(Console.ReadLine());
            return actype;
        }
        public void printAccount()
        {
           
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Date of Birth :" + dob);
            Console.WriteLine("Nominee : " + nominee);
            Console.WriteLine("Balance :" + balance);
        }
        public Account()
        {

        }
        public Account(string name, DateTime dob, string nominee, double balance)
        {
            this.name = name;
            this.dob = dob;
            this.nominee = nominee;
            this.balance = balance;
        }
    }
}