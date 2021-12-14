using System;

namespace Bank
{
    class Program
    {
        static readonly string TitleFormat = "**** {0} ****";
        
        static void Main(string[] args)
        {
            Bank bn = new();
            WelcomeScreen(bn);
        }

        private static void setTitle(string title)
        {
            title = string.Format(TitleFormat, title);
            Console.WriteLine(title);
        }

        private static void WelcomeScreen(Bank bank)
        {
            string input;
            do
            {
                Console.Clear();
                setTitle("Welcome to Bank Management System");
                Console.WriteLine("What you want to do:");
                Console.WriteLine("0. Customer Login");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("9. Exit");
                input = Console.ReadLine();
            
                switch (input)
                {
                    case "0":
                        LoginCustomer(bank);
                        break;
                    case "1":
                        LoginAdmin(bank);
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        private static void LoggedInCustomerOperations(Bank bank, User user)
        {
            if (user == null)
            {
                Console.WriteLine("User Not Found!\n\n\n\n");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
            string input;
            while (true)
            {
                Console.WriteLine("What you want to do:");
                Console.WriteLine("0. View all account balances and transactions");
                Console.WriteLine("1. Open a checking account");
                Console.WriteLine("2. Open a savings account");
                Console.WriteLine("3. Apply for a loan");
                Console.WriteLine("4. Make Loan Payment");
                Console.WriteLine("9. To Log Out");
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);

                switch (input)
                {
                    case "0":
                        user.ViewAllBalancesAndTransactions();
                        break;
                    case "1":
                        user.OpenNewAccount('C');
                        break;
                    case "2":
                        user.OpenNewAccount('S');
                        break;
                    case "3":
                        user.OpenNewAccount('L');
                        break;
                    case "4":
                        user.MakeLoanPayment();
                        break;
                    case "9":
                        WelcomeScreen(bank);
                        break;
                }
                Console.ReadKey();
            }
        }

        private static void LoginCustomer(Bank bank)
        {
            bool isAFailedAttempt = false;
            string accountId;
            string accountPassword;
            do
            {
                setTitle("Customer LogIn");
                if (isAFailedAttempt)
                    Console.WriteLine("Please try again, incorrect user ID or password!");
                Console.WriteLine("Enter user ID:");
                accountId = Console.ReadLine();
                Console.WriteLine("Enter user password:");
                accountPassword = Console.ReadLine();
                isAFailedAttempt = !bank.LoginCustomer(accountId, accountPassword);
            } while (!bank.LoginCustomer(accountId, accountPassword));
            LoggedInCustomerOperations(bank, bank.findCustomer(accountId));
        }

        private static void AdminOperations(Bank bank, User adminUser)
        {
            if (adminUser == null || !adminUser.isEmployee)
            {
                Console.WriteLine("User Not Found!\n\n\n\n");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }

            string input;
            do
            {
                Console.WriteLine("What you want to do:");
                Console.WriteLine("0. View all account balances");
                Console.WriteLine("9. To Log Out");
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);

                switch (input)
                {
                    case "0":
                        setTitle("All Account Balances and Transactions");
                        Console.Write("\n");
                        bank.ViewAllAccounts();
                        break;
                    case "9":
                        WelcomeScreen(bank);
                        break;
                }
                Console.ReadKey();
            } while (true);
        }

        private static void AddNewCustomer(Bank bank)
        {
            setTitle("Enter Customer Info");
            bank.AddUser(false);
            Console.WriteLine("Customer added succesfully!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private static void LoginAdmin(Bank bank)
        {
            bool isAFailedAttempt = false;
            string accountId;
            string accountPassword;
            do
            {
                setTitle("Admin LogIn");
                if (isAFailedAttempt)
                    Console.WriteLine("Please try again, incorrect user ID or password!");
                Console.WriteLine("Enter account ID:");
                accountId = Console.ReadLine();
                Console.WriteLine("Enter account password:");
                accountPassword = Console.ReadLine();
                isAFailedAttempt = !bank.LoginAdmin(accountId, accountPassword);
            } while (!bank.LoginAdmin(accountId, accountPassword));
            AdminOperations(bank, bank.findAdmin(accountId));
        }
    }
}