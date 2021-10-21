using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Models
{
    public class CreateAccountModel
    {
        public int AcctNumber { get; set; }
        public int ClientId { get; set; }       
        public double Balance { get; set; }
    }
}
