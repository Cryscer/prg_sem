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

        public BankAccount(int accountNumber, string holderName, string currency, int balance)
        {
            this.accountNumber = accountNumber;
            this.holderName = holderName;
            this.currency = currency;
            this.balance = balance;
        }

        public void Deposit(int amount)
        {
            if (amount < 0) amount = 0;
            balance += amount;
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
            else Console.WriteLine("Successfully transfered");
            accountFrom.balance -= amount;
            accountTo.balance += amount;           
        }
    }
}
