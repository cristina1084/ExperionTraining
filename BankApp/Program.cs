/*A sample application to handle different bank accounts/fund transfer. 
  There is no need to use a database. Keep the data locally in a data structure. 
  Perform operations like credit/debit amount to an account.*/

using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string custName;
            int amount;
            long accno;
            long accno1;
            bool flag = false, flag1 = false;
            Random random = new Random();
            List<Accounts> accounts = new List<Accounts>();
            while (true)
            {
                Console.WriteLine("\n1. Create Account\n2. Credit\n3. Debit\n4. Transfer Funds\n5. Display\n6. Exit\n");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter name: ");
                        custName = Console.ReadLine();
                        accounts.Add(new Accounts { AccountNumber = random.Next(999999999), CustomerName = custName, AccountBalance = 0 });
                        break;

                    case 2:
                        Console.Write("Enter Account Number: ");
                        accno = Convert.ToInt64(Console.ReadLine());
                        foreach (var acc in accounts)
                        {
                            if(acc.AccountNumber == accno)
                            {
                                Console.Write("Enter amount to credit: ");
                                amount = Convert.ToInt32(Console.ReadLine());
                                acc.AccountBalance += amount;
                                flag = true;
                                break;
                            }
                        }
                        if(!flag)
                            Console.WriteLine("Account not found!\n");
                        break;

                    case 3:
                        Console.Write("Enter Account Number: ");
                        accno = Convert.ToInt64(Console.ReadLine());
                        flag = false;
                        foreach (var acc in accounts)
                        {
                            if(acc.AccountNumber == accno)
                            {
                                Console.Write("Enter amount to debit: ");
                                amount = Convert.ToInt32(Console.ReadLine());
                                if (acc.AccountBalance > amount)
                                    acc.AccountBalance -= amount;
                                else
                                    Console.WriteLine("No sufficient balance");
                                flag = true;
                                break;
                            }
                        }
                        if(!flag)
                            Console.WriteLine("Account not found!!\n");
                        break;

                    case 4:
                        Console.Write("Enter your account number: ");
                        accno = Convert.ToInt64(Console.ReadLine());
                        flag = false;
                        foreach (var acc in accounts)
                        {
                            if(acc.AccountNumber == accno)
                            {
                                Console.Write("Enter the account number to transfer fund: ");
                                accno1 = Convert.ToInt64(Console.ReadLine());
                                foreach (var acc1 in accounts)
                                {
                                    if (acc1.AccountNumber == accno1)
                                    {
                                        Console.Write("Enter amount to transfer: ");
                                        amount = Convert.ToInt32(Console.ReadLine());
                                        if (acc.AccountBalance > amount)
                                        {
                                            acc.AccountBalance -= amount;
                                            acc1.AccountBalance += amount;
                                        }
                                        else
                                            Console.WriteLine("No sufficient balance");
                                        flag1 = true;
                                        break;
                                    }
                                }
                                if(!flag1)
                                    Console.WriteLine("Account not found");
                                flag = true;
                                break;
                            }
                        }
                        if(!flag)
                            Console.WriteLine("Account not found");
                        break;

                    case 5:
                        Console.WriteLine("Account Number | Customer Name   | Account Balance");
                        Console.WriteLine("--------------------------------------------------");
                        foreach (var acc in accounts)
                            Console.WriteLine("{0,-14} | {1,-15} | {2}", acc.AccountNumber, acc.CustomerName, acc.AccountBalance);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
