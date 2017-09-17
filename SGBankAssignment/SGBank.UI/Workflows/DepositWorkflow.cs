﻿using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            decimal amount = 0;
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

                Console.Write("Enter an account number: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Enter a deposit amount: ");

                decimal.TryParse(Console.ReadLine(), out amount);

                AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

                if (response.Success)
                {
                    Console.WriteLine("Deposit completed!");
                    Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                    Console.WriteLine($"Old balance: {response.OldBalance:c}");
                    Console.WriteLine($"Amount Deposited: {response.Amount:c}");
                    Console.WriteLine($"New balance: {response.Account.Balance:c}");
                }
                else
                {
                    Console.WriteLine("An error occurred: ");
                    Console.WriteLine(response.Message);
                }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
