using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Optimized_Banking_System
{
    class Program
    {
        public class BankAccount
        {
            public string Bank { get; set; }
            public string Name { get; set; }
            public decimal Balance { get; set; }

            public static BankAccount Parse(string inputData)
            {
                var tokens = inputData.Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var bank = tokens[0];
                var accountName = tokens[1];
                var balance = decimal.Parse(tokens[2]);

                var result = new BankAccount()
                {
                    Bank = bank,
                    Name = accountName,
                    Balance = balance
                };

                return result;
            }
        }

        static void Main()
        {
            var inputData = Console.ReadLine();
            var accountsList = new List<BankAccount>();

            while (inputData != "end")
            {
                var currentAccount = BankAccount.Parse(inputData);
                accountsList.Add(currentAccount);
                inputData = Console.ReadLine();
            }

            accountsList = accountsList.OrderByDescending(x => x.Balance).ThenBy(x => x.Bank.Length).ToList();
            accountsList.ForEach(x => Console.WriteLine($"{x.Name} -> {x.Balance} ({x.Bank})"));
        }
    }
}
