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
            if(amount < 0)
            {
                //throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be possitive");
                Console.WriteLine("Can not add, amount must be positive!");
                return;
            }

            transactions.Add(new Transaction(amount, date, note));
        }
        public void TakeFromBalance(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                //throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be possitive");
                Console.WriteLine("Can not withdraw, amount must be positive!");
                return;
            }

            if(this.Balance - amount < 0)
            {
                Console.WriteLine("Can not withdraw, not sufficient funds!");
                return;
            }

            transactions.Add(new Transaction(-amount, date, note));
        }

        public void PrintTransactions()
        {
            Console.WriteLine($"A printout for  {this.Number} {this.Owner}");
            Console.WriteLine("----------------------------------------------------");
            foreach (var t in transactions)
            {
                Console.WriteLine($" {t.Date} : {t.Amount} {Currency}");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Balance: {this.Balance} {this.Currency}");
            Console.WriteLine("----------------------------------------------------");
        }

    }
}
