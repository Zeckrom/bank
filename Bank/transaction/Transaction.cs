using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.transaction
{
    public class Transaction< TAccountKey> : AbstractTransaction<TAccountKey>
    {
        public Transaction(Guid number, TAccountKey sourceAccount, TAccountKey targetAccount, decimal amount, DateTime date, State state, Direction direction)
        {
            Number = number;
            SourceAccountNumber = sourceAccount;
            TargetAccountNumber = targetAccount;
            Amount = amount;
            Date = date;
            State = state;
            Direction = direction;
        }
    }
}
