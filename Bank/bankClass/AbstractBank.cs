using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Bank.account;
using Bank.client;
using Bank.transaction;

namespace Bank.bankClass
{
    abstract class AbstractBank<TBankKey, TAccountKey, TClientKey> : IBank<TAccountKey, TClientKey>
    {
        public string Name { get; set; }
        public TBankKey SWIFT { get; set; }
        public int Agents { get; set; }
        public static Queue<Transaction<TAccountKey>> TransactionQueue { get; set; }

        public abstract void AddAgent(int number = 1);
        public abstract void RemoveAgent(int number = 1);
        public abstract void AddTransaction(Transaction<TAccountKey> transaction);
        public abstract void Load(string path);
        public abstract Lazy<IEnumerable<Transaction<TAccountKey>>> GetAllTransactions();
        public abstract Lazy<IEnumerable<Account<TAccountKey, TClientKey>>> GetAllAccounts();
        public abstract IEnumerable<Client<TAccountKey, TClientKey>> GetAllClients();
        public abstract void SaveFile(string path);
    }
}
