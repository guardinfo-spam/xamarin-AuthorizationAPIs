using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinDemo.Business.Models
{
    public sealed class UserLoginModel
    {
        public readonly string Username;
        public readonly string Password;

        public UserLoginModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Username) && !string.IsNullOrWhiteSpace(this.Password);
        }
    }
}
