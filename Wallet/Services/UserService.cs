using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Models;

namespace Wallet.Services
{
    public static class UserService
    {
        public static UserModel Get(string username, string password)
        {
            var users = new List<UserModel>();
            users.Add(new UserModel { Id = 1, Username = "test1@test.com", Password = "12345.", Role = "Analista" });
            users.Add(new UserModel { Id = 2, Username = "test2@test.com", Password = "12345.", Role = "Desarrollador" });
            users.Add(new UserModel { Id = 3, Username = "test3@test.com", Password = "12345.", Role = "Coordinadora" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
