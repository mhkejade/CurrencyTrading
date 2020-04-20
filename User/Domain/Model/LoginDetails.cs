using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyTrading.User.Domain.Model
{
    public class LoginDetails
    {
        public string Username { get; }
        public string Password { get; }

        public LoginDetails(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
