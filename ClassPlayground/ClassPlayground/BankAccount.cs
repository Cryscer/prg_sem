using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class BankAccount
    {
        //note static funkce jsou k pouziti funkce bez vytvoreni specificke nove instance (BankAccount account1 = new account), tedy nemusime si vytvorit account1. Dokonce i writeline je staticka funkce
        int accountNumber;
        string holderName;
        string currency;
        int balance;
        Random rnd = new Random();

        public BankAccount(string holderName, string currency)
        {
            this.holderName = holderName;
            this.currency = currency;
            accountNumber = rnd.Next(100000000, 1000000000);
            balance = 0;
        }

        public void Deposit(int amount)
        {
            if (amount < 0) amount = 0;
            balance += amount;
            Console.WriteLine("Successfully deposited " + amount + " " + currency);
        }

        public int Withdraw(int amount)
        {
            if (amount < 0) amount = 0;
            if (amount > balance)
            {
                amount = 0;
                Console.WriteLine("Not enough money in account!");
            }
            balance -= amount;
            Console.WriteLine("Successfully withdrawn " + amount + " " + currency);
            return amount;
        }
        static void Transfer(BankAccount accountFrom, BankAccount accountTo, int amount) 
        {
            if (amount < 0)
            {
                amount = 0;
                Console.WriteLine("Cannot transfer a ngative amount!");
            }
            else if (amount > accountFrom.balance)
            {
                amount = 0;
                Console.WriteLine("Not enough money in account!");
            }           
            else Console.WriteLine("Successfully transfered " + amount + " " + accountTo.currency + " to " + accountTo.holderName);
            accountFrom.balance -= amount;
            accountTo.balance += amount;                    
        }
    }
}
