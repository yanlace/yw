using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {


            string input;
            Bank bn = new Bank();
            Console.WriteLine("****  Welcome to Bank Management System  ***");
            while (true)
            {
                Console.WriteLine("What you want to do:");
                Console.WriteLine("0. Create account");
                Console.WriteLine("1. Show account information");
                Console.WriteLine("2. Deposit from account");
                Console.WriteLine("3. Withdraw from account");
                Console.WriteLine("4. Show all account with id");
                Console.WriteLine("5. Clear screen");
                Console.WriteLine("6. Exit");
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);

                //for 0-6  funtion calling
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Enter account Type :");
                        bn.Create_account();

                        break;
                    case "1":
                        Console.Write("Enter account Number :");
                        bn.ShowInfo();
                        break;
                    case "2":
                        Console.WriteLine("Enter Account Id: ");
                        bn.Deposit();
                        break;
                    case "3":
                        Console.WriteLine("Enter Account Id: ");
                        bn.Withdraw();
                        break;
                    case "4":
                        bn.ShowAll();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();


            }

            // Console.ReadKey();

        }



    }
}