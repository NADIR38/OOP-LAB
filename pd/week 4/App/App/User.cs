using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class User
    {
        public string username;
        public string password;
        public string roles;
        public User(string username,string password,string roles)
        {
            this.username = username;
            this.password = password;
            this.roles = roles;
        }
        static List<User> users = new List<User>();
        public string adduser(User user)
        {
            users.Add(user);
            return "user added succesfully";
        }
        public static User validateuser(string username,string password)
        {
            foreach(var User in users)
            {
                if(User.username==username && User.password==password)
                {
                    return User;
                }
            }
            return null;
        }

    }
    
}
