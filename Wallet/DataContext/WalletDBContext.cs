using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities;

namespace Wallet.DataContext
{
    public class WalletDBContext : DbContext
    {
        public WalletDBContext() { }

        public WalletDBContext(DbContextOptions<WalletDBContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("Wallet_DB");
        }

    }
}
