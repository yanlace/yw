using Apache.NMS.ActiveMQ.Util;
using System;
using System.Globalization;
using System.Linq;

namespace Bank
{
    class Bank
    {

        string id;//hold generated id  from idgenerator and add string
        public int idnum = 0;//index number for id
        //hold separated id in separated index
        public string[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] myAccType = new string[100];
        public string[] myDob = new string[100];
        public string[] myNominee = new string[100];
        public double[] myBalance = new double[100];

        IdGenerator id1 = new IdGenerator();
        DateTime dob = new DateTime();
        Credit cr = new Credit();
        Debit db = new Debit();
        Savings sv = new Savings();
        //see in create account
        public bool val = true;
        public bool debval = true;

        //id storing
        private void GetAcc(string ID)
        {
            myId[idnum] = ID;
            idnum++;

        }

        public void ShowAll()
        {
            Console.WriteLine("All accounts are:\n");
            for (int i = 0; i < idnum; i++)
            {
                Console.WriteLine(myId[i]);

            }
        }

        public void ShowInfo()
        {
            int indexNum;//specific index for showing information
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);//find out array number
                Console.WriteLine("Your details: ");
                Console.WriteLine("Name: " + myName[indexNum]);
                Console.WriteLine("Id: " + myId[indexNum]);
                Console.WriteLine("Acc Type: " + myAccType[indexNum]);
                Console.WriteLine("DOB: " + myDob[indexNum]);
                Console.WriteLine("Nominee: " + myNominee[indexNum]);
                Console.WriteLine("Balance: " + myBalance[indexNum]);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }


        }

        private static string GetUserName()
        {
            Console.Write("Name:");
            return Convert.ToString(Console.ReadLine());
        }

        private static string GetUserDOB() {
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

        private static string GetNominee()
        {
            Console.WriteLine("Enter Nominee name: ");
            return Convert.ToString(Console.ReadLine());
        }

        private double InsertBalance(string accType)
        {
            switch (accType)
            {
                case "Debit":
                    return InsertDebitBalance();
                case "Credit":
                    return InsertCrebitBalance();
                case "Savings":
                    Console.WriteLine("Enter account balance: ");
                    return Convert.ToDouble(Console.ReadLine());
                default:
                    Console.WriteLine("Enter account balance: ");
                    return Convert.ToDouble(Console.ReadLine());
            }
        }

        private double InsertDebitBalance()
        {
            double balance;
            bool isOverMax = false;
            do
            {
                if (isOverMax)
                    Console.WriteLine("Debit Account's max value is 100000!");

                Console.WriteLine("Enter account balance: ");
                balance = Convert.ToDouble(Console.ReadLine());
                isOverMax = balance > db.maxBalance;
            } while (isOverMax);

            return balance;
        }

        private double InsertCrebitBalance()
        {
            double balance;
            bool isUnderMin = false;
            do
            {
                if (isUnderMin)
                    Console.WriteLine("Credit Account's min val is -100000!");

                Console.WriteLine("Enter account balance: ");
                balance = Convert.ToDouble(Console.ReadLine());
                isUnderMin = balance < db.maxBalance;
            } while (isUnderMin);

            return balance;
        }

        private string CreateID(string accType)
        {
            string newAccountID;
            newAccountID = id1.GenerateId(); //collect id from id generator
            newAccountID += accType; //add string to that generated id
            Console.WriteLine("Your Account Id : " + newAccountID);
            return newAccountID;
        }

        public void Create_account()
        {
            string accType;
            string input;
            Console.WriteLine("0. Debit Account");
            Console.WriteLine("1. Credit Account");
            Console.WriteLine("2. Savings Account");
            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            switch (input)
            {
                case "0":
                    accType = "Debit";
                    myAccType[idnum] = accType;
                    myName[idnum] = GetUserName();
                    myDob[idnum] = GetUserDOB();
                    myNominee[idnum] = GetNominee();
                    myBalance[idnum] = InsertBalance(accType);
                    Console.WriteLine("Created debit account successfully...! ");
                    id = CreateID("Deb");
                    GetAcc(id);
                    break;

                case "1":
                    accType = "Credit";
                    myAccType[idnum] = accType;
                    myName[idnum] = GetUserName();
                    myDob[idnum] = GetUserDOB();
                    myNominee[idnum] = GetNominee();
                    myBalance[idnum] = InsertBalance(accType);
                    Console.WriteLine("Created Credit account successfully...! ");
                    id = CreateID("Cre");
                    GetAcc(id);
                    break;

                case "2":
                    accType = "Savings";
                    myAccType[idnum] = accType;
                    myName[idnum] = GetUserName();
                    myDob[idnum] = GetUserDOB();
                    myNominee[idnum] = GetNominee();
                    myBalance[idnum] = InsertBalance(accType);
                    Console.WriteLine("Created Savings account successfully...! ");
                    id = CreateID("Sav");
                    GetAcc(id);
                    break;
            }
        }

        public void Deposit()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                //passArrNum = indexNum;
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.deposit(depval);
                    myBalance[indexNum] = sv.balance;
                }

            }

            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }

        public void Withdraw()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to withdraw: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.withdraw(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.withdraw(depval);
                    myBalance[indexNum] = cr.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.withdraw(depval);
                    myBalance[indexNum] = sv.balance;
                }

            }

            else
            {
                Console.WriteLine("Your id is wrong!");
            }


        }
    }
}