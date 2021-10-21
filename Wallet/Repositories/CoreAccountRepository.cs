using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.DataContext;
using Wallet.Entities;

namespace Wallet.Repositories
{
    public class CoreAccountRepository : CoreRepository<Account, WalletDBContext>
    {
        public CoreAccountRepository(WalletDBContext context) : base(context)
        {

        }
    }
}
