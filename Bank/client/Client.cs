using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bank.account;

namespace Bank.client
{
    class Client<TAccountKey,TClientKey> : AbstractClient<TAccountKey,TClientKey>
    {
        public override IEnumerable<Account<TAccountKey,TClientKey>> GetAllAccounts()
        {
            return Accounts;
        }

        public override Account<TAccountKey, TClientKey> GetAccount(TAccountKey accountNumber)
        {
            var result = from account in Accounts
                where
                    account.AccountNumber.Equals(accountNumber)
                select account;
            return result.FirstOrDefault();
        }

        public override void CreateAccount(Account<TAccountKey,TClientKey> account)
        {
            Accounts.Add(account);
        }

        public override void CloseAccount(TAccountKey key)
        {
            Accounts.RemoveAll(account => account.AccountNumber.Equals(key));
        }

        public Client(TClientKey cin, string name) : base(cin, name)
        {
        }
    }
}
