using System;
using System.Collections.Generic;
using System.Text;
using Bank.transaction;

namespace Bank.account
{
    class SavingAccount<TAccountKey,TClientKey> : Account<TAccountKey, TClientKey> 
    {
        public SavingAccount(TAccountKey accountNumber, TClientKey clientKey, DateTime creationDate, bool isActive = true) : base(accountNumber, clientKey, creationDate, isActive)
        {
            Transactions = new List<Transaction<TAccountKey>>();
            AccountNumber = accountNumber;
            Owner = clientKey;
            CreationDate = creationDate;
            IsActive = isActive;
        }

        public SavingAccount(TAccountKey accountNumber, TClientKey clientKey, bool isActive = true) : base(accountNumber, clientKey, isActive)
        {
            Transactions = new List<Transaction<TAccountKey>>();
            AccountNumber = accountNumber;
            Owner = clientKey;
            CreationDate = DateTime.Now;
            IsActive = isActive;
        }

        public override void Debit(decimal amount, TAccountKey accountNumber)
        {
            if ((decimal)(amount + Balance * TaxRatio) <= Balance)
            {
                SendMoney((decimal)(-(amount + amount * TaxRatio)));
                Transactions.Add(new Transaction<TAccountKey>(
                    Guid.NewGuid(), AccountNumber, accountNumber, amount, DateTime.Now, State.Ready, Direction.Incoming));
            }
            else
            {
                Console.WriteLine("you broke bro");
                Transactions.Add(new Transaction<TAccountKey>(
                    Guid.NewGuid(), AccountNumber, accountNumber, amount, DateTime.Now, State.Rejected, Direction.Outgoing));
            }
        }

        public override decimal TaxRatio => (decimal)0.0001;
    }
}
