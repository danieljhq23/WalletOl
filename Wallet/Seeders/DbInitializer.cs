using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.DataContext;
using Wallet.Entities;

namespace Wallet.Seeders
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new WalletDBContext(serviceProvider.GetRequiredService<DbContextOptions<WalletDBContext>>()))
            {

                if (_context.Clients.Any())
                {
                    return;
                }

                _context.Clients.AddRange(
                    new Client { FirstName = "Jose", LasttName = "Lopez", Addres = "Caracas", Telephone = "58412-323245" },
                    new Client { FirstName = "Pedro", LasttName = "Gutierrez", Addres = "Panama", Telephone = "98765432"},
                    new Client { FirstName = "Carlos", LasttName = "Marcano", Addres = "Santo Domingo", Telephone = "1234567" }
                 );

                _context.SaveChanges();
                                

                if (_context.Accounts.Any())
                {
                    return;
                }

                _context.Accounts.AddRange(
                    new Account
                    {
                        AcctNumber = 123456,
                        ClientID = _context.Clients.FirstOrDefault(c => c.FirstName.Equals("Jose")).Id,
                        Balance = 10,
                        Created = Convert.ToDateTime("14/10/2021 08:00"),
                        Modified = Convert.ToDateTime("14/10/2021 15:00"),                        
                    },

                    new Account
                    {
                        AcctNumber = 123456,
                        ClientID = _context.Clients.FirstOrDefault(c => c.FirstName.Equals("Pedro")).Id,
                        Balance = 10,
                        Created = Convert.ToDateTime("14/10/2021 08:00"),
                        Modified = Convert.ToDateTime("14/10/2021 15:00"),
                    },

                     new Account
                     {
                         AcctNumber = 123456,
                         ClientID = _context.Clients.FirstOrDefault(c => c.FirstName.Equals("Carlos")).Id,
                         Balance = 10,
                         Created = Convert.ToDateTime("14/10/2021 08:00"),
                         Modified = Convert.ToDateTime("14/10/2021 15:00"),
                     },

                      new Account
                      {
                          AcctNumber = 1234562,
                          ClientID = _context.Clients.FirstOrDefault(c => c.FirstName.Equals("Carlos")).Id,
                          Balance = 15,
                          Created = Convert.ToDateTime("14/10/2021 08:00"),
                          Modified = Convert.ToDateTime("14/10/2021 15:00"),
                      }
                );

                _context.SaveChanges();
            }
        }
    }
}