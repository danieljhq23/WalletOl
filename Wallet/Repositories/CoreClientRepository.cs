using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.DataContext;
using Wallet.Entities;
using Wallet.Interfaces;

namespace Wallet.Repositories
{
    public class CoreClientRepository : CoreRepository<Client, WalletDBContext>
    {
       
        public CoreClientRepository(WalletDBContext context) : base(context)
        {
           
        }      
       
    }
}
