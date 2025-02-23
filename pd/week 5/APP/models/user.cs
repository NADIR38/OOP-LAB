using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.models
{
    public class user
    {
        public string username;
        public string password;
        public string email;
        public user(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
}
