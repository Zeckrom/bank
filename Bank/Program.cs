using System;
using System.Collections.Generic;
using Bank.account;
using Bank.client;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BusinessAccount<int, int> account = new BusinessAccount<int, int>(8, 6, true);
            account.Credit(100, 9);
            account.Credit(100, 8);
            account.Credit(100, 6);
            account.Credit(100, 1);
            Console.WriteLine(account.Transactions);
            Console.WriteLine("Hello World!");
        }
    }
}
