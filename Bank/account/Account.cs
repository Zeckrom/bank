using System;
using System.Collections.Generic;
using System.Linq;
using Bank.transaction;

namespace Bank.account
{
    public class Account<TAccountKey,TClientKey> :AbstractAccount<TAccountKey,TClientKey>
    {

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Account<TAccountKey, TClientKey>);
        }

        public bool Equals(Account<TAccountKey, TClientKey> a)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(a, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, a))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != a.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return Object.Equals(AccountNumber, a.AccountNumber);
        }

        public Account(TAccountKey accountNumber, TClientKey clientKey, DateTime creationDate, bool isActive = true)
        {
            Transactions = new List<Transaction<TAccountKey>>();
            AccountNumber = accountNumber;
            Owner = clientKey;
            CreationDate = creationDate;
            IsActive = isActive;
            Balance = 1000;
        }

        public Account(TAccountKey accountNumber, TClientKey clientKey,bool isActive = true)
        {
            Transactions = new List<Transaction<TAccountKey>>();
            AccountNumber = accountNumber;
            Owner = clientKey;
            CreationDate = DateTime.Now;
            IsActive = isActive;
            Balance = 1000;
        }

        public override void Credit(decimal amount, TAccountKey accountNumber)
        {
            SendMoney(amount);
            Transactions.Add(new Transaction<TAccountKey>(
                Guid.NewGuid(),AccountNumber, accountNumber, amount, DateTime.Now, State.Accepted, Direction.Incoming));
        }

        public override void SendMoney(decimal amount)
        {
            Balance = Balance + amount;
        }

        public override void Debit(decimal amount, TAccountKey accountNumber)
        {
            if ((decimal)(amount + amount * TaxRatio) <= Balance)
            {
                SendMoney((decimal) (-(amount + amount * TaxRatio)));
                Transactions.Add(new Transaction<TAccountKey>(
                    Guid.NewGuid(), AccountNumber, accountNumber, amount, DateTime.Now, State.Accepted, Direction.Outgoing));
            }
            else
            {
                Console.WriteLine("you broke bro");
                Transactions.Add(new Transaction<TAccountKey>(
                    Guid.NewGuid(), AccountNumber, accountNumber, amount, DateTime.Now, State.Accepted, Direction.Outgoing));
            }
        }

        public override IEnumerable<Transaction< TAccountKey>> GetAllTransactions()
        {
            return Transactions;
        }

        public override IEnumerable<Transaction<TAccountKey>> GetTransactionsByDate(DateTime date)
        {
            return from transaction in Transactions
                where transaction.Date.Equals(date)
                select transaction;
        }

        public override IEnumerable<Transaction<TAccountKey>> GetTransactionsByTarget(TAccountKey accountKey)
        {
            return from transaction in Transactions
                where transaction.TargetAccountNumber.Equals(accountKey)
                select transaction;
        }

        public override IEnumerable<Transaction< TAccountKey>> GetTransactionsByQuery(Func<Transaction<TAccountKey>, bool> query)
        {

            return Transactions.Where(query);
           
        }
    }
}
