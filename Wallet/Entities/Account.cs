using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Interfaces;

namespace Wallet.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public int AcctNumber { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public double Balance { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


    }
}
