using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.transaction
{
    public abstract class AbstractTransaction<TAccountKey>
    {
        public Guid Number { get; set; }
        public TAccountKey SourceAccountNumber { get; set; }
        public TAccountKey TargetAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
        public Direction Direction { get; set; }
    }
}
