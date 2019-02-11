using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Bank.client;
using Bank.transaction;

namespace Bank.account
{
    public abstract class AbstractAccount<TAccountKey,TClientKey> : IAccount<TAccountKey>
    {
        public decimal Balance { get; set; }
        public TAccountKey AccountNumber { get; set; }
        public TClientKey Owner { get; set; }
        public List<Transaction<TAccountKey>> Transactions { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public virtual decimal TaxRatio { get;}


        public abstract void Credit(decimal amount, TAccountKey accountNumber);
        public abstract void Debit(decimal amount, TAccountKey accountNumber);
        public abstract IEnumerable<Transaction<TAccountKey>> GetAllTransactions();
        public abstract IEnumerable<Transaction<TAccountKey>> GetTransactionsByDate(DateTime date);
        public abstract IEnumerable<Transaction<TAccountKey>> GetTransactionsByQuery(Func<Transaction<TAccountKey>, bool> query);
        public abstract IEnumerable<Transaction<TAccountKey>> GetTransactionsByTarget(TAccountKey target);
        public abstract void SendMoney(decimal amount);
    }
}
