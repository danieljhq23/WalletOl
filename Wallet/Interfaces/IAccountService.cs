using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities;
using Wallet.Models;

namespace Wallet.Interfaces
{
    public interface IAccountService
    {
        Task<ActionResult<Account>> SaveAccountAsync(CreateAccountModel input);
        Task<ActionResult<Account>> AddCredit(UpdateAccountModel input);
        Task<ActionResult<OutputBalance>> GetBalanceClient(int clientId);
    }
}
