using System;
using System.Collections.Generic;
using System.Text;
using Bank.account;

namespace Bank.client
{
    interface IClient<TAccountKey,TClientKey>
    {
        IEnumerable<Account<TAccountKey,TClientKey>> GetAllAccounts();
        Account<TAccountKey,TClientKey> GetAccount(TAccountKey accountNumber);
        void CreateAccount(Account<TAccountKey, TClientKey> account);
        void CloseAccount(TAccountKey account);
    }
}
