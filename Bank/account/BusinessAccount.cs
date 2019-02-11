using System;
using System.Collections.Generic;
using System.Text;
using Bank.transaction;

namespace Bank.account
{
    class BusinessAccount<TAccountKey,TClientKey> : Account<TAccountKey,TClientKey> 
    {
        public BusinessAccount(TAccountKey accountNumber, TClientKey clientKey, DateTime creationDate, bool isActive = true) : base(accountNumber, clientKey, creationDate, isActive)
        {
            Transactions = new List<Transaction<TAccountKey>>();
            AccountNumber = accountNumber;
            Owner = clientKey;
            CreationDate = creationDate;
            IsActive = isActive;
        }

        public BusinessAccount(TAccountKey accountNumber, TClientKey clientKey, bool isActive = true) : base(accountNumber, clientKey, isActive)
        {
            Transactions = new List<Transaction<TAccountKey>>();
            AccountNumber = accountNumber;
            Owner = clientKey;
            CreationDate = DateTime.Now;
            IsActive = isActive;
        }

        public override decimal TaxRatio => (decimal) 0.01;
    }
}
