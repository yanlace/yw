using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bank
{
    class User
    {
        public static int counter = 1;
        public string Id { get;}
        public string password { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public bool isEmployee { get; set; }
        public List<Savings> savingsAccounts = new();
        public List<CheckingAccount> checkingAccounts = new();
        public List<Loan> loanAccounts = new();
        
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
                    CheckingAccount checking = new(GetInitialBalance());
                    checking.DisplayAccountCreatedMessage();
                    checkingAccounts.Add(checking);
                    break;
                case 'S':
                    Savings savings = new(GetInitialBalance());
                    savings.DisplayAccountCreatedMessage();
                    savingsAccounts.Add(savings);
                    break;

                case 'L':
                    Loan loan = new(GetInitialBalance());
                    loan.DisplayAccountCreatedMessage();
                    loanAccounts.Add(loan);
                    break;
            }
        }

        private double GetInitialBalance()
        {
            Console.WriteLine("Enter account balance: ");

            return Convert.ToDouble(Console.ReadLine());
        }


        public void ViewAllBalancesAndTransactions()
        {
            if (checkingAccounts.Count == 0 &&
                savingsAccounts.Count == 0 &&
                loanAccounts.Count == 0)
            {
                Console.WriteLine("There are no accounts associated with this user!");
                return;
            }
            foreach (CheckingAccount checking in checkingAccounts)
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

        public void ShowInfo()
        {
            Console.WriteLine("Your details: ");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Total number of accounts: "
                + (loanAccounts.Count + savingsAccounts.Count + checkingAccounts.Count));
            Console.WriteLine("DOB: " + dob.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Phone: " + phoneNumber);
            Console.WriteLine("Email: " + email);
        }

        private string GetUserDOB()
        {
            bool isDOBValid;
            DateTime dateTimeDOB = new DateTime();
            do
            {
                try
                {
                    Console.Write("Enter your Date of Birth (DD/MM/YYYY) : ");
                    string dob = Console.ReadLine();
                    dateTimeDOB = DateTime.ParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    isDOBValid = true;
                }
                catch (Exception)
                {
                    Console.Write("Enter a valid date!\n");
                    isDOBValid = false;
                }
            } while (!isDOBValid);
            return dateTimeDOB.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}
