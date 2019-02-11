using System;
using System.Collections.Generic;
using System.Text;
using Bank.account;
using Bank.client;
using Bank.transaction;

namespace Bank.bankClass
{
    interface IBank<TAccountKey, TClientKey>
    {
        void AddAgent(int number = 1);
        void RemoveAgent(int number = 1);
        void AddTransaction(Transaction<TAccountKey> transaction);
        void Load(string path);
        Lazy<IEnumerable<Transaction<TAccountKey>>> GetAllTransactions();
        Lazy<IEnumerable<Account<TAccountKey,TClientKey>>> GetAllAccounts();
        IEnumerable<Client<TAccountKey,TClientKey>> GetAllClients();
        void SaveFile(string path);
    }
}
