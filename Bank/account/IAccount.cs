using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Bank.transaction;

namespace Bank.account
{
    interface IAccount<TAccountKey>
    {

        void Debit(decimal amount, TAccountKey accountNumber);
        void Credit(decimal amount, TAccountKey accountNumber);
        void SendMoney(decimal amount);
        IEnumerable<Transaction< TAccountKey>> GetAllTransactions();
        IEnumerable<Transaction<TAccountKey>> GetTransactionsByDate(DateTime date);
        IEnumerable<Transaction<TAccountKey>> GetTransactionsByTarget(TAccountKey target);
        IEnumerable<Transaction<TAccountKey>> GetTransactionsByQuery(Func<Transaction<TAccountKey>, bool> query);
    }
}
