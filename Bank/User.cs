using System;
using System.Collections.Generic;

namespace Bank
{
    class User
    {
        public static int counter = 0;
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
            Id = Convert.ToString(counter);
            counter++;
        }

        public void OpenNewAccount(char accType)
        {
            
            switch (accType)
            {
                case 'C':
                    CheckingAccount checking = new();
                    checkingAccounts.Add(checking);
                    break;
                case 'S':
                    //Savings savings = new();
                    //savingsAccounts.Add(savings);
                    break;

                case 'L':
                    //Loan loan = new();
                    //loanAccounts.Add(loan);
                    break;
            }
        }

        public void ViewAllBalancesAndTransactions()
        {
            foreach(CheckingAccount checking in checkingAccounts)
            {
                Console.WriteLine("Checking Account balance is $" + checking.balance);
                checking.printAccount();
            }
            foreach (Savings savings in savingsAccounts)
            {
                Console.WriteLine("Savings Account balance is $" + savings.balance);
                savings.printAccount();
            }
            foreach (Loan loan in loanAccounts)
            {
                Console.WriteLine("Loan balance is $" + loan.balance);
                loan.printAccount();
            }
        }

        public void MakeLoanPayment()
        {
            Console.WriteLine("Current Loan Accounts");
            Console.WriteLine("Choose which to make payment on:");
            int index = 0;
            foreach (var loan in loanAccounts)
            {
                Console.WriteLine(index + ". make payment Loan Account: $" + loan.balance);
                index++;
            }

            int input = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter the amount you would like to pay on the loan:");
            double amount = Convert.ToDouble(Console.ReadLine());
            loanAccounts[input].deposit(amount);
        }
    }
}
