using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Repository
{
    public class UserRepository
    {
        private static DatabaseTAxAidiEntities1 db = new DatabaseTAxAidiEntities1();
        public static bool insertUser(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static User getUser(string username, string password)
        {
            User user = (from x in db.Users where username == x.Username && password == x.Password select x).FirstOrDefault();
            return user;
        }

        public static User getUserById(int userId)
        {
            User user = (from x in db.Users where userId == x.Id select x).FirstOrDefault();
            return user;
        }

        public static bool UpdateUser(User user)
        {
            if (user != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}