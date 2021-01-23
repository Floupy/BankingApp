using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach(var t in transactions)
                {
                    balance += t.Amount;
                }
                return balance;
            }
        }
        public string Currency { get; }
        public DateTime DateCreated { get; }

        private List<Transaction> transactions = new List<Transaction>();

        public BankAccount(string number, string owner, decimal balance, string currency)
        {
            this.Number = number;
            this.Owner = owner;
            this.Currency = currency;
            this.DateCreated = DateTime.Now;

            this.AddToBalance(balance, DateTime.Now, "Initial balance");
        }

        public void Print()
        {
            Console.WriteLine($"- account {this.Number} created on {this.DateCreated}  belongs to {this.Owner} and has a balance of {this.Balance} {this.Currency} ");
        }


        public void AddToBalance(decimal amount, DateTime date, string note)
        {
            transactions.Add(new Transaction(amount, date, note));
        }

        

    }
}
