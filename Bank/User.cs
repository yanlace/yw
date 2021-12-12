using System;
using System.Collections.Generic;

namespace Bank
{
    class User
    {
        public static int count = 0;
        public string Id { get;}
        public string password { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public bool isEmployee { get; set; }
        public List<Savings> savingsAccounts = new ();
        public List<CheckingAccount> checkingAccounts = new();
        public List<Loan> loanAccounts = new ();
        
        public User()
        {
            Id = Convert.ToString(count);
            count++;
        }

        public void OpenNewAccount(char accType)
        {
            Account account;
            switch (accType)
            {
                case 'C':
                    account = new CheckingAccount();
                    checkingAccounts.Add(account as CheckingAccount);
                    break;
                case 'S':
                    account = new Savings();
                    savingsAccounts.Add(account as Savings);
                    break;

                case 'L':
                    account = new Loan();
                    loanAccounts.Add(account as Loan);
                    break;
            }
        }

        public void ViewAllBalances()
        {
            foreach(CheckingAccount checking in checkingAccounts)
            {
                Console.WriteLine("Savings Account balance is $" + checking.balance);
                checking.printAccount();
            }
            foreach (Savings savings in savingsAccounts)
            {
                Console.WriteLine("Savings Account balance is $" + savings.balance);
                savings.printAccount();
            }
            foreach (Loan loan in loanAccounts)
            {
                Console.WriteLine("Savings Account balance is $" + loan.balance);
                loan.printAccount();
            }
        }
    }
}
