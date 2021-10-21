using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Interfaces;

namespace Wallet.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }       
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Addres { get; set; }      
        public string Telephone { get; set; }
    }
}
