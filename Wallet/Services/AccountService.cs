using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.DataContext;
using Wallet.Entities;
using Wallet.Interfaces;
using Wallet.Models;
using Wallet.Repositories;


namespace Wallet.Services
{
    public class AccountService : CoreRepository<Account, WalletDBContext>, IAccountService
    {
        private readonly ICoreRepository<Account> _accountBusiness;
        public AccountService(WalletDBContext context, CoreAccountRepository repository) : base(context)
        {
            _accountBusiness = repository;
        }

        public async Task<ActionResult<Account>> SaveAccountAsync(CreateAccountModel input)
        {
            Account newAccount = new Account();

            newAccount.AcctNumber = input.AcctNumber;
            newAccount.ClientID = input.ClientId;
            newAccount.Balance = input.Balance;
            newAccount.Created = DateTime.UtcNow;

            var addResult = await _accountBusiness.Add(newAccount);                    

            return newAccount;
        }

        public async Task<ActionResult<Account>> AddCredit(UpdateAccountModel input)
        {           
            var existingAccount = await _accountBusiness.Get(input.Id);

            var newBalance = existingAccount.Balance + input.Amount;

            existingAccount.Balance = newBalance;
            existingAccount.Modified = DateTime.UtcNow;

            var addResult = await _accountBusiness.Update(existingAccount);       

            return existingAccount;
        }

        public async Task<ActionResult<OutputBalance>> GetBalanceClient(int clientId)
        {
            OutputBalance balance = new();
            double total = 0;
            var data = await _accountBusiness.GetAsync(a => a.ClientID == clientId);

            foreach (var r in data)
            {
                total = total + r.Balance;
            }

            balance.ClientId = clientId;
            balance.Balance = total;

            return balance;
        }

    }
}
