using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5.Models;

namespace Lesson5.Infrastructure
{
    public static class Users
    {
        static List<User> users;

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>(); 
            users.Add(
                new User{ Username = "peter" }); 
            users.Add(new User{  Username = "suol" }); 
            users.Add(new User{ Username = "tmlar" }); 
            users.Add(new User{ Username = "vibe"});
            return users;
        }

        public static bool UsernameIsUnique(string username)
        {

            var queryResult = from User in GetUsers() where User.Username == username select users;

            if (queryResult.ToList().Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
