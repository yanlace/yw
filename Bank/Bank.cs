using System;
using System.Collections.Generic;

namespace Bank
{
    class Bank
    {
        private List<User> users = new();
        //see in create account
        public bool val = true;
        public bool debval = true;

        public Bank()
        {
            //admin user
            CreateMockData("Yanique", "123", true); //id is 1
            //regular customer users
            CreateMockData("Drew", "abcd", false); // id is 2
            CreateMockData("wallace", "efgh", false); // id is 3
        }

        private void CreateMockData(
            string name,
            string password,
            bool isEmployee)
        {
            User user = new();
            user.name = name;
            user.password = password;
            user.isEmployee = isEmployee;
            users.Add(user);
        }

        public User findCustomer(string id)
        {
            foreach (User customer in users)
            {
                if (customer.Id == id && !customer.isEmployee) return customer;
            }
            return null;
        }

        public User findAdmin(string id)
        {
            foreach (User admin in users)
            {
                if (admin.Id == id && admin.isEmployee) return admin;
            }
            return null;
        }

        public void ViewAllAccounts()
        {
            foreach(User user in users)
            {
                if (!user.isEmployee)
                {
                    Console.WriteLine("\t\t" + user.name + "'s balance and transactions.");
                    user.ViewAllBalancesAndTransactions();
                    Console.WriteLine("\n\n\n");
                }
            }
        }

        public bool LoginCustomer(string id, string password)
        {
            return findCustomer(id) != null && findCustomer(id).password == password;
        }

        public bool LoginAdmin(string id, string password)
        {
            return findAdmin(id) != null && findAdmin(id).password == password;
        }
        

        private static string GetUserName()
        {
            Console.Write("Name:");
            return Convert.ToString(Console.ReadLine());
        }

        public void AddUser(bool isEmployee)
        {
            User user = new();
            Console.WriteLine("Your ID: " + user.Id);
            user.name = GetUserName();
            user.isEmployee = isEmployee;
            //todo: set the other user properties
        }
    }
}