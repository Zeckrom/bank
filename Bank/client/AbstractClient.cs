using System;
using System.Collections.Generic;
using System.Text;
using Bank.account;

namespace Bank.client
{
    abstract class AbstractClient<TAccountKey,TClientKey>: IClient<TAccountKey,TClientKey>
    {
        public string Name { get; set; }
        public TClientKey Cin { get; set; }
        public List<Account<TAccountKey,TClientKey>> Accounts { get; set; }

        protected AbstractClient(TClientKey cin, string name)
        {
            Cin = cin;
            Name = name;
            Accounts = new List<Account<TAccountKey, TClientKey>>();
        }
        public abstract IEnumerable<Account<TAccountKey,TClientKey>> GetAllAccounts();
        public abstract Account<TAccountKey,TClientKey> GetAccount(TAccountKey accountNumber);
        public abstract void CreateAccount(Account<TAccountKey,TClientKey> account);
        public abstract void CloseAccount(TAccountKey account);
    }
}
