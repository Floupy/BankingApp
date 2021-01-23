using System;
using System.Collections.Generic;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Datorium Digital Bank***");
            Console.WriteLine("");

            List<BankAccount> accounts = new List<BankAccount>();



            accounts.Add(new BankAccount("DDB123456789", "Linus Torwalds", 4000000, "EUR"));
            accounts.Add(new BankAccount("DDB123456790", "Anna Kurnikova", 10000000, "RUB"));
            accounts.Add(new BankAccount("DDB123456791", "Jenifer Lopez", 200, "USD"));

            accounts[0].AddToBalance(1000000, new DateTime(2015, 12, 31, 5, 10, 20), "Donations");
            accounts[0].AddToBalance(2000, DateTime.Now, "Lecture");


            foreach (var account in accounts)
            {
                account.Print();
            }

            
            
        }
    }

    
    
}
