using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Models
{
    public class UpdateAccountModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }        
        public double Amount { get; set; }
    }
}
